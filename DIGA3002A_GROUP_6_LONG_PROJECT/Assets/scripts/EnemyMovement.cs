using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI; 
using UnityEngine.PlayerLoop;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float fireRate = 8f;
    private float nextTimeToFire = 0f;
    public GameObject projectile;
    public float projectileForce = 32f;

    public float currentEnemyHealth;
    public float maxEnemyHealth;
    public Image enemyHealthBarPic; 

    public Transform firePosition;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public ParticleSystem explosion;
    public ParticleSystem muzzleEffect;

    public static event System.Action<EnemyMovement> OnEnemyDeath;

    public bool isDead = false;

    public superMoveBar superMoveBar;
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

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
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
        agent.SetDestination(player.position);
        Debug.Log("is working");
    }

    private void AttackPlayer()
    {
        agent.SetDestination(player.position);

        Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPos);

        if (Time.time >= nextTimeToFire)
        {
            FireProjectile();
            nextTimeToFire = Time.time + (1f / fireRate);
        }
    }

    private void FireProjectile()
    {
        if (projectile == null || firePosition == null || player == null)
        {
            return;
        }

        if (muzzleEffect != null)
        {
            muzzleEffect.Play(); 
        }

        Rigidbody rb = Instantiate(projectile, firePosition.position, Quaternion.identity).GetComponent<Rigidbody>();
        Vector3 direction = (player.position - firePosition.position).normalized; 

        rb.AddForce(direction * projectileForce, ForceMode.Impulse);

        rb.transform.forward = direction; 
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
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


        float distance = Vector3.Distance(transform.position, player.transform.position);
        walkPointRange = distance;
        if (walkPointRange <= 10)
        {
            ChasePlayer();
            AttackPlayer();
            Debug.Log(distance);

        }
        else if (distance > 10)
        {
            Patrolling();

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
        if (other.CompareTag("BasicBullet"))
        {
            currentEnemyHealth = currentEnemyHealth - 5f;
            currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
            superMoveBar.BasicHit();
            UpdateEnemyHealthBar();

            if (currentEnemyHealth <= 0)
            {
                if (isDead) return;  // prevent multiple deaths
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
        }

        else if (other.CompareTag("LaserBullet"))
        {
            currentEnemyHealth = currentEnemyHealth - 10f;
            currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
            superMoveBar.LaserHit();
            UpdateEnemyHealthBar();

            if (currentEnemyHealth <= 0)
            {
                if (isDead) return;  // prevent multiple deaths
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
        }

        else if (other.CompareTag("MachineBullet"))
        {
            currentEnemyHealth = currentEnemyHealth - 2f;
            currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
            superMoveBar.MachineHit();
            UpdateEnemyHealthBar();

            if (currentEnemyHealth <= 0)
            {
                if (isDead) return;  // prevent multiple deaths
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
        }

        else if (other.CompareTag("AssaultBullet"))
        {
            currentEnemyHealth = currentEnemyHealth - 4f;
            currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
            superMoveBar.AssaultHit();
            UpdateEnemyHealthBar();

            if (currentEnemyHealth <= 0)
            {
                if (isDead) return;  // prevent multiple deaths
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
}
