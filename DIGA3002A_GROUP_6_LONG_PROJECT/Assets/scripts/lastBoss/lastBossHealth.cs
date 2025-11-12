using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lastBossHealth : MonoBehaviour
{

    [Header("Health Bar")]
    public float maxHealth = 1500f;
    public float currentHealth;
    public Image healthBarPic;
    public lastBossPosture lastBossPosture;
    public lastBoss firstBoss;
    public ParticleSystem explosion;
    public static event System.Action<lastBossHealth> OnBossLDeath;
    public void Start()
    {
        currentHealth = maxHealth;


    }

    public void Update()
    {
        if (currentHealth > 1300f)
        {
            firstBoss.Phase1 = true;
            firstBoss.Phase2 = false;
            firstBoss.Phase3 = false;
        }

        if (currentHealth < 1300f && currentHealth > 800f)
        {
            firstBoss.Phase1 = false;
            firstBoss.Phase2 = true;
            firstBoss.Phase3 = false;
        }

        if (currentHealth < 800f)
        {
            firstBoss.Phase1 = false;
            firstBoss.Phase2 = false;
            firstBoss.Phase3 = true;
        }

        if (currentHealth <= 0f)
        {
            Debug.Log("Boss died");
            if (explosion != null)
            {
                ParticleSystem ps = Instantiate(explosion, transform.position, Quaternion.identity);
                ps.Play();
                Destroy(ps.gameObject, ps.main.duration);
            }

            OnBossLDeath?.Invoke(this);
            Destroy(gameObject);
        }

    }


    [ContextMenu("BasicHit")]
    public void BasicHit()
    {
        currentHealth = currentHealth - 5f;
        updateHealthBar();
        lastBossPosture.PostureHitALot();
    }

    [ContextMenu("MachineHit")]
    public void MachineHit()
    {
        currentHealth = currentHealth - 2f;

        updateHealthBar();
        lastBossPosture.SmallPostureHit();
    }

    [ContextMenu("AssaultHit")]

    public void AssaultHit()
    {
        currentHealth = currentHealth - 4f;
        updateHealthBar();
        lastBossPosture.PostureHitALot();
    }

    [ContextMenu("LaserHit")]
    public void LaserHit()
    {
        currentHealth = currentHealth - 10f;

        updateHealthBar();
        lastBossPosture.BigPostureHit();
    }

    [ContextMenu("BeamHit")]
    public void BeamHit()
    {
        currentHealth = currentHealth - 50f;

        updateHealthBar();
        lastBossPosture.BigPostureHit();
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
