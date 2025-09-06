using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBarPic;
    public playerPosture playerPosture;

   

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
        playerPosture.PlayerPostureHit();
    }

    [ContextMenu("PlayerHitALot")]
    public void PlayerHitALot()
    {
        currentHealth = currentHealth - 30f;
        updateHealthBar();
        playerPosture.PlayerPostureHitALot();
    }

    [ContextMenu("PlayerHitATon")]

    public void PlayerHitATon()
    {
        currentHealth = currentHealth - 50f;
        updateHealthBar();
        playerPosture.FullPostureHit();
    }


    [ContextMenu("Heal")]
    public void Heal()
    {
        currentHealth = maxHealth;
        updateHealthBar();
        playerPosture.PostureHeal();    
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
