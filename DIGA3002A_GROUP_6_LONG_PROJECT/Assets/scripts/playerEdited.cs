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
    public float crouchSpeed = 2f;
    public float lookSpeed = 2f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    [Header("State Flags")]
    public bool isPaused = false;
    public bool isCrouching = false;
    private bool isJumpingHeld;

    [Header("References")]
    public GameObject pauseScreen;
    public dashManager dashManager;

    private void Awake()
    {
        playerInput = new PlayerControls();
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
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
    }

    private void OnDisable()
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

        // Shooting
        playerInput.Player.ShootLeft.performed -= ctx => ShootLeft();
        playerInput.Player.ShootRight.performed -= ctx => ShootRight();
        playerInput.Player.SuperMove.performed -= ctx => SuperMove();
    }

    private void Update()
    {
        Move();
        Look();
        ApplyGravity();

        if (isJumpingHeld)
        {
            Jetpack();
        }
    }

    #region Input Callbacks

    private void OnMovePerformed(InputAction.CallbackContext ctx) =>
        _moveInput = ctx.ReadValue<Vector2>();

    private void OnMoveCanceled(InputAction.CallbackContext ctx) =>
        _moveInput = Vector2.zero;

    private void OnLookPerformed(InputAction.CallbackContext ctx) =>
        _lookInput = ctx.ReadValue<Vector2>();

    private void OnLookCanceled(InputAction.CallbackContext ctx) =>
        _lookInput = Vector2.zero;

    private void OnJumpStarted(InputAction.CallbackContext ctx)
    {
        isJumpingHeld = true;

        if (_characterController.isGrounded && dashManager.currentBoost > 1 && isPaused == false)
        {
            // initial hop
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            dashManager.UseJump();
            StartCoroutine(JumpReset());
        }
    }

    private void OnJumpCanceled(InputAction.CallbackContext ctx) =>
        isJumpingHeld = false;

    #endregion

    #region Actions

    private void Move()
    {
        if (isPaused == true) 
        return;

        Vector3 move = new Vector3(-_moveInput.x, 0, -_moveInput.y);
        move = transform.TransformDirection(move);

        float currentSpeed = isCrouching ? crouchSpeed : moveSpeed;
        _characterController.Move(move * currentSpeed * Time.deltaTime);
    }

    private void Look()
    {
        if (isPaused == true) 
        return;

        float lookX = _lookInput.x * lookSpeed;
        transform.Rotate(0f, lookX, 0f);
    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -0.5f; // keep grounded
        }

        _velocity.y += gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void Jetpack()
    {
        if (isPaused == true)     
        return;

        // Only thrust if we still have fuel
        if (dashManager.currentBoost > 0.5f)
        {
            // Apply upward thrust
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            // Drain fuel gradually
            dashManager.currentBoost -= 10f * Time.deltaTime;
            dashManager.currentBoost = Mathf.Max(dashManager.currentBoost, 0f); // clamp at 0
        }
        else
        {
            // No boost left = stop thrust immediately
            isJumpingHeld = false;
        }
    }

    private void Dash()
    {
        if (dashManager.currentBoost > 3)
        {
            moveSpeed = moveSpeed + 8f;
            dashManager.UseBoost();
            StartCoroutine(DashReset());
            Debug.Log("Dodge activated");
        }
    }

    private void Pause()
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

    private void ShootLeft() 
    { 
    
    }
    private void ShootRight() 
    { 
    
    }
    private void SuperMove() 
    { 
    
    }

    #endregion

    #region Coroutines

    private IEnumerator DashReset()
    {
        yield return new WaitForSeconds(1f);
        moveSpeed = moveSpeed - 8f;
        dashManager.shouldFillBar = true;
    }

    private IEnumerator JumpReset()
    {
        yield return new WaitForSeconds(1f);
        dashManager.shouldFillBar = true;
    }

    #endregion
}

