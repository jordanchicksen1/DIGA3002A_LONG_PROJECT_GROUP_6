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
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        UpdateEnemyHealthBar();
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
                if (explosion != null)
                {
                    ParticleSystem ps = Instantiate(explosion, transform.position, Quaternion.identity);
                    ps.Play();
                    Destroy(ps.gameObject, ps.main.duration);
                }

                Destroy(tankEnemy);
            }
        }

        else if (other.CompareTag("LaserBullet"))
        {
            currentEnemyHealth--;
            currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);

            UpdateEnemyHealthBar();

            if (currentEnemyHealth <= 0)
            {
                if (explosion != null)
                {
                    ParticleSystem ps = Instantiate(explosion, transform.position, Quaternion.identity);
                    ps.Play();
                    Destroy(ps.gameObject, ps.main.duration);
                }

                Destroy(tankEnemy);
            }
        }

        else if (other.CompareTag("MachineBullet"))
        {
            currentEnemyHealth--;
            currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);

            UpdateEnemyHealthBar();

            if (currentEnemyHealth <= 0)
            {
                if (explosion != null)
                {
                    ParticleSystem ps = Instantiate(explosion, transform.position, Quaternion.identity);
                    ps.Play();
                    Destroy(ps.gameObject, ps.main.duration);
                }

                Destroy(tankEnemy);
            }
        }

        else if (other.CompareTag("AssaultBullet"))
        {
            currentEnemyHealth--;
            currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);

            UpdateEnemyHealthBar();

            if (currentEnemyHealth <= 0)
            {
                if (explosion != null)
                {
                    ParticleSystem ps = Instantiate(explosion, transform.position, Quaternion.identity);
                    ps.Play();
                    Destroy(ps.gameObject, ps.main.duration);
                }

                Destroy(tankEnemy);
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
