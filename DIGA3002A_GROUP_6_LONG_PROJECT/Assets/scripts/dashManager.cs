using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dashManager : MonoBehaviour
{
    public float maxBoost = 30f;
    public float currentBoost;
    public Image boostBarPic;

    public bool shouldFillBar = false;

    public void Start()
    {
        currentBoost = maxBoost;
    }

    public void Update()
    {
        RefillBoostBar();
    }

    public void RefillBoostBar()
    {
        if (shouldFillBar == true && currentBoost < maxBoost)
        {
            currentBoost += 2*Time.deltaTime;
            updateBoostBar();
        }
    }

    public void UseBoost()
    {
        currentBoost = currentBoost - 3f;
        updateBoostBar();
    }

    public void UseJump()
    {
        currentBoost = currentBoost - 1f;
        updateBoostBar();
    }

    public void UseJetpack()
    {
        currentBoost = currentBoost - 10f * Time.deltaTime;
        updateBoostBar();
    }
    public void updateBoost(float amount)
    {
        currentBoost += amount;
        updateBoostBar();

    }

    public void updateBoostBar()
    {
        float targetFillAmount = currentBoost / maxBoost;
        boostBarPic.fillAmount = targetFillAmount;
    }
}
