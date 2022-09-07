using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject howToPlay;
    public GameObject theTask;

    public AudioSource audioSource;

    // When the start button is pressed it will load our game scene
    public void StartGameButton()
    {
        audioSource.Play();
        SceneManager.LoadScene("scene-1");
    }

    // When the quit button is pressed it will quit the application
    public void QuitGameButton()
    {
        audioSource.Play();
        Application.Quit();
    }

    //Will open the how to play menu and hide this canvas so it does not get in the way of the user
    public void HowToPlayButton()
    {
        audioSource.Play();
        startMenu.SetActive(false);
        howToPlay.SetActive(true);
    }
    
    //Will open the how to play menu and hide this canvas so it does not get in the way of the user
    public void TheTaskButton()
    {
        audioSource.Play();
        startMenu.SetActive(false);
        theTask.SetActive(true);
    }

}
