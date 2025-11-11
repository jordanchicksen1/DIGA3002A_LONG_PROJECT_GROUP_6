using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorial1 : MonoBehaviour
{
    public int requiredKills = 3;   // how many enemies must be killed
    public int currentKills = 0;
    public TextMeshProUGUI currentKillsText;
    public GameObject currentKillsTextObject;
    public GameObject tutorial1CompleteScreen;
    public GameObject player;
    public Transform garageTeleporter;
    public CharacterController characterController;
    public GameObject globalVolumes;
    public GameObject levelMusic;
    public playerHealth playerHealth;
    public uiButtons uiButtons;
    public GameObject lobbyMusic;
    public GameObject tutorial2Icon;
    public credits credits;
    public GameObject tutorial1Icon;
    private void OnEnable()
    {
        
        EnemyMovement.OnEnemyDeath += HandleMovementDeath;
        
    }

    private void OnDisable()
    {
        
        EnemyMovement.OnEnemyDeath -= HandleMovementDeath;
   
    }

  
    private void HandleMovementDeath(EnemyMovement enemy)
    {
        CountKill();
        credits.WalkerKill();
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
        StartCoroutine(TutorialOneComplete());
    }

    public IEnumerator TutorialOneComplete()
    {
        yield return new WaitForSeconds(2f);
        tutorial1CompleteScreen.SetActive(true);
        characterController.enabled = false;
        yield return new WaitForSeconds(2f);
        player.transform.position = garageTeleporter.transform.position;
        characterController.enabled = true;
        tutorial1CompleteScreen.SetActive(false);
        playerHealth.Heal();
        globalVolumes.SetActive(false);
        levelMusic.SetActive(false);
        currentKillsTextObject.SetActive(false);
        uiButtons.isDoingTutorialOne = false;
        lobbyMusic.SetActive(true);
        tutorial2Icon.SetActive(true);
        tutorial1Icon.SetActive(false);
        credits.AddTutOneCredits();
    }
}
