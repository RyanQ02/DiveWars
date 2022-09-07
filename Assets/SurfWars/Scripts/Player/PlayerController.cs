using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public bool rushing = false;
    public float rushingDelay = 4f;    
    private float nextRush = 2f;
    private float speedMod = 0;
    public int maxHealth = 5;
    public int currentHealth;

    public GameObject deathScreen;
    public GameObject menuButtons;
    public GameObject healthBar, killText, bossHealthBar, boss;

    float timeLeft = 2f;

    private Rigidbody2D myRigidBody;

    private Animator myAnim;

    public GameObject bubbles;

    public AudioSource Rushing;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        resetBoostTime();
        controllerManager();

        myAnim.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
    }
    //handles button inputs that move the player around
    void controllerManager()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            myRigidBody.transform.GetChild(0).localRotation = Quaternion.Euler(0f, 0f, 0f);
            movePlayer();
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            // Child Transform is flipped 180 when the player is facing left.
            myRigidBody.transform.GetChild(0).localRotation = Quaternion.Euler(0f, 180f, 0f);
            movePlayer();
        }
        else if (Input.GetAxisRaw("Vertical") > 0f)
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, moveSpeed, 0f);
        }
        else if (Input.GetAxis("Vertical") < 0f)
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, -moveSpeed, 0f);
        }

        if (Input.GetButtonDown("Jump") && !rushing && Time.time > nextRush)
        {
            Rushing.Play();
            rushing = true;
            speedMod = 1.5f;
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            movePlayer();
            // Adds delay between Rushes.
            nextRush = Time.time + rushingDelay;
        }
    }

    void movePlayer()
    {
        if (transform.localScale.x == 1)
        {
            myRigidBody.velocity = new Vector3(moveSpeed + speedMod, myRigidBody.velocity.y, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector3(-(moveSpeed + speedMod), myRigidBody.velocity.y, 0f);
        }
    }

    //stops the player from being able to spam the rush attack
    void resetBoostTime()
    {
        if (timeLeft <= 0)
        {
            timeLeft = 1.5f;
            rushing = false;
            speedMod = 0;
        }
        else if (rushing)
        {
            timeLeft -= Time.deltaTime;
        }
    }

    //palys the hurt animation provided the player is not rushing
    public void hurt()
    {
        if (!rushing)
        {
            gameObject.GetComponent<Animator>().Play("PlayerHurt");
        }
    }

    //changes the amount of health the player has to a float for UIHealthBar to change the GUI health bar
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if (!rushing)
            UIHealthBar.instance.SetValue(currentHealth / (float) maxHealth);
        if (currentHealth < 1)
        {
            DeathScreen();
        }
    }    

    //If the player dies this will show the death menu and hide any elements that would overlay the screens
    void DeathScreen()
    {
        Time.timeScale = 0;
        deathScreen.SetActive(true);
        menuButtons.SetActive(true);
        healthBar.SetActive(false);
        killText.SetActive(false);
        bossHealthBar.SetActive(false);
        boss.SetActive(false);
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in enemy)
        {
            go.SetActive(false);
        }
    }
}