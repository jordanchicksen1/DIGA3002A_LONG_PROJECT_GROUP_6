using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastBossMission : MonoBehaviour
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
    public credits credits;
    private void OnEnable()
    {
        lastBossHealth.OnBossLDeath += HandleBossDeath;
    }

    private void OnDisable()
    {
        lastBossHealth.OnBossLDeath -= HandleBossDeath;
    }

    private void HandleBossDeath(lastBossHealth boss)
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
        SceneManager.LoadScene("END");
    }
}
