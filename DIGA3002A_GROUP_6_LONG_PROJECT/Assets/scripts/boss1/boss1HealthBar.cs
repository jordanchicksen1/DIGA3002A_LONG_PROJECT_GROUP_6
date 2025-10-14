using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class boss1HealthBar : MonoBehaviour
{
    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBarPic;
    public boss1Posture boss1Posture;

    public void Start()
    {
        currentHealth = maxHealth;

       
    }

    public void Update()
    {
      
        
    }


    [ContextMenu("BasicHit")]
    public void BasicHit()
    {
        currentHealth = currentHealth - 5f;
        updateHealthBar();
        boss1Posture.PostureHitALot();
    }

    [ContextMenu("MachineHit")]
    public void MachineHit()
    {
        currentHealth = currentHealth - 2f;
      
        updateHealthBar();
        boss1Posture.SmallPostureHit();
    }

    [ContextMenu("AssaultHit")]

    public void AssaultHit()
    {
        currentHealth = currentHealth - 4f;
        updateHealthBar();
        boss1Posture.PostureHitALot();
    }

    [ContextMenu("LaserHit")]
    public void LaserHit()
    {
        currentHealth = currentHealth - 10f;

        updateHealthBar();
       boss1Posture.BigPostureHit();
    }

    [ContextMenu("BeamHit")]
    public void BeamHit()
    {
        currentHealth = currentHealth - 50f;

        updateHealthBar();
        boss1Posture.BigPostureHit();
    }

    public void Heal()
    {
        currentHealth = maxHealth;
        updateHealthBar();
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
