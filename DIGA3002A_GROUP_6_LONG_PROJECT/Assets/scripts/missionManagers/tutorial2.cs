using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorial2 : MonoBehaviour
{
    public int requiredKills = 3;   // how many enemies must be killed
    public int currentKills = 0;
    public TextMeshProUGUI currentKillsText;
    public GameObject currentKillsTextObject;
    public GameObject tutorial2CompleteScreen;
    public GameObject player;
    public Transform garageTeleporter;
    public CharacterController characterController;
    public GameObject globalVolumes;
    public GameObject levelMusic;
    public playerHealth playerHealth;
    public uiButtons uiButtons;
    public GameObject lobbyMusic;
    public GameObject tutorial3Icon;
    private void OnEnable()
    {

        EnemyWeakSpot.OnEnemyDeath += HandleTankDeath;

    }

    private void OnDisable()
    {

        EnemyWeakSpot.OnEnemyDeath -= HandleTankDeath;

    }


    private void HandleTankDeath(EnemyWeakSpot enemy)
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
        StartCoroutine(TutorialTwoComplete());
    }

    public IEnumerator TutorialTwoComplete()
    {
        yield return new WaitForSeconds(2f);
        tutorial2CompleteScreen.SetActive(true);
        characterController.enabled = false;
        yield return new WaitForSeconds(2f);
        player.transform.position = garageTeleporter.transform.position;
        characterController.enabled = true;
        tutorial2CompleteScreen.SetActive(false);
        playerHealth.Heal();
        globalVolumes.SetActive(false);
        levelMusic.SetActive(false);
        currentKillsTextObject.SetActive(false);
        uiButtons.isDoingTutorialTwo = false;
        lobbyMusic.SetActive(true);
        tutorial3Icon.SetActive(true);
    }
}
