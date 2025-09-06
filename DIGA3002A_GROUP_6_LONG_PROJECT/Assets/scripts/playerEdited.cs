using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerInput;
    private CharacterController _characterController;

    private Vector2 _moveInput;
    private Vector2 _lookInput;
    private Vector3 _velocity;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float originalSpeed = 5f;
    public float crouchSpeed = 2f;
    public float lookSpeed = 2f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    [Header("State Flags")]
    public bool isPaused = false;
    public bool isCrouching = false;
    private bool isJumpingHeld;
    private bool canDash = true;

    [Header("References")]
    public GameObject pauseScreen;
    public dashManager dashManager;
    public playerHealth playerHealth;
    public healManager healManager;
    public playerPosture playerPosture;

    private void Awake()
    {
        playerInput = new PlayerControls();
        _characterController = GetComponent<CharacterController>();
    }

    public void OnEnable()
    {
        playerInput.Player.Enable();

        // Movement
        playerInput.Player.Movement.performed += OnMovePerformed;
        playerInput.Player.Movement.canceled += OnMoveCanceled;

        // Look
        playerInput.Player.Look.performed += OnLookPerformed;
        playerInput.Player.Look.canceled += OnLookCanceled;

        // Jump
        playerInput.Player.Jump.started += OnJumpStarted;
        playerInput.Player.Jump.canceled += OnJumpCanceled;

        // Dash
        playerInput.Player.Dash.performed += ctx => Dash();

        // Pause
        playerInput.Player.Pause.performed += ctx => Pause();

        // Shooting
        playerInput.Player.ShootLeft.performed += ctx => ShootLeft();
        playerInput.Player.ShootRight.performed += ctx => ShootRight();
        playerInput.Player.SuperMove.performed += ctx => SuperMove();

        //heal
        playerInput.Player.Heal.performed += ctx => Heal();
    }

    public void OnDisable()
    {
        playerInput.Player.Disable();

        // Movement
        playerInput.Player.Movement.performed -= OnMovePerformed;
        playerInput.Player.Movement.canceled -= OnMoveCanceled;

        // Look
        playerInput.Player.Look.performed -= OnLookPerformed;
        playerInput.Player.Look.canceled -= OnLookCanceled;

        // Jump
        playerInput.Player.Jump.started -= OnJumpStarted;
        playerInput.Player.Jump.canceled -= OnJumpCanceled;

        // Dash
        playerInput.Player.Dash.performed -= ctx => Dash();

        // Pause
        playerInput.Player.Pause.performed -= ctx => Pause();

        // attacks
        playerInput.Player.ShootLeft.performed -= ctx => ShootLeft();
        playerInput.Player.ShootRight.performed -= ctx => ShootRight();
        playerInput.Player.SuperMove.performed -= ctx => SuperMove();

        //heal
        playerInput.Player.Heal.performed -= ctx => Heal();
    }

    public void Start()
    {
        moveSpeed = originalSpeed;
    }
    public void Update()
    {
        Move();
        Look();
        ApplyGravity();

        if (isJumpingHeld)
        {
            Jetpack();
        }
    }

    //callbacks

    public void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
    }
       

    public void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        _moveInput = Vector2.zero;
    }
        

    public void OnLookPerformed(InputAction.CallbackContext ctx)
    {
        _lookInput = ctx.ReadValue<Vector2>();
    }
        

    public void OnLookCanceled(InputAction.CallbackContext ctx)
    {
        _lookInput = Vector2.zero;
    }
        

    public void OnJumpStarted(InputAction.CallbackContext ctx)
    {
        isJumpingHeld = true;
        dashManager.shouldFillBar = false;

        if (_characterController.isGrounded && dashManager.currentBoost > 1 && isPaused == false)
        {
            // initial hop
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            dashManager.UseJump();

        }
    }

    public void OnJumpCanceled(InputAction.CallbackContext ctx) 
    {
        isJumpingHeld = false;
        dashManager.shouldFillBar = true;

    }

    

    

    //actions

    public void Move()
    {
        if (isPaused == true) 
        return;

        Vector3 move = new Vector3(-_moveInput.x, 0, -_moveInput.y);
        move = transform.TransformDirection(move);

        float currentSpeed = isCrouching ? crouchSpeed : moveSpeed;
        _characterController.Move(move * currentSpeed * Time.deltaTime);
    }

    public void Look()
    {
        if (isPaused == true) 
        return;

        float lookX = _lookInput.x * lookSpeed;
        transform.Rotate(0f, lookX, 0f);
    }

    public void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -0.5f; // keep grounded
        }

        _velocity.y += gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    public void Jetpack()
    {
        if (isPaused == true)     
        return;

        // Only thrust if we still have fuel
        if (dashManager.currentBoost > 0.5f)
        {
            // Apply upward thrust
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            dashManager.UseJetpack();
            
            dashManager.currentBoost = Mathf.Max(dashManager.currentBoost, 0f); // clamp at 0
            dashManager.shouldFillBar = false;
        }
        else
        {
            // No boost left = stop thrust immediately
            isJumpingHeld = false;
            dashManager.shouldFillBar = true;
        }
    }

    public void Dash()
    {
        if (dashManager.currentBoost > 3 && canDash == true)
        {
            canDash = false;
            moveSpeed = moveSpeed + 8f;
            dashManager.UseBoost();
            StartCoroutine(DashReset());
            Debug.Log("Dodge activated");
        }
    }

    public void Pause()
    {
        Debug.Log("pressed pause");

        if (isPaused == false)
        {
            pauseScreen.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }

        else if (isPaused == true)
        {
            pauseScreen.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }


    }

    public void ShootLeft() 
    { 
    
    }
    public void ShootRight() 
    { 
    
    }
    public void SuperMove() 
    { 
    
    }

    public void Heal()
    {
        Debug.Log("pressed Heal");

        if(healManager.heal >= 1 && playerHealth.currentHealth < playerHealth.maxHealth)
        {
            playerHealth.Heal();
            healManager.UseHeal();
        }
     
    }

    public void PlayerStaggered()
    {
        StartCoroutine(PostureFull());
    }
    

    //coroutines

    public IEnumerator DashReset()
    {
        yield return new WaitForSeconds(1f);
        moveSpeed = originalSpeed;
        dashManager.shouldFillBar = true;
        canDash = true;
    }

    public IEnumerator PostureFull()
    {
        yield return new WaitForSeconds(0f);
        moveSpeed = 0f;
        canDash = false;
        playerPosture.isStaggered = true;
        yield return new WaitForSeconds(3f);
        moveSpeed = originalSpeed;
        canDash = true;
        playerPosture.isStaggered = false;
        playerPosture.PostureHeal();
    }
 

    
}

