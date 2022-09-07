using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
    private bool isPaused = false;
    public GameObject pauseScreen;

    // Use this for initialization
    void Start () {
        pauseScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, -10);
        PauseMenu();
    }

    //Shows or hides pause menu when the escape key is pressed
    void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
                target.GetComponent<PlayerController>().enabled = true;
                target.GetComponent<Weapon>().enabled = true;
            }
            else if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
                target.GetComponent<PlayerController>().enabled = false;
                target.GetComponent<Weapon>().enabled = false;
            }
        }
    }
}
