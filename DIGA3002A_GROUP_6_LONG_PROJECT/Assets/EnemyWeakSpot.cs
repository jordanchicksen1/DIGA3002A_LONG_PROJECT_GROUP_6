using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EnemyWeakSpot : MonoBehaviour
{
    public float currentEnemyHealth;
    public float maxEnemyHealth;
    public Image enemyHealthBarPic;

    public ParticleSystem explosion;

    public GameObject tankEnemy;
    public superMoveBar superMoveBar;


    public static event System.Action<EnemyWeakSpot> OnEnemyDeath;

    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        UpdateEnemyHealthBar();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BasicBullet")) TakeDamage(5f);
        else if (other.CompareTag("LaserBullet")) TakeDamage(10f);
        else if (other.CompareTag("MachineBullet")) TakeDamage(2f);
        else if (other.CompareTag("AssaultBullet")) TakeDamage(4f);
    }

    private void TakeDamage(float amount)
    {
        currentEnemyHealth -= amount;
        currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
        UpdateEnemyHealthBar();
        superMoveBar.AssaultHit();
        if (currentEnemyHealth <= 0)
        {
            Die();  // now Die() is called exactly once
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("EnemyTankShooting Die() called!");

        if (explosion != null)
        {
            ParticleSystem ps = Instantiate(explosion, transform.position, Quaternion.identity);
            ps.Play();
            Destroy(ps.gameObject, ps.main.duration);
        }

        OnEnemyDeath?.Invoke(this);
        Destroy(tankEnemy);
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
