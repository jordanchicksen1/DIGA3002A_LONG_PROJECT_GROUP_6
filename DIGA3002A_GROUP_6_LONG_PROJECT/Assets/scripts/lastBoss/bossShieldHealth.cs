using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossShieldHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBarPic;
    public GameObject theShield;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(theShield);
        }
    }



    [ContextMenu("BasicHit")]
    public void BasicHit()
    {
        currentHealth = currentHealth - 5f;
        updateHealthBar();
       
    }

    [ContextMenu("MachineHit")]
    public void MachineHit()
    {
        currentHealth = currentHealth - 2f;

        updateHealthBar();
       
    }

    [ContextMenu("AssaultHit")]

    public void AssaultHit()
    {
        currentHealth = currentHealth - 4f;
        updateHealthBar();
       
    }

    [ContextMenu("LaserHit")]
    public void LaserHit()
    {
        currentHealth = currentHealth - 10f;

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
