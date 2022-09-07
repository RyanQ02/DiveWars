using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Score shown at the top right of the screen.
    public static int scoreValue = 0;

    // Public variable to easily edit the number of fish.
    public int numberOfFish;

    // Controls the boss door.
    public GameObject bossDoor;

    // Controls the Kill Counter Game Object
    // and the editable Text Element along with it.
    public GameObject scoreText;
    private Text scoreTextElement;

    // Controls the Game Object Text that shows up when the Boss door is unlocked.
    public GameObject bossText;

    void Start()
    {
        scoreTextElement = GetComponent<Text>();
        bossDoor.SetActive(false);
        bossText.SetActive(false);
        scoreValue = 0;
    }

    void Update()
    {
        scoreTextElement.text = "Total Kills \n" + scoreValue + "/" + numberOfFish;
        BossDoorUnlocked();
    }

    // Function runs when all Enemy Fish have been eliminated
    // and when the max scoreValue has been reached.
    void BossDoorUnlocked()
    {
        if (scoreValue == numberOfFish)
        {
            // Unlocks the door
            bossDoor.SetActive(false);

            // Hides the Kill Counter.
            scoreText.SetActive(false);

            bossText.SetActive(true);
            Destroy(bossText, 27);
        }
        else
        {
            // Door will be true when scorevalue != numberOfFish still remaining.
            bossDoor.SetActive(true);
        }
    }
}