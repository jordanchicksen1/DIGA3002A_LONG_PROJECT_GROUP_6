using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class superMoveBar : MonoBehaviour
{
    public float maxSuperBar = 100f;
    public float currentSuperBar;
    public Image superBarPic;
    

    public void Start()
    {
        //use this for testing but take it out when enemies are in
        currentSuperBar = maxSuperBar;
        updateSuperBar();
    }

    public void Update()
    {
        
    }


    [ContextMenu("BasicHit")]
    public void BasicHit()
    {
        currentSuperBar = currentSuperBar + 1.25f;
        updateSuperBar();

    }

    [ContextMenu("MachineHit")]
    public void MachineHit()
    {
        currentSuperBar = currentSuperBar + 0.5f;
        updateSuperBar();

    }

    [ContextMenu("AssaultHit")]
    public void AssaultHit()
    {
        currentSuperBar = currentSuperBar + 1f;
        updateSuperBar();

    }

    [ContextMenu("LaserHit")]
    public void LaserHit()
    {
        currentSuperBar = currentSuperBar + 2.5f;
        updateSuperBar();

    }

    [ContextMenu("UseSuperBar")]
    public void UseSuperBar()
    {
        currentSuperBar = 0f;
        updateSuperBar();
    }

    [ContextMenu("FullSuperTest")]
    public void FullSuperTest()
    {
        currentSuperBar = 100f;
        updateSuperBar();
    }



    public void updateSuper(float amount)
    {
        currentSuperBar += amount;
        updateSuperBar();

    }

    public void updateSuperBar()
    {
        float targetFillAmount = currentSuperBar / maxSuperBar;
        superBarPic.fillAmount = targetFillAmount;
    }
}
