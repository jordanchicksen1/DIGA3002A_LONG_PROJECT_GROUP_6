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
    public bool isDoingMissionOne = false;
    public GameObject mission1Screen;
    public Transform teleporterLevel;
    public GameObject missionOneEnemies;
    public GameObject currentKillsCounter;
    public Transform garageTeleporter;
    public GameObject gameOverScreen;
    public GameObject lobbyMusic;

    [Header("Tutorial 1 Stuff")]
    public bool isDoingTutorialOne = false;
    public GameObject tutorial1Screen;
    public GameObject currentKillsCounterTut1;
    public GameObject tutorialOneEnemies;

    [Header("Tutorial 2 Stuff")]
    public bool isDoingTutorialTwo = false;
    public GameObject tutorial2Screen;
    public GameObject currentKillsCounterTut2;
    public GameObject tutorialTwoEnemies;

    [Header("Tutorial 3 Stuff")]
    public bool isDoingTutorialThree = false;
    public GameObject tutorial3Screen;
    public GameObject currentKillsCounterTut3;
    public GameObject tutorialThreeEnemies;
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

    public void StartTutorialOne()
    {
        missionScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(TutorialOne());
    }

    public void StartTutorialTwo()
    {
        missionScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(TutorialTwo());
    }

    public void StartTutorialThree()
    {
        missionScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(TutorialThree());
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
        lobbyMusic.SetActive(false);
        tutorialOneEnemies.SetActive(false);   
        tutorialTwoEnemies.SetActive(false);
        tutorialThreeEnemies.SetActive(false);
        yield return new WaitForSeconds(1f);
        characterController.enabled = true;
        mission1Screen.SetActive(false);
        globalVolumes.SetActive(true);
        levelMusic.SetActive(true);
        missionOneEnemies.SetActive(true);
        currentKillsCounter.SetActive(true);
    }

    public IEnumerator TutorialOne()
    {
        yield return new WaitForSeconds(0f);
        tutorial1Screen.SetActive(true);
        isDoingTutorialOne = true;
        characterController.enabled = false;
        player.transform.position = teleporterLevel.transform.position;
        lobbyMusic.SetActive(false);
        tutorialThreeEnemies.SetActive(false);
        tutorialTwoEnemies.SetActive(false);
        missionOneEnemies.SetActive(false);
        yield return new WaitForSeconds(1f);
        characterController.enabled = true;
        tutorial1Screen.SetActive(false);
        globalVolumes.SetActive(true);
        levelMusic.SetActive(true);
        tutorialOneEnemies.SetActive(true);
        currentKillsCounterTut1.SetActive(true);
    }

    public IEnumerator TutorialTwo()
    {
        yield return new WaitForSeconds(0f);
        tutorial2Screen.SetActive(true);
        isDoingTutorialTwo = true;
        characterController.enabled = false;
        player.transform.position = teleporterLevel.transform.position;
        lobbyMusic.SetActive(false);
        tutorialOneEnemies.SetActive(false);
        tutorialThreeEnemies.SetActive(false);
        missionOneEnemies.SetActive(false);
        yield return new WaitForSeconds(1f);
        characterController.enabled = true;
        tutorial2Screen.SetActive(false);
        globalVolumes.SetActive(true);
        levelMusic.SetActive(true);
        tutorialTwoEnemies.SetActive(true);
        currentKillsCounterTut2.SetActive(true);
    }

    public IEnumerator TutorialThree()
    {
        yield return new WaitForSeconds(0f);
        tutorial3Screen.SetActive(true);
        isDoingTutorialThree = true;
        characterController.enabled = false;
        player.transform.position = teleporterLevel.transform.position;
        lobbyMusic.SetActive(false);
        tutorialOneEnemies.SetActive(false);
        tutorialTwoEnemies.SetActive(false);
        missionOneEnemies.SetActive(false);
        yield return new WaitForSeconds(1f);
        characterController.enabled = true;
        tutorial3Screen.SetActive(false);
        globalVolumes.SetActive(true);
        levelMusic.SetActive(true);
        tutorialThreeEnemies.SetActive(true);
        currentKillsCounterTut3.SetActive(true);
    }

    public IEnumerator BackToTheGarage()
    {
        yield return new WaitForSeconds(0f);
        characterController.enabled = false;
        yield return new WaitForSeconds(0.5f);
        isDoingMissionOne = false;
        isDoingTutorialOne = false;
        isDoingTutorialTwo = false;
        isDoingTutorialThree = false;
        missionOneEnemies.SetActive(false);
        currentKillsCounter.SetActive(false);
        tutorialOneEnemies.SetActive(false);
        currentKillsCounterTut1.SetActive(false);
        tutorialTwoEnemies.SetActive(false);
        currentKillsCounterTut2.SetActive(false);
        tutorialThreeEnemies.SetActive(false);
        currentKillsCounterTut3.SetActive(false);
        player.transform.position = garageTeleporter.transform.position;
        characterController.enabled = true;
        globalVolumes.SetActive(false);
        levelMusic.SetActive(false);
        lobbyMusic.SetActive(true);
        gameOverScreen.SetActive(false);
        playerHealth.Heal();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
