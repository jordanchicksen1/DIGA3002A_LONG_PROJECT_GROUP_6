using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basicShieldHealth : MonoBehaviour
{
    public float maxShieldHealth = 100f;
    public float currentShieldHealth;
    public Image healthBarShieldPic;
    public GameObject theShield;

    public void Start()
    {
        currentShieldHealth = maxShieldHealth;
    }

    public void Update()
    {
       
    }


    [ContextMenu("ShieldHit")]
    public void ShieldHit()
    {
        currentShieldHealth = currentShieldHealth - 10f;
        updateShieldHealthBar();

        if (currentShieldHealth <= 0)
        {

            theShield.SetActive(false);
        }
    }

    [ContextMenu("ShieldHitALot")]
    public void ShieldHitALot()
    {
        currentShieldHealth = currentShieldHealth - 30f;
        updateShieldHealthBar();

        if (currentShieldHealth <= 0)
        {

            theShield.SetActive(false);
        }
    }

    [ContextMenu("ShieldHitATon")]

    public void ShieldHitATon()
    {
        currentShieldHealth = currentShieldHealth - 50f;
        updateShieldHealthBar();

        if (currentShieldHealth <= 0)
        {

            theShield.SetActive(false);
        }
    }




    public void updateShieldHealth(float amount)
    {
        currentShieldHealth += amount;
        updateShieldHealthBar();

    }

    public void updateShieldHealthBar()
    {
        float targetFillAmount = currentShieldHealth / maxShieldHealth;
        healthBarShieldPic.fillAmount = targetFillAmount;
    }
}
