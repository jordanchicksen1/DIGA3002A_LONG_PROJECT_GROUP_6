using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class TacticalDroneAI : MonoBehaviour
{
    public enum FireMode { Alternate, Twin, Staggered }

    [Header("References")]
    public Transform player;
    public Transform firePointA;
    public Transform firePointB;
    public GameObject projectilePrefab;

    [Header("Waypoints")]
    public Transform[] waypoints;
    public float moveSpeed = 5f;
    public float waypointThreshold = 1f;
    public float hoverAmplitude = 0.5f;
    public float hoverSpeed = 2f;
    private int currentWaypoint = 0;

    [Header("Combat Settings")]
    public float engageRange = 25f;
    public FireMode fireMode = FireMode.Alternate;
    public float projectileForce = 35f;
    public float fireRate = 1.5f;
    public float staggerDelay = 0.15f;
    public int burstCount = 3;
    public float burstInterval = 0.15f;
    public float burstCooldown = 3.5f;

    [Header("Effects")]
    public ParticleSystem muzzleA;
    public ParticleSystem muzzleB;
    public AudioSource fireSound;
    public Light flashLightA;
    public Light flashLightB;
    public float flashDuration = 0.05f;

    [Header("Health")]
    public float maxEnemyHealth;
    public float currentEnemyHealth;
    public Image enemyHealthBarPic;

    [Header("Rotation Settings")]
    public float rotationSpeed = 5f; // How quickly the drone tracks the player

    private float fireTimer = 0f;
    private int shotsInBurst = 0;
    private bool inCooldown = false;
    private bool nextIsA = true; // For alternate mode
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    
        currentEnemyHealth = maxEnemyHealth;
        UpdateEnemyHealthBar();
    }


    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= engageRange)
        {
            // Engage player
            RotateTowardPlayer();
            if (!inCooldown)
            {
                fireTimer += Time.deltaTime;
                if (fireTimer >= fireRate)
                {
                    fireTimer = 0f;
                    StartCoroutine(DoBurst());
                }
            }
        }
        else
        {
            // Patrol between waypoints
            Patrol();
        }

        // Hover motion for realism
        HoverEffect();
    }

    private void Patrol()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypoint];
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < waypointThreshold)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

    private void HoverEffect()
    {
        Vector3 pos = transform.position;
        pos.y = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverAmplitude;
        transform.position = pos;
    }

    private void RotateTowardPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator DoBurst()
    {
        for (int i = 0; i < burstCount; i++)
        {
            if (fireMode == FireMode.Alternate)
            {
                if (nextIsA) FireFrom(firePointA, muzzleA, flashLightA);
                else FireFrom(firePointB, muzzleB, flashLightB);
                nextIsA = !nextIsA;
            }
            else if (fireMode == FireMode.Twin)
            {
                FireFrom(firePointA, muzzleA, flashLightA);
                FireFrom(firePointB, muzzleB, flashLightB);
            }
            else if (fireMode == FireMode.Staggered)
            {
                FireFrom(firePointA, muzzleA, flashLightA);
                yield return new WaitForSeconds(staggerDelay);
                FireFrom(firePointB, muzzleB, flashLightB);
            }

            if (fireSound != null) fireSound.Play();
            yield return new WaitForSeconds(burstInterval);
        }

        shotsInBurst++;
        if (shotsInBurst >= burstCount)
        {
            shotsInBurst = 0;
            inCooldown = true;
            StartCoroutine(CooldownRoutine());
        }
    }

    private void FireFrom(Transform firePoint, ParticleSystem muzzle, Light flashLight)
    {
        if (firePoint == null || projectilePrefab == null) return;

        Vector3 dir = (player.position - firePoint.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);

        GameObject proj = Instantiate(projectilePrefab, firePoint.position, rot);
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(dir * projectileForce, ForceMode.Impulse);

        if (muzzle != null) muzzle.Play();
        if (flashLight != null) StartCoroutine(FlashLight(flashLight));

        Destroy(proj, 8f);
    }

    private IEnumerator FlashLight(Light light)
    {
        light.enabled = true;
        yield return new WaitForSeconds(flashDuration);
        light.enabled = false;
    }

    private IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(burstCooldown);
        inCooldown = false;
        fireTimer = 0f;
    }

    private void UpdateEnemyHealthBar()
    {
        if (enemyHealthBarPic != null)
            enemyHealthBarPic.fillAmount = currentEnemyHealth / maxEnemyHealth;
    }
}
