using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiButtons : MonoBehaviour
{
    [Header("Screens")]
    public GameObject roboBuildingScreen;
    public GameObject headsScreen;
    public GameObject torsosScreen;
    public GameObject legsScreen;
    public GameObject weaponsScreen;
    public GameObject supersScreen;
    public GameObject pauseScreen;
    public PlayerController playerEdited;

    [Header("Scripts")]
    public leftAmmoManager leftAmmoManager;
    public rightAmmoManager rightAmmoManager;

    public void GoBackToRoboBuilding()
    {
        headsScreen.SetActive(false);
        torsosScreen.SetActive(false);
        legsScreen.SetActive(false);
        weaponsScreen.SetActive(false);
        supersScreen.SetActive(false);
        roboBuildingScreen.SetActive(true);
    }

    public void GoToHeadsScreen()
    {
        headsScreen.SetActive(true);
        torsosScreen.SetActive(false);
        legsScreen.SetActive(false);
        weaponsScreen.SetActive(false);
        supersScreen.SetActive(false);
        roboBuildingScreen.SetActive(false);
    }

    public void GoToTorsosScreen()
    {
        headsScreen.SetActive(false);
        torsosScreen.SetActive(true);
        legsScreen.SetActive(false);
        weaponsScreen.SetActive(false);
        supersScreen.SetActive(false);
        roboBuildingScreen.SetActive(false);
    }

    public void GoToLegsScreen()
    {
        headsScreen.SetActive(false);
        torsosScreen.SetActive(false);
        legsScreen.SetActive(true);
        weaponsScreen.SetActive(false);
        supersScreen.SetActive(false);
        roboBuildingScreen.SetActive(false);
    }

    public void GoToWeaponsScreen()
    {
        headsScreen.SetActive(false);
        torsosScreen.SetActive(false);
        legsScreen.SetActive(false);
        weaponsScreen.SetActive(true);
        supersScreen.SetActive(false);
        roboBuildingScreen.SetActive(false);
    }

    public void GoToSupersScreen()
    {
        headsScreen.SetActive(false);
        torsosScreen.SetActive(false);
        legsScreen.SetActive(false);
        weaponsScreen.SetActive(false);
        supersScreen.SetActive(true);
        roboBuildingScreen.SetActive(false);
    }

    public void CloseRoboBuilding()
    {
        headsScreen.SetActive(false);
        torsosScreen.SetActive(false);
        legsScreen.SetActive(false);
        weaponsScreen.SetActive(false);
        supersScreen.SetActive(false);
        roboBuildingScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        leftAmmoManager.currentAmmo = leftAmmoManager.maxAmmo;
        leftAmmoManager.updateAmmoBar();
        rightAmmoManager.currentAmmo = rightAmmoManager.maxAmmo;
        rightAmmoManager.updateAmmoBar();
    }

    public void ClosePause()
    {
        pauseScreen.SetActive(false);
        playerEdited.isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}
