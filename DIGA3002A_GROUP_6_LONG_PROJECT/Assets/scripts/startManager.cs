using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startManager : MonoBehaviour
{
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    public GameObject scene4;
    public GameObject scene5;
    public GameObject scene6;
    public GameObject scene7;
    public GameObject scene8;

    public void StartButton()
    {
        scene1.SetActive(false);
        scene2.SetActive(true);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(false);
        scene6.SetActive(false);
        scene7.SetActive(false);
        scene8.SetActive(false);
    }

    public void NextOne()
    {
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(true);
        scene4.SetActive(false);
        scene5.SetActive(false);
        scene6.SetActive(false);
        scene7.SetActive(false);
        scene8.SetActive(false);
    }

    public void NextTwo() 
    {
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(true);
        scene5.SetActive(false);
        scene6.SetActive(false);
        scene7.SetActive(false);
        scene8.SetActive(false);
    }
    public void NextThree() 
    {
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(true);
        scene6.SetActive(false);
        scene7.SetActive(false);
        scene8.SetActive(false);
    }

    public void NextFour() 
    {
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(false);
        scene6.SetActive(true);
        scene7.SetActive(false);
        scene8.SetActive(false);
    }

    public void NextFive() 
    {
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(false);
        scene6.SetActive(false);
        scene7.SetActive(true);
        scene8.SetActive(false);
    }

    public void NextSeven() 
    {
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(false);
        scene6.SetActive(false);
        scene7.SetActive(false);
        scene8.SetActive(true);
    }

    public void PlayGame() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the index of the next scene
        int nextSceneIndex = currentSceneIndex + 1;

        // Optional: Check if the next scene index is valid or wrap around
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Handle end of scenes (e.g., return to main menu or loop)
            Debug.Log("Reached the last scene in the build settings!");
            // Example to loop back to the first scene (index 0):
            // SceneManager.LoadScene(0); 
        }
    }

}
