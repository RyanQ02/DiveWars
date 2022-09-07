using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    //when this is pressed you will be taken to the main menu
     public void MenuButton()
     {
        SceneManager.LoadScene("MainMenu");
     }

    //will load the game scene again to try again
    public void PlayAgainButton()
    {
        SceneManager.LoadScene("scene-1");
    }

    //Quits the game 
    public void QuitGameButton()
    {
        Application.Quit();
    }
}
