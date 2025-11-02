using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstBossPosture : MonoBehaviour
{
    public float maxPosture = 100f;
    public float minPosture = 0f;
    public float currentPosture;
    public Image postureBarPic;
    public bool isStaggered = false;
    public GameObject staggeredText;
    public PlayerController playerController;


    public void Start()
    {
        currentPosture = minPosture;
        updatePostureBar();
    }

    public void Update()
    {
        if (currentPosture <= maxPosture && currentPosture > minPosture && isStaggered == false)
        {
            currentPosture -= Time.deltaTime * 10;
            updatePostureBar();
        }

        if (currentPosture >= maxPosture)
        {
            isStaggered = true;
            staggeredText.SetActive(true);
            StartCoroutine(GotStaggered());

        }
    }


    [ContextMenu("SmallPostureHit")]
    public void SmallPostureHit()
    {
        currentPosture = currentPosture + 2f;
        updatePostureBar();
    }

    [ContextMenu("PostureHitALot")]
    public void PostureHitALot()
    {
        currentPosture = currentPosture + 5f;
        updatePostureBar();
    }

    [ContextMenu("BigPostureHit")]
    public void BigPostureHit()
    {
        currentPosture = currentPosture + 12f;
        updatePostureBar();
    }

    [ContextMenu("PostureHeal")]
    public void BossPostureHeal()
    {
        currentPosture = minPosture;
        updatePostureBar();
    }




    public IEnumerator GotStaggered()
    {
        yield return new WaitForSeconds(3f);
        isStaggered = false;
        staggeredText.SetActive(false);
        BossPostureHeal();
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
