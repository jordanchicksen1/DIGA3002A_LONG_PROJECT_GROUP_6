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
    private bool hasHit = false;

    [Header("Music Manager")]
    public MusicManager MusicManager;

    [Header("References")]
    public GameObject pauseScreen;
    public dashManager dashManager;
    public playerHealth playerHealth;
    public healManager healManager;
    public playerPosture playerPosture;
    public GameObject staggeredText;
    public leftAmmoManager leftAmmoManager;
    public rightAmmoManager rightAmmoManager;

    [Header("Basic Gun Info")]
    public GameObject basicBulletPrefab;
    public float basicBulletSpeed;
    public Transform basicLeftFirePoint;
    public float basicFireRate = 0.2f;
    public bool isShootingLeftHeld = false;
    public Coroutine basicLeftCoroutine;
    public bool leftBasicEquipped = true;
    public Transform basicRightFirePoint;
    public bool isShootingRightHeld = false;
    public Coroutine basicRightCoroutine;
    public bool rightBasicEquipped = true;
    

    [Header("Machine Gun Info")]
    public GameObject machineBulletPrefab;
    public float machineBulletSpeed;
    public Transform machineLeftFirePoint;
    public float machineFireRate = 0.1f;
    public Coroutine machineLeftCoroutine;
    public bool leftMachineEquipped = false;
    public Transform machineRightFirePoint;
    public Coroutine machineRightCoroutine;
    public bool rightMachineEquipped = false;

    [Header("Assault Gun Info")]
    public GameObject assaultBulletPrefab;
    public float assaultBulletSpeed;
    public Transform assaultLeftFirePoint;
    public float assaultFireRate = 0.15f;
    public Coroutine assaultLeftCoroutine;
    public bool leftAssaultEquipped = false;
    public Transform assaultRightFirePoint;
    public Coroutine assaultRightCoroutine;
    public bool rightAssaultEquipped = false;

    [Header("Laser Gun Info")]
    public GameObject laserBulletPrefab;
    public float laserBulletSpeed;
    public Transform laserLeftFirePoint;
    public float laserFireRate = 0.8f;
    public Coroutine laserLeftCoroutine;
    public bool leftLaserEquipped = false;
    public Transform laserRightFirePoint;
    public Coroutine laserRightCoroutine;
    public bool rightLaserEquipped = false;

    [Header("Super Move Stuff")]
    public bool basicSuperEquipped = true;
    public bool shieldSuperEquipped = false;
    public bool laserSuperEquipped = false;
    public superMoveBar superMoveBar;
    public GameObject basicSuper;
    public basicShieldHealth basicShieldHealth;



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
        playerInput.Player.ShootLeft.started += OnLeftShootStarted;
        playerInput.Player.ShootLeft.canceled += OnLeftShootCanceled;

        playerInput.Player.ShootRight.started += OnRightShootStarted;
        playerInput.Player.ShootRight.canceled += OnRightShootCanceled;
        
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
        playerInput.Player.ShootLeft.started -= OnLeftShootStarted;
        playerInput.Player.ShootLeft.canceled -= OnLeftShootCanceled;
        
        playerInput.Player.ShootRight.started -= OnRightShootStarted;
        playerInput.Player.ShootRight.canceled -= OnRightShootCanceled;
       
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

        if (_characterController.isGrounded && dashManager.currentBoost > 1 && isPaused == false && playerPosture.isStaggered == false)
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

    public void OnLeftShootStarted(InputAction.CallbackContext ctx)
    {
        if (isPaused == false) 
        {
            isShootingLeftHeld = true;

            if (leftBasicEquipped == true && leftAmmoManager.currentAmmo >= 5f)
            {
                ShootBasicLeft();
                basicLeftCoroutine = StartCoroutine(AutoFireLeftBasic());
            }

            if (leftMachineEquipped == true && leftAmmoManager.currentAmmo >= 2f)
            {
                ShootMachineLeft();
                machineLeftCoroutine = StartCoroutine(AutoFireLeftMachine());
            }

            if (leftAssaultEquipped == true && leftAmmoManager.currentAmmo >= 4f)
            {
                ShootAssaultLeft();
                assaultLeftCoroutine = StartCoroutine(AutoFireLeftAssault());
            }

            if (leftLaserEquipped == true && leftAmmoManager.currentAmmo >= 10f)
            {
                ShootLaserLeft();
                laserLeftCoroutine = StartCoroutine(AutoFireLeftLaser());
            }
        }  
    }

    public void OnLeftShootCanceled(InputAction.CallbackContext ctx)
    {
        isShootingLeftHeld = false;
        
        if (leftBasicEquipped == true) 
        {
            if (basicLeftCoroutine != null) 
            { 
            StopCoroutine(basicLeftCoroutine);
            }

        }

        if (leftMachineEquipped == true)
        {
            if (machineLeftCoroutine != null)
            {
                StopCoroutine(machineLeftCoroutine);
            }

        }

        if (leftAssaultEquipped == true)
        {
            if (assaultLeftCoroutine != null)
            {
                StopCoroutine(assaultLeftCoroutine);
            }

        }

        if (leftLaserEquipped == true)
        {
            if (laserLeftCoroutine != null)
            {
                StopCoroutine(laserLeftCoroutine);
            }

        }

    }

    public void OnRightShootStarted(InputAction.CallbackContext ctx)
    {
        if (isPaused == false)
        {
            isShootingRightHeld = true;

            if (rightBasicEquipped == true && rightAmmoManager.currentAmmo >= 5f)
            {
                ShootBasicRight();
                basicRightCoroutine = StartCoroutine(AutoFireRightBasic());
            }

            if (rightMachineEquipped == true && rightAmmoManager.currentAmmo >= 2f)
            {
                ShootMachineRight();
                machineRightCoroutine = StartCoroutine(AutoFireRightMachine());
            }

            if (rightAssaultEquipped == true && rightAmmoManager.currentAmmo >= 4f)
            {
                ShootAssaultRight();
                assaultRightCoroutine = StartCoroutine(AutoFireRightAssault());
            }

            if (rightLaserEquipped == true && rightAmmoManager.currentAmmo >= 10f)
            {
                ShootLaserRight();
                laserRightCoroutine = StartCoroutine(AutoFireRightLaser());
            }

        }
    }

    public void OnRightShootCanceled(InputAction.CallbackContext ctx)
    {
        isShootingRightHeld = false;

        if (rightBasicEquipped == true)
        {
            if (basicRightCoroutine != null)
            {
                StopCoroutine(basicRightCoroutine);
            }

        }

        if (rightMachineEquipped == true)
        {
            if (machineRightCoroutine != null)
            {
                StopCoroutine(machineRightCoroutine);
            }

        }

        if (rightAssaultEquipped == true)
        {
            if (assaultRightCoroutine != null)
            {
                StopCoroutine(assaultRightCoroutine);
            }

        }

        if (rightLaserEquipped == true)
        {
            if (laserRightCoroutine != null)
            {
                StopCoroutine(laserRightCoroutine);
            }

        }
    }



    //actions

    public void Move()
    {
        if (isPaused == false && playerPosture.isStaggered == false)
        {
            Vector3 move = new Vector3(-_moveInput.x, 0, -_moveInput.y);
            move = transform.TransformDirection(move);

            float currentSpeed = isCrouching ? crouchSpeed : moveSpeed;
            _characterController.Move(move * currentSpeed * Time.deltaTime);
        }
       
       
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
        if (isPaused == false && playerPosture.isStaggered == false)
        {
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

    public void ShootBasicLeft() 
    {
        if (basicBulletPrefab == null || basicLeftFirePoint == null) return;

        var projectile = Instantiate(basicBulletPrefab, basicLeftFirePoint.position, basicLeftFirePoint.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = basicLeftFirePoint.forward * basicBulletSpeed;
        Destroy(projectile, 1f);
        leftAmmoManager.BasicShot();

        Debug.Log("basic shot left");
    }
    public void ShootBasicRight() 
    {
        if (basicBulletPrefab == null || basicRightFirePoint == null) return;

        var projectile = Instantiate(basicBulletPrefab, basicRightFirePoint.position, basicRightFirePoint.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = basicRightFirePoint.forward * basicBulletSpeed;
        Destroy(projectile, 1f);
        rightAmmoManager.BasicShot();

        Debug.Log("basic shot right");
    }

    public void ShootMachineLeft()
    {
        if (machineBulletPrefab == null || machineLeftFirePoint == null) return;

        var projectile = Instantiate(machineBulletPrefab, machineLeftFirePoint.position, machineLeftFirePoint.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = machineLeftFirePoint.forward * machineBulletSpeed;
        Destroy(projectile, 0.8f);
        leftAmmoManager.MachineShot();

        Debug.Log("machine shot left");
    }

    public void ShootMachineRight()
    {
        if (machineBulletPrefab == null || machineRightFirePoint == null) return;

        var projectile = Instantiate(machineBulletPrefab, machineRightFirePoint.position, machineRightFirePoint.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = machineRightFirePoint.forward * machineBulletSpeed;
        Destroy(projectile, 0.8f);
        rightAmmoManager.MachineShot();

        Debug.Log("machine shot right");
    }

    public void ShootAssaultLeft()
    {
        if (assaultBulletPrefab == null || assaultLeftFirePoint == null) return;

        var projectile = Instantiate(assaultBulletPrefab, assaultLeftFirePoint.position, assaultLeftFirePoint.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = assaultLeftFirePoint.forward * assaultBulletSpeed;
        Destroy(projectile, 1f);
        leftAmmoManager.AssaultShot();

        Debug.Log("assault shot left");
    }

    public void ShootAssaultRight()
    {
        if (assaultBulletPrefab == null || assaultRightFirePoint == null) return;

        var projectile = Instantiate(assaultBulletPrefab, assaultRightFirePoint.position, assaultRightFirePoint.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = assaultRightFirePoint.forward * assaultBulletSpeed;
        Destroy(projectile, 1f);
        rightAmmoManager.AssaultShot();

        Debug.Log("assault shot right");
    }

    public void ShootLaserLeft()
    {
        if (laserBulletPrefab == null || laserLeftFirePoint == null) return;

        MusicManager.SFX.PlayOneShot(MusicManager.Laser);
        var projectile = Instantiate(laserBulletPrefab, laserLeftFirePoint.position, laserLeftFirePoint.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = laserLeftFirePoint.forward * laserBulletSpeed;
        Destroy(projectile, 1.5f);
        leftAmmoManager.LaserShot();

        Debug.Log("laser shot left");
    }

    public void ShootLaserRight()
    {
        if (laserBulletPrefab == null || laserRightFirePoint == null) return;

        MusicManager.SFX.PlayOneShot(MusicManager.Laser);
        var projectile = Instantiate(laserBulletPrefab, laserRightFirePoint.position, laserRightFirePoint.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = laserRightFirePoint.forward * laserBulletSpeed;
        Destroy(projectile, 1.5f);
        rightAmmoManager.LaserShot();

        Debug.Log("assault shot right");
    }
    public void SuperMove() 
    { 
    
        if(basicSuperEquipped == true && superMoveBar.currentSuperBar >= 100f)
        {
            superMoveBar.UseSuperBar();
            basicSuper.SetActive(true);
            Debug.Log("used basic super");
            basicShieldHealth.currentShieldHealth = basicShieldHealth.maxShieldHealth;
            basicShieldHealth.updateShieldHealthBar();
        }

        if (shieldSuperEquipped == true && superMoveBar.currentSuperBar >= 100f)
        {
            superMoveBar.UseSuperBar();
            Debug.Log("used shield super");
        }

        if (laserSuperEquipped == true && superMoveBar.currentSuperBar >= 100f)
        {
            superMoveBar.UseSuperBar();
            Debug.Log("used laser super");
        }
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

    public void OnTriggerEnter(Collider other)
    {

        if(other.tag == "EnemyBulletSmall" && hasHit == false)
        {
            hasHit = true;
            Destroy(other.gameObject);
            playerHealth.PlayerHit();
            Debug.Log("small hit");
            StartCoroutine(BulletHit());
        }

        if(other.tag == "EnemyBulletMedium" && hasHit == false)
        {
           hasHit = true;
            Destroy(other.gameObject);
            playerHealth.PlayerHitALot();
            Debug.Log("medium hit");
            StartCoroutine(BulletHit());
        }

        if(other.tag == "EnemyBulletLarge" && hasHit == false)
        {
            hasHit = true;
            Destroy(other.gameObject);
            playerHealth.PlayerHitATon();
            Debug.Log("big hit");
            StartCoroutine(BulletHit());
        }
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
        
        canDash = false;
        playerPosture.isStaggered = true;
        staggeredText.SetActive(true);
        yield return new WaitForSeconds(3f);
        
        canDash = true;
        playerPosture.isStaggered = false;
        playerPosture.PostureHeal();
        staggeredText.SetActive(false);

    }
 
    public IEnumerator BulletHit()
    {
        yield return new WaitForSeconds(0.1f);
        hasHit = false;
    }

    //basic left auto fire
    public IEnumerator AutoFireLeftBasic()
    {
        while (isShootingLeftHeld == true)
        {
           yield return new WaitForSeconds(basicFireRate);
          
            if(leftAmmoManager.currentAmmo <= 0)
            {
                isShootingLeftHeld = false;
                yield break;
            }
            
            ShootBasicLeft();
        }
    }

    public IEnumerator AutoFireRightBasic()
    {
        while (isShootingRightHeld == true)
        {
            yield return new WaitForSeconds(basicFireRate);

            if (rightAmmoManager.currentAmmo <= 0)
            {
                isShootingRightHeld = false;
                yield break;
            }

            ShootBasicRight();
        }
    }

    public IEnumerator AutoFireLeftMachine()
    {
        while (isShootingLeftHeld == true)
        {
            yield return new WaitForSeconds(machineFireRate);

            if (leftAmmoManager.currentAmmo <= 0)
            {
                isShootingLeftHeld = false;
                yield break;
            }

            ShootMachineLeft();
        }
    }

    public IEnumerator AutoFireRightMachine()
    {
        while (isShootingRightHeld == true)
        {
            yield return new WaitForSeconds(machineFireRate);

            if (rightAmmoManager.currentAmmo <= 0)
            {
                isShootingRightHeld = false;
                yield break;
            }

            ShootMachineRight();
        }
    }

    public IEnumerator AutoFireLeftAssault()
    {
        while (isShootingLeftHeld == true)
        {
            yield return new WaitForSeconds(assaultFireRate);

            if (leftAmmoManager.currentAmmo <= 0)
            {
                isShootingLeftHeld = false;
                yield break;
            }

            ShootAssaultLeft();
        }
    }

    public IEnumerator AutoFireRightAssault()
    {
        while (isShootingRightHeld == true)
        {
            yield return new WaitForSeconds(assaultFireRate);

            if (rightAmmoManager.currentAmmo <= 0)
            {
                isShootingRightHeld = false;
                yield break;
            }

            ShootAssaultRight();
        }
    }

    public IEnumerator AutoFireLeftLaser()
    {
        while (isShootingLeftHeld == true)
        {
            yield return new WaitForSeconds(laserFireRate);

            if (leftAmmoManager.currentAmmo <= 0)
            {
                isShootingLeftHeld = false;
                yield break;
            }

            ShootLaserLeft();
        }
    }

    public IEnumerator AutoFireRightLaser()
    {
        while (isShootingRightHeld == true)
        {
            yield return new WaitForSeconds(laserFireRate);

            if (rightAmmoManager.currentAmmo <= 0)
            {
                isShootingRightHeld = false;
                yield break;
            }

            ShootLaserRight();
        }
    }
}

