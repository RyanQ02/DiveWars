using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioSource audioSource;
    //Restarts the level
    public void RestartButton()
    {
        audioSource.Play();
        SceneManager.LoadScene("scene-1");
    }

    //Loads the Main Menu (will complete once main menu branch is merged)
    public void MainMenuButton()
    {
        audioSource.Play();
        SceneManager.LoadScene("MainMenu");
    }

    //Quits the game
    public void QuitGameButton()
    {
        audioSource.Play();
        Application.Quit();
    }
}
