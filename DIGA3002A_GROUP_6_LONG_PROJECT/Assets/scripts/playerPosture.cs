using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerPosture : MonoBehaviour
{

    public float maxPosture = 100f;
    public float staggeredPosture = 90f;
    public float minPosture = 0f;
    public float currentPosture;
    public Image postureBarPic;
    public bool isStaggered = false;

    public PlayerController playerController;


    public void Start()
    {
        currentPosture = minPosture;
    }

    public void Update()
    {
        if(currentPosture < maxPosture && currentPosture > minPosture && isStaggered == false)
        {
            currentPosture -= Time.deltaTime;
            updatePostureBar();
        }

        if(currentPosture > 99.9)
        {
            currentPosture = staggeredPosture;
            updatePostureBar();
            playerController.PlayerStaggered();
            
        }
    }


    [ContextMenu("PlayerPostureHit")]
    public void PlayerPostureHit()
    {
        currentPosture = currentPosture + 20f;
        updatePostureBar();
    }

    [ContextMenu("PlayerPostureHitALot")]
    public void PlayerPostureHitALot()
    {
        currentPosture = currentPosture + 40f;
        updatePostureBar();
    }

    [ContextMenu("FullPostureHit")]
    public void FullPostureHit()
    {
        currentPosture = maxPosture;
        updatePostureBar();
    }

    [ContextMenu("PostureHeal")]
    public void PostureHeal()
    {
        currentPosture = minPosture;
        updatePostureBar();
    }

    public void updatePosture(float amount)
    {
        currentPosture += amount;
        updatePostureBar();

    }

    public void updatePostureBar()
    {
        float targetFillAmount = currentPosture / maxPosture;
        postureBarPic.fillAmount = targetFillAmount;
    }
}
