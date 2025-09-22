using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBarPic;
    public playerPosture playerPosture;

    [Header("Damage")]
    public Image DamagedScreenImage;
    public float Alpha;

    [Header("Player Hurt Comunication")]
    public MeshRenderer MeshRenderer;
    public Material HurtPlayerMat;

    private void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        //put player death here
        DamagedPlayerScreen();
    }


    [ContextMenu("PlayerHit")]
    public void PlayerHit()
    {
        currentHealth = currentHealth - 10f;
        
        if (currentHealth <= maxHealth / 2)
        {
            Alpha += 0.1f;
        }

        updateHealthBar();
        playerPosture.PlayerPostureHit();
    }

    [ContextMenu("PlayerHitALot")]
    public void PlayerHitALot()
    {
        currentHealth = currentHealth - 30f;

        if (currentHealth <= maxHealth / 2)
        {
            Alpha += 0.3f;
        }
        updateHealthBar();
        playerPosture.PlayerPostureHitALot();
    }

    [ContextMenu("PlayerHitATon")]

    public void PlayerHitATon()
    {
        currentHealth = currentHealth - 50f;
        
        if (currentHealth <= maxHealth / 2)
        {
            Alpha += 0.5f;
        }
        
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

    public void DamagedPlayerScreen()
    {
        Color currentColor = DamagedScreenImage.color;
        currentColor.a = Alpha;
        
        DamagedScreenImage.color = currentColor;

        if (currentHealth <= 0)
        {
            Alpha = 1f;
        }

       

    }
}
