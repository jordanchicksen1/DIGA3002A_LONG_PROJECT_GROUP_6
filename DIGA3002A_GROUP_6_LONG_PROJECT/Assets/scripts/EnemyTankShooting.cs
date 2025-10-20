using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyTankShooting : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform firePoint;
    public GameObject projectilePrefab;

    [Header("Shooting Settings")]
    [Tooltip("Time between individual shots within a burst.")]
    public float fireInterval = 1.2f;

    [Tooltip("Number of shots in a burst.")]
    public int burstCount = 3;

    [Tooltip("Cooldown time after a full burst.")]
    public float cooldownTime = 4f;

    [Tooltip("Force applied to projectiles when fired.")]
    public float projectileForce = 35f;

    [Tooltip("Random offset to make shots less predictable.")]
    public float aimJitter = 0.5f;

    [Header("Dynamic Fire Control")]
    [Tooltip("Decrease fire interval as health drops (increases aggression).")]
    public bool adaptiveFireRate = true;
    public float minFireInterval = 0.5f;

    [Header("Health Settings")]
    public float maxEnemyHealth = 100f;
    private float currentEnemyHealth;
    public Image enemyHealthBarPic;

    [Header("Effects")]
    public ParticleSystem explosion;
    public AudioSource fireSound;
    public AudioSource deathSound;

    private int shotsFired = 0;
    private float fireTimer = 0f;
    private bool inCooldown = false;
    private float cooldownTimer = 0f;
    private bool isDead = false;

    public static event System.Action<EnemyTankShooting> OnEnemyDeath;

    private void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        UpdateEnemyHealthBar();
    }

    private void Update()
    {
        if (isDead || player == null) return;

        Vector3 lookDir = (player.position - transform.position).normalized;
        lookDir.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookDir), Time.deltaTime * 3f);

        if (inCooldown)
        {
            HandleCooldown();
            return;
        }

        fireTimer += Time.deltaTime;
        float adjustedFireInterval = GetAdjustedFireInterval();

        if (fireTimer >= adjustedFireInterval)
        {
            Shoot();
            fireTimer = 0f;
            shotsFired++;

            if (shotsFired >= burstCount)
                StartCooldown();
        }
    }

    private void Shoot()
    { 
        Vector3 jitter = new Vector3(Random.Range(-aimJitter, aimJitter), Random.Range(-aimJitter, aimJitter), 0);
        Quaternion shootRotation = firePoint.rotation * Quaternion.Euler(jitter);

        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, shootRotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);

        if (fireSound != null) fireSound.Play();
    }

    private void StartCooldown()
    {
        inCooldown = true;
        cooldownTimer = 0f;
    }

    private void HandleCooldown()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= cooldownTime)
        {
            inCooldown = false;
            shotsFired = 0;
        }
    }

    private float GetAdjustedFireInterval()
    {
        if (!adaptiveFireRate) return fireInterval;

        float healthRatio = currentEnemyHealth / maxEnemyHealth;
        return Mathf.Lerp(minFireInterval, fireInterval, healthRatio);
    }

    private void UpdateEnemyHealthBar()
    {
        if (enemyHealthBarPic == null) return;
        enemyHealthBarPic.fillAmount = currentEnemyHealth / maxEnemyHealth;
    }

    public void ApplyDamage(float damage)
    {
        if (isDead) return;

        currentEnemyHealth -= damage;
        currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
        UpdateEnemyHealthBar();

        if (currentEnemyHealth <= 0)
            Die();
    }

    private void Die()
    {
        isDead = true;
        if (explosion != null) explosion.Play();
        if (deathSound != null) deathSound.Play();

        OnEnemyDeath?.Invoke(this);
        Destroy(gameObject, 2f); 
    }
}
