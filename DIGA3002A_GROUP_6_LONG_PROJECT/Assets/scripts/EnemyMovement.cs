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

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    public float currentEnemyHealth;
    public float maxEnemyHealth;
    public Image enemyHealthBarPic; 

    public Transform firePosition;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    
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

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, firePosition.position, Quaternion.identity).GetComponent<Rigidbody>();

            Vector3 direction = (player.position - firePosition.position).normalized;

            rb.AddForce(direction * 32f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false; 
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
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


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
            currentEnemyHealth--;
            currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);

            UpdateEnemyHealthBar();

            if (currentEnemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void UpdateEnemyHealthBar()
    {
        float targetFillAmount = currentEnemyHealth / maxEnemyHealth;
        enemyHealthBarPic.fillAmount = targetFillAmount;
    }
}
