using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiButtons : MonoBehaviour
{
    [Header("Screens")]
    public GameObject roboBuildingScreen;
    public GameObject missionScreen;
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
    public playerHealth playerHealth;


    [Header("Mission Stuff")]
    public GameObject player;
    public CharacterController characterController;
    public GameObject globalVolumes;
    public GameObject levelMusic;
    public bool isDoingMissionOne;
    public GameObject mission1Screen;
    public Transform teleporterLevel;
    public GameObject missionOneEnemies;
    public GameObject currentKillsCounter;
    public Transform garageTeleporter;
    public GameObject gameOverScreen;
    

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
        leftAmmoManager.currentAmmo = leftAmmoManager.maxAmmo;
        leftAmmoManager.updateAmmoBar();
        rightAmmoManager.currentAmmo = rightAmmoManager.maxAmmo;
        rightAmmoManager.updateAmmoBar();
    }

    public void CloseMissionScreen()
    {
        missionScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void StartMissionOne()
    {
        missionScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(MissionOne());
    }

    public void BackGarage()
    {
        StartCoroutine(BackToTheGarage());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator MissionOne()
    {
        yield return new WaitForSeconds(0f);
        mission1Screen.SetActive(true);
        isDoingMissionOne = true;
        characterController.enabled = false;
        player.transform.position = teleporterLevel.transform.position;
        yield return new WaitForSeconds(1f);
        characterController.enabled = true;
        mission1Screen.SetActive(false);
        globalVolumes.SetActive(true);
        levelMusic.SetActive(true);
        missionOneEnemies.SetActive(true);
        currentKillsCounter.SetActive(true);
    }

    public IEnumerator BackToTheGarage()
    {
        yield return new WaitForSeconds(0f);
        playerHealth.Heal();
        gameOverScreen.SetActive(false);
        characterController.enabled = false;
        yield return new WaitForSeconds(0.5f);
        player.transform.position = garageTeleporter.transform.position;
        characterController.enabled = true;
        
        
        
    }
}
