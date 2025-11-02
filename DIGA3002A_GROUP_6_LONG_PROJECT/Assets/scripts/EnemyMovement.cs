using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI; 


public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Transform firePosition;
    public GameObject projectile;
    public Image enemyHealthBarPic;
    public ParticleSystem explosion;
    public ParticleSystem muzzleEffect;

    public float fireRate = 8f;
    private float nextTimeToFire = 0f;
    
    public float maxEnemyHealth;
    public float currentEnemyHealth;
    public float sightRange, attackRange;
    public float projectileForce = 32f;

    public float fireCooldown = 1.5f;
    [SerializeField] private int burstCount = 3;
    [SerializeField] private float burstInterval = 0.1f;
    [SerializeField] private float burstCooldown = 2f;
    public float timeBetweenShots = 0.2f;
    public float aimSpread = 0.05f;

    private int shotsFired = 0;
    private bool isCoolingDown = false;

    public float walkPointRange;
    public float strafeSpeed = 3f;
    public float retreatThreshold = 0.3f;

    public Vector3 walkPoint;
    private bool walkPointSet;
    private float lastAttackTime = 0f;
    private bool strafeLeft; 
    private bool hasCalledBackup = false;

    public bool playerInSightRange, playerInAttackRange;
    public bool isDead = false;

    public static event System.Action<EnemyMovement> OnEnemyDeath;

    private enum EnemyState { Patrol, Chase, Attack, Retreat }
    private EnemyState currentState = EnemyState.Patrol;

    [SerializeField] private float minFireRate = 2f; // slowest shots per second
    [SerializeField] private float maxFireRate = 6f;
    private float currentFireRate;
    private float nextFireTime;


    private void Awake()
    {
        player= GameObject.Find("player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        UpdateEnemyHealthBar();
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint(); 
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        if (Vector3.Distance(transform.position, walkPoint) < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ); 

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }


    private void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
        Debug.Log("is working");
    }

    private void AttackPlayer()
    {
        agent.isStopped = true;

        Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPos);

        Strafe(); 

        float distance = Vector3.Distance(transform.position, player.position);
        currentFireRate = Mathf.Lerp(maxFireRate, minFireRate, distance / attackRange);

        if (!isCoolingDown && Time.time >= nextFireTime)
        {
            FireProjectile();
            shotsFired++;
            nextFireTime = Time.time + burstInterval;

            if (shotsFired >= burstCount)
            {
                isCoolingDown = true;
                shotsFired = 0;
                Invoke(nameof(ResetCooldown), burstCooldown);
            }
        }
    }

    private void ResetCooldown()
    {
        isCoolingDown = false;
    }

    private IEnumerator FireBurst()
    {
        for (int i = 0; i < burstCount; i++)
        {
            FireProjectile();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    private void FireProjectile()
    {
        if (projectile == null || firePosition == null || player == null) return;

        GameObject bulletObj = Instantiate(projectile, firePosition.position, Quaternion.identity);
        EnemyBullet eb = bulletObj.GetComponent<EnemyBullet>();

        Vector3 direction = (player.position - firePosition.position).normalized;

        float spread = 0.05f;
        direction += new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0);

        direction.Normalize();
        eb.direction = direction;  // <--- important

        if (muzzleEffect != null)
            muzzleEffect.Play();
    }



    private void Strafe()
    {
        Vector3 strafeDir = strafeLeft ? -transform.right : transform.right;
        agent.Move(strafeDir * strafeSpeed * Time.deltaTime);

        if (Random.value > 0.99f)
        {
            strafeLeft = !strafeLeft; 
        }
    }

    private void TakeCover()
    {
        Collider[] covers = Physics.OverlapSphere(transform.position, 15f, LayerMask.GetMask("Cover"));
        if (covers.Length == 0)
        {
            return;
        }

        Transform bestCover = covers[0].transform;
        float shortest = Vector3.Distance(transform.position, bestCover.position);

        foreach (Collider c in covers)
        {
            float dist = Vector3.Distance(transform.position, c.transform.position);

            if (dist < shortest)
            {
                shortest = dist;
                bestCover = c.transform;
            }
        }

        agent.isStopped = false;
        agent.SetDestination(bestCover.position); 
    }

    private bool CanSeePlayer()
    {
        Vector3 dirToPlayer = (player.position - transform.position).normalized;
        if (Physics.Raycast(transform.position + Vector3.up, dirToPlayer, out RaycastHit hit, sightRange))
            return hit.transform.CompareTag("Player");
        return false;
    }

    //public void TakeDamage(int damage)
    //{
    //    currentEnemyHealth -= damage;
    //    if (currentEnemyHealth <= 0)
    //    {
    //        Invoke(nameof(DestroyEnemy), 0.5f); 
    //    }
    //}

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead)
        {
            return;
        }

        playerInSightRange = CanSeePlayer(); 
        playerInAttackRange = Vector3.Distance(transform.position, player.position) <= attackRange;

        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrolling();
                if (playerInSightRange)
                {
                    currentState = EnemyState.Chase; 
                }
                break;

            case EnemyState.Chase:
                ChasePlayer();
                if (playerInAttackRange && playerInSightRange) currentState = EnemyState.Attack;
                else if (!playerInSightRange) currentState = EnemyState.Patrol;
                break;

            case EnemyState.Attack:
                AttackPlayer();
                if (!playerInAttackRange || !playerInSightRange) currentState = EnemyState.Chase;
                if (currentEnemyHealth <= maxEnemyHealth * retreatThreshold)
                    currentState = EnemyState.Retreat;
                break;

            case EnemyState.Retreat:
                TakeCover();
                if (currentEnemyHealth > maxEnemyHealth * retreatThreshold)
                    currentState = EnemyState.Chase;
                break; 
        }


        //if (!playerInSightRange && !playerInAttackRange)
        //{
        //    Patrolling();
        //}

        //else if (playerInSightRange && !playerInAttackRange)
        //{
        //    ChasePlayer();
        //}

        //else if (playerInSightRange && playerInAttackRange)
        //{
        //    AttackPlayer();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag("BasicBullet"))
        {
            ApplyDamage(5f);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("LaserBullet"))
        {
            ApplyDamage(10f);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("MachineBullet"))
        {
            ApplyDamage(2f);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("AssaultBullet"))
        {
            ApplyDamage(4f);
            Destroy(other.gameObject);
        }
    }


    private void ApplyDamage(float amount)
    {
        currentEnemyHealth = Mathf.Clamp(currentEnemyHealth - amount, 0, maxEnemyHealth);
        UpdateEnemyHealthBar();

        if (currentEnemyHealth <= 0)
            Die();
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        if (explosion != null)
        {
            ParticleSystem ps = Instantiate(explosion, transform.position, Quaternion.identity);
            ps.Play();
            Destroy(ps.gameObject, ps.main.duration);
        }

        OnEnemyDeath?.Invoke(this);
        Destroy(gameObject);
    }

    private void UpdateEnemyHealthBar()
    {
        if (enemyHealthBarPic != null)
            enemyHealthBarPic.fillAmount = currentEnemyHealth / maxEnemyHealth;
    }
}
