using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class boss1Mission : MonoBehaviour
{
    public int requiredKills = 1;   // how many enemies must be killed
    public int currentKills = 0;
    public TextMeshProUGUI currentKillsText;
    public GameObject currentKillsTextObject;
    public GameObject mission1CompleteScreen;
    public GameObject player;
    public Transform garageTeleporter;
    public CharacterController characterController;
    public GameObject globalVolumes;
    public GameObject levelMusic;
    public playerHealth playerHealth;
    public uiButtons uiButtons;
    public GameObject lobbyMusic;
    public GameObject boss1Icon;
    public GameObject finalBossIcon;
    public credits credits;
    public GameObject boss1HealthBar;
    private void OnEnable()
    {
        firstBossHealth.OnBoss1Death += HandleBossDeath;
    }

    private void OnDisable()
    {
        firstBossHealth.OnBoss1Death -= HandleBossDeath;
    }

    private void HandleBossDeath(firstBossHealth boss)
    {
        CountKill();
        Debug.Log("MissionManager received TankDeath event!");
    }

    

    private void CountKill()
    {
        currentKills++;
        currentKillsText.text = currentKills.ToString();
        Debug.Log("Enemy destroyed! Total: " + currentKills);

        if (currentKills >= requiredKills)
        {
            MissionComplete();
        }
    }

    public void MissionComplete()
    {
        Debug.Log("Mission Complete!");
        StartCoroutine(MissionOneComplete());
    }

    public IEnumerator MissionOneComplete()
    {
        yield return new WaitForSeconds(2f);
        mission1CompleteScreen.SetActive(true);
        characterController.enabled = false;
        yield return new WaitForSeconds(2f);
        player.transform.position = garageTeleporter.transform.position;
        characterController.enabled = true;
        mission1CompleteScreen.SetActive(false);
        playerHealth.Heal();
        globalVolumes.SetActive(false);
        levelMusic.SetActive(false);
        uiButtons.isDoingBossOne = false;
        currentKillsTextObject.SetActive(false);
        lobbyMusic.SetActive(true);
        boss1Icon.SetActive(false);
        finalBossIcon.SetActive(true);
        credits.AddBossOneCredits();
        boss1HealthBar.SetActive(false);
        
    }
}


