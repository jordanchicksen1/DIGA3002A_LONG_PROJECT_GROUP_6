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
    public float ImageAlpha;
    public GameObject gameOverScreen;
    [Header("Player Hurt Comunication")]
    /*public MeshRenderer MeshRenderer;
    public Material HurtPlayerMat;
    public float MateralAlpha;*/
    public GameObject HurtPlayerOutline;
    public AttackIndicator attackIndicator;

    private void Awake()
    {
        //MeshRenderer = GetComponent<MeshRenderer>();
    }

    public void Start()
    {
        currentHealth = maxHealth;

      /*  Color C = HurtPlayerMat.color;
        C.a = MateralAlpha;
        HurtPlayerMat.color = C;*/
    }

    public void Update()
    {
        //put player death here
        DamagedPlayerScreen();

        if(currentHealth <= 0)
        {
            gameOverScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    [ContextMenu("PlayerHit")]
    public void PlayerHit(Vector3 attackerPosition)
    {
        currentHealth -= 10f;
        StartCoroutine(RedOn());

        if (attackIndicator != null)
        {
            Vector3 attackDirection = attackerPosition - transform.position;
            attackIndicator.ShowIndicator(attackDirection);
        }

        if (currentHealth <= maxHealth / 2)
            ImageAlpha += 0.1f;

        updateHealthBar();
        playerPosture.PlayerPostureHit();
    }


    [ContextMenu("PlayerHitALot")]
    public void PlayerHitALot()
    {
        currentHealth = currentHealth - 30f;
        StartCoroutine(RedOn());

        if (currentHealth <= maxHealth / 2)
        {
            ImageAlpha += 0.3f;
        }
        updateHealthBar();
        playerPosture.PlayerPostureHitALot();
    }

    [ContextMenu("PlayerHitATon")]

    public void PlayerHitATon()
    {
        currentHealth = currentHealth - 50f;
        StartCoroutine(RedOn());

        if (currentHealth <= maxHealth / 2)
        {
            ImageAlpha += 0.5f;
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
        currentColor.a = ImageAlpha;
        
        DamagedScreenImage.color = currentColor;

        if (currentHealth <= 0)
        {
            ImageAlpha = 1f;
        }

        if (currentHealth > maxHealth / 2) 
        {
            ImageAlpha = 0f;
        }
    }

    public IEnumerator RedOn() 
    {
        HurtPlayerOutline.SetActive(true);
        yield return new WaitForSeconds(1);
        HurtPlayerOutline.SetActive(false);
    }
}
