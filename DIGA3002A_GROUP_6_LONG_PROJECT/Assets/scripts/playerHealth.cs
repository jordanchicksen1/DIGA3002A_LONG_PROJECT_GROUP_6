using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBarPic;

   

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        //put player death here
    }


    [ContextMenu("PlayerHit")]
    public void PlayerHit()
    {
        currentHealth = currentHealth - 10f;
        updateHealthBar();
    }

    [ContextMenu("PlayerHitALot")]
    public void PlayerHitALot()
    {
        currentHealth = currentHealth - 30f;
        updateHealthBar();
    }
    
    [ContextMenu("Heal")]
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
