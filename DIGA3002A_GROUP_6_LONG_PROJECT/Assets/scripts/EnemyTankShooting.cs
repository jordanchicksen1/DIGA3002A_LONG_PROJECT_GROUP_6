using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EnemyTankShooting : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform firePoint;
    public GameObject projectilePrefab;

    [Header("Shooting Settings")]
    public float fireInterval = 1.5f;
    public int burstCount = 3;
    public float cooldownTime = 5f;
    public float projectileForce = 30f;

    private int shotsFired = 0;
    private float fireTimer = 0f;
    private bool inCooldown = false;
    private float cooldownTimer = 0f;

    public float currentEnemyHealth;
    public float maxEnemyHealth;
    public Image enemyHealthBarPic;

    public ParticleSystem explosion;

    public bool isDead = false;

    public static event System.Action<EnemyTankShooting> OnEnemyDeath;

    private void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        UpdateEnemyHealthBar();
    }

    void Update()
    {
        if (player == null || inCooldown)
        {
            HandleCooldown();
            return;
        }

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            Shoot();
            fireTimer = 0f;
            shotsFired++;

            if (shotsFired >= burstCount)
            {
                StartCooldown();
            }
        }
    }

    

    private void UpdateEnemyHealthBar()
    {
        if (enemyHealthBarPic == null)
        {
            return;
        }
        float targetFillAmount = currentEnemyHealth / maxEnemyHealth;
        enemyHealthBarPic.fillAmount = targetFillAmount;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
    }

    private void StartCooldown()
    {
        inCooldown = true;
        cooldownTimer = 0f;
    }

    private void HandleCooldown()
    {
        cooldownTimer += Time.deltaTime;
        if(cooldownTimer >= cooldownTime)
        {
            inCooldown = false;
            shotsFired = 0; 
        }
    }
}
