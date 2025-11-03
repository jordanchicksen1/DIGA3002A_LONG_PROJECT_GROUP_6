using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstBossHealth : MonoBehaviour
{
  
    [Header("Health Bar")]
    public float maxHealth = 1500f;
    public float currentHealth;
    public Image healthBarPic;
    public firstBossPosture firstBossPosture;
    public firstBoss firstBoss;
    public ParticleSystem explosion;
    public static event System.Action<firstBossHealth> OnBoss1Death;
    public void Start()
    {
        currentHealth = maxHealth;


    }

    public void Update()
    {
        if(currentHealth > 1000f)
        {
            firstBoss.Phase1 = true;
            firstBoss.Phase2 = false;
            firstBoss.Phase3 = false;
        }

        if (currentHealth < 1000f && currentHealth > 500f)
        {
            firstBoss.Phase1 = false;
            firstBoss.Phase2 = true;
            firstBoss.Phase3 = false;
        }

        if (currentHealth < 500f)
        {
            firstBoss.Phase1 = false;
            firstBoss.Phase2 = false;
            firstBoss.Phase3 = true;
        }

        if(currentHealth <= 0f)
        {
            Debug.Log("Boss died");
            if (explosion != null)
            {
                ParticleSystem ps = Instantiate(explosion, transform.position, Quaternion.identity);
                ps.Play();
                Destroy(ps.gameObject, ps.main.duration);
            }

            OnBoss1Death?.Invoke(this);
            Destroy(gameObject);
        }

    }


    [ContextMenu("BasicHit")]
    public void BasicHit()
    {
        currentHealth = currentHealth - 5f;
        updateHealthBar();
        firstBossPosture.PostureHitALot();
    }

    [ContextMenu("MachineHit")]
    public void MachineHit()
    {
        currentHealth = currentHealth - 2f;

        updateHealthBar();
        firstBossPosture.SmallPostureHit();
    }

    [ContextMenu("AssaultHit")]

    public void AssaultHit()
    {
        currentHealth = currentHealth - 4f;
        updateHealthBar();
        firstBossPosture.PostureHitALot();
    }

    [ContextMenu("LaserHit")]
    public void LaserHit()
    {
        currentHealth = currentHealth - 10f;

        updateHealthBar();
        firstBossPosture.BigPostureHit();
    }

    [ContextMenu("BeamHit")]
    public void BeamHit()
    {
        currentHealth = currentHealth - 50f;

        updateHealthBar();
        firstBossPosture.BigPostureHit();
    }

    public void updateHealth(float amount)
    {
        currentHealth += amount;
        updateHealthBar();

    }

    public void updateHealthBar()
    {
        float targetFillAmount = currentHealth / maxHealth;
        healthBarPic.fillAmount = targetFillAmount;
    }
}


