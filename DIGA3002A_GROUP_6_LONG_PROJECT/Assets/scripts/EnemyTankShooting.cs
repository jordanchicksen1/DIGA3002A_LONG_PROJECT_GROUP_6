using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyTankShooting : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform firePoint;
    public GameObject projectilePrefab;

    [Header("Phase Lights & Audio")]
    public Light warningLight;              
    public AudioSource phaseChangeSound;        
    public float flashDuration = 3f;        
    public float flashSpeed = 5f;          
    private bool phase2Triggered = false;
    private bool phase3Triggered = false;

    [Header("Phase 1")]
    public float phase1_FireInterval = 1.8f;
    public int phase1_BurstCount = 3;
    public float phase1_CooldownTime = 4.5f;

    [Header("Phase 2")]
    public float phase2_FireInterval = 1.2f;
    public int phase2_BurstCount = 4;
    public float phase2_CooldownTime = 4f;

    [Header("Phase 3")]
    public float phase3_FireInterval = 0.9f;
    public int phase3_BurstCount = 5;
    public float phase3_CooldownTime = 3.5f;

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

    private int currentPhase = 1;

    private void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        UpdateEnemyHealthBar();
    }

    private void Update()
    {
        if (isDead || player == null) return;

        CheckPhaseChange();

        HandleShooting();
    }

    private void CheckPhaseChange()
    {
        float healthPercent = currentEnemyHealth / maxEnemyHealth;

        if (healthPercent <= 0.65f && !phase2Triggered)
        {
            currentPhase = 2;
            phase2Triggered = true;
            StartCoroutine(PhaseTransitionEffect());
        }
        else if (healthPercent <= 0.35f && !phase3Triggered)
        {
            currentPhase = 3;
            phase3Triggered = true;
            StartCoroutine(PhaseTransitionEffect());
        }
    }

    private IEnumerator PhaseTransitionEffect()
    {
        if (phaseChangeSound != null)
            phaseChangeSound.Play();

        float elapsed = 0f;
        bool lightState = false;

        while (elapsed < flashDuration)
        {
            elapsed += Time.deltaTime * flashSpeed;
            if (warningLight != null)
            {
                lightState = !lightState;
                warningLight.enabled = lightState;
            }
            yield return new WaitForSeconds(0.1f);
        }

        if (warningLight != null)
            warningLight.enabled = false;
    }

    private void HandleShooting()
    {
        if (inCooldown) { HandleCooldown(); return; }

        fireTimer += Time.deltaTime;
        float fireInterval = phase1_FireInterval;
        int burstCount = phase1_BurstCount;
        float cooldownTime = phase1_CooldownTime;

        if (currentPhase == 2)
        {
            fireInterval = phase2_FireInterval;
            burstCount = phase2_BurstCount;
            cooldownTime = phase2_CooldownTime;
        }
        else if (currentPhase == 3)
        {
            fireInterval = phase3_FireInterval;
            burstCount = phase3_BurstCount;
            cooldownTime = phase3_CooldownTime;
        }

        if (fireTimer >= fireInterval)
        {
            Shoot();
            fireTimer = 0f;
            shotsFired++;

            if (shotsFired >= burstCount)
                StartCooldown(cooldownTime);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * 35f, ForceMode.Impulse);

        if (fireSound != null) fireSound.Play();
    }

    private void StartCooldown(float time)
    {
        inCooldown = true;
        cooldownTimer = 0f;
        StartCoroutine(CooldownTimer(time));
    }

    private IEnumerator CooldownTimer(float time)
    {
        yield return new WaitForSeconds(time);
        inCooldown = false;
        shotsFired = 0;
    }

    private void HandleCooldown() { /* optional effects */ }

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
        Destroy(gameObject, 2f);
    }
}
