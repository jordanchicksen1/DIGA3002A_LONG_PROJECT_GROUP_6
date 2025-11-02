
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class missionOneManager : MonoBehaviour
{
    public int requiredKills = 6;   // how many enemies must be killed
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
    public GameObject bossOneIcon;
    private void OnEnable()
    {
        EnemyWeakSpot.OnEnemyDeath += HandleTankDeath;
        EnemyMovement.OnEnemyDeath += HandleMovementDeath;
        TacticalDroneAI.OnDroneDeath += HandleDroneDeath;
    }

    private void OnDisable()
    {
        EnemyWeakSpot.OnEnemyDeath -= HandleTankDeath;
        EnemyMovement.OnEnemyDeath -= HandleMovementDeath;
        TacticalDroneAI.OnDroneDeath += HandleDroneDeath;
    }

    private void HandleTankDeath(EnemyWeakSpot enemy)
    {
        CountKill();
        Debug.Log("MissionManager received TankDeath event!");
    }

    private void HandleMovementDeath(EnemyMovement enemy)
    {
        CountKill();
        Debug.Log("MissionManager received MovementDeath event!");
    }

    private void HandleDroneDeath(TacticalDroneAI enemy)
    {
        CountKill();
        Debug.Log("MissionManager received TacticalDroneAI Event!");
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
        uiButtons.isDoingMissionOne = false;
        currentKillsTextObject.SetActive(false);
        bossOneIcon.SetActive(true);
        lobbyMusic.SetActive(true);
    }
}
