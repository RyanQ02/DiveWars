using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject subMenu;
    public AudioSource audioSource;

    //returns you to the main menu screen
    public void ReturnToStartMenu()
    {
        audioSource.Play();
        subMenu.SetActive(false);
        startMenu.SetActive(true);
    }
}
