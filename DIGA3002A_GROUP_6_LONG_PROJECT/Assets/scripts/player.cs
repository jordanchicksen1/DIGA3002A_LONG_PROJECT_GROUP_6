using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class player : MonoBehaviour
{
    [Header("MOVEMENT SETTINGS")]
    [Space(5)]

    // Public variables to set movement and look speed, and the player camera
    public float moveSpeed = 8f; // Speed at which the player moves
    public float lookSpeed; // Sensitivity of the camera movement
    public float gravity = -9.81f; // Gravity value
    public float jumpHeight = 1.0f; // Height of the jump
  


    // Private variables to store input values and the character controller
    private Vector2 _moveInput; // Stores the movement input from the player
    private Vector2 _lookInput;
    private Vector3 _velocity; // Velocity of the player
    private CharacterController _characterController; // Reference to the CharacterController component

    [Header("CROUCH SETTINGS")]
    [Space(5)]
    public float crouchHeight = 1f; //make short
    public float standingHeight = 2f; //make normal
    public float crouchSpeed = 1.5f; //short speed
    public bool isCrouching = false; //if short or normal

    public Rigidbody rb;

   

    //dash
    public bool canDash = true;
    public dashManager dashManager;
  

    //pause stuff
    public bool isPaused = false;
    public GameObject pauseScreen;

    //differentCanvases
    public GameObject playerCanvas;
    public GameObject shopCanvas;
    public GameObject mechBuildingCanvas;
   


    private void OnEnable()
    {

        // Create a new instance of the input actions
        var playerInput = new PlayerControls();

        // Enable the input actions
        playerInput.Player.Enable();

        // Subscribe to the movement input events
        playerInput.Player.Movement.performed += ctx => _moveInput = ctx.ReadValue<Vector2>(); // Update moveInput when movement input is performed
        playerInput.Player.Movement.canceled += ctx => _moveInput = Vector2.zero; // Reset moveInput when movement input is canceled

        // Subscribe to the look input events
        playerInput.Player.Look.performed += ctx => _lookInput = ctx.ReadValue<Vector2>(); // Update lookInput when look input is performed

        //playerInput.Player.LookAround.performed += ctx => currentScheme = ctx.control;
        playerInput.Player.Look.canceled += ctx => _lookInput = Vector2.zero; // Reset lookInput when look input is canceled

        // Subscribe to the jump input event
        playerInput.Player.Jump.performed += ctx => Jump(); // Call the Jump method when jump input is performed

        //Subscribe to the sprint
        playerInput.Player.Dash.performed += ctx => Dash(); // dash
      
        //Subscribe to the pause
        playerInput.Player.Pause.performed += ctx => Pause(); // pause

        //Subscribe to the shootLeft
        playerInput.Player.ShootLeft.performed += ctx => ShootLeft(); // shoot left hand

        //Subscribe to the shootRight
        playerInput.Player.ShootRight.performed += ctx => ShootRight(); // shoot left hand

        //Subscribe to the superMove
        playerInput.Player.SuperMove.performed += ctx => SuperMove(); // shoot left hand
    }

    private void Awake()
    {
        // Get and store the CharacterController component attached to this GameObject
        _characterController = GetComponent<CharacterController>();
        // playerAnim = GetComponent<Animator>();

    }

    public void Start()
    {
       
    }

    public void Update()
    {
        Move();
        Look();
        ApplyGravity();
    
    }

    public void Move()
    {

        if (isPaused == false)
        {
            // Create a movement vector based on the input
            Vector3 move = new Vector3(-_moveInput.x, 0, -_moveInput.y);

            // Transform direction from local to world space
            move = transform.TransformDirection(move);

            var currentSpeed = isCrouching ? crouchSpeed : moveSpeed;

            // Move the character controller based on the movement vector and speed
            _characterController.Move(move * currentSpeed * Time.deltaTime);
        }

    }



    public void Look()
    {
        if (isPaused == false)
        {
            // Only use horizontal input (left/right)
            float lookX = _lookInput.x * lookSpeed;

            // Rotate the player left/right around the Y-axis
            transform.Rotate(0f, lookX, 0f);
        }

    }



    public void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -0.5f; // Small value to keep the player grounded
        }

        _velocity.y += gravity * Time.deltaTime; // Apply gravity to the velocity
        _characterController.Move(_velocity * Time.deltaTime); // Apply the velocity to the character
    }

    public void Jump()
    {
        if (_characterController.isGrounded && isPaused == false)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

    }

    public void Dash()
    {
        if (canDash == true)
        {
            canDash = false;
            moveSpeed = moveSpeed + 8f;
            dashManager.UseBoost();
            StartCoroutine(DashReset());
            Debug.Log("should dodge");
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

    private IEnumerator DashReset()
    {
        yield return new WaitForSeconds(0.5f);
        moveSpeed = moveSpeed - 8f; 
        dashManager.shouldFillBar = true;
        yield return new WaitForSeconds(3f);
        canDash = true;
    }
}
