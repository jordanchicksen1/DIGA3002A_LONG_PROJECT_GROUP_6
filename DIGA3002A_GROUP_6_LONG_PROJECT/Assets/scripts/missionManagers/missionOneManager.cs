using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class missionOneManager : MonoBehaviour
{
    public int requiredKills = 6;   // how many enemies must be killed
    public int currentKills = 0;
    public TextMeshProUGUI currentKillsText;
    public GameObject mission1CompleteScreen;
    public GameObject player;
    public Transform garageTeleporter;
    public CharacterController characterController;
    public GameObject globalVolumes;
    public GameObject levelMusic;
    public playerHealth playerHealth;
    private void OnEnable()
    {
        EnemyWeakSpot.OnEnemyDeath += HandleTankDeath;
        EnemyMovement.OnEnemyDeath += HandleMovementDeath;
    }

    private void OnDisable()
    {
        EnemyWeakSpot.OnEnemyDeath -= HandleTankDeath;
        EnemyMovement.OnEnemyDeath -= HandleMovementDeath;
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

    }
}
