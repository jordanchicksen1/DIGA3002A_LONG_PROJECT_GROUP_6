using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leftAmmoManager : MonoBehaviour
{
    public float maxAmmo = 100f;
    public float currentAmmo;
    public Image ammoBarPic;

    private bool isRefilling = false;

    public void Start()
    {
        currentAmmo = maxAmmo;
        updateAmmoBar();
    }

    public void Update()
    {
        if (currentAmmo <= 0 && !isRefilling)
        {
            Debug.Log("Ammo empty, starting refill...");
            StartCoroutine(AmmoFill());
        }
    }

    public void BasicShot()
    {
        currentAmmo -= 5f;
        updateAmmoBar();
    }

    public void MachineShot()
    {
        currentAmmo -= 2f;
        updateAmmoBar();
    }

    public void AssaultShot()
    {
        currentAmmo -= 4f;
        updateAmmoBar();
    }

    public void LaserShot()
    {
        currentAmmo -= 10f;
        updateAmmoBar();
    }

    public void RefillAmmo()
    {
        currentAmmo = maxAmmo;
        updateAmmoBar();
    }

    public void updateAmmo(float amount)
    {
        currentAmmo += amount;
        updateAmmoBar();
    }

    public void updateAmmoBar()
    {
        float targetFillAmount = currentAmmo / maxAmmo;
        ammoBarPic.fillAmount = targetFillAmount;
    }

    public IEnumerator AmmoFill()
    {
        isRefilling = true;

        yield return new WaitForSeconds(3f);

        currentAmmo = maxAmmo;
        updateAmmoBar();

        isRefilling = false;
    }
}
