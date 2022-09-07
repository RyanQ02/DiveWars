using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossScript : MonoBehaviour
{
	private PlayerController thePlayer;
	public GameObject death;
	public GameObject BossHealthUI, menuButtons, winScreen, playerHealthBar;
	public GameObject[] spawnPoints;
	public GameObject minion;

	public float speed = 0.3f;
	public float timeTrigger;
	bool healthIsVisible;
	bool musicStatus = false ;

	Rigidbody2D myRigidbody;
	StateBoss currentState;
	Animator anim;
	NavMeshAgent agent;
	Trigger trigger;
	public Transform player;

	public int health;
	int fullhealth;

	public AudioSource killed;
	public AudioSource bossMusic;



	void Start()
	{
		thePlayer = FindObjectOfType<PlayerController>();
		trigger = FindObjectOfType<Trigger>();
		myRigidbody = GetComponent<Rigidbody2D>();
		fullhealth = health;
		timeTrigger = 3f;
		healthIsVisible = false;
		BossHealthUI.SetActive(false);

		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
		agent.speed = speed;

		currentState = new EngageBoss(this.gameObject, anim, player, agent, spawnPoints, minion);

	}

	// When Spear or Rush is within the collider of the Enemy then Damage is done.
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player" && thePlayer.rushing)
		{
			TakeDamage(30);
		}


	}
	//plays music if it is not already playing
    private void Update()
    {
        if (trigger.isActivated)
        {
			musicStatus = true;
			currentState = currentState.Process();
		}


		if (musicStatus == true && !bossMusic.isPlaying)
		{
			bossMusic.Play();
		}

	}

    // Health is reduced when damage from the Spear prefab or rushing is done changing the health bar
    public void TakeDamage(int damage)
	{
		health -= damage;
		if (!healthIsVisible)
        {
			BossHealthUI.SetActive(true);
			UIBossHealthBar.instance.SetMaskSize();
			healthIsVisible = true;
        }

		
		UIBossHealthBar.instance.SetBossHealth(health / (float)fullhealth);

		if (health <= 0)
		{
			BossHealthUI.SetActive(false);
			Die();
		}
	}

	// When Health is 0, Enemy Game Object will be destroyed and the score counter will go up by 1.
	void Die()
	{		
		Destroy(gameObject);
		killed.Play();
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		Destroy(gameObject, 1);
		Score.scoreValue += 1;
		WinScreen();
	}

	//shows the win screen and hides anything that would overlay the screen
	void WinScreen()
	{
		bossMusic.Stop();
		Time.timeScale = 0;
		winScreen.SetActive(true);
		menuButtons.SetActive(true);
		playerHealthBar.SetActive(false);
		GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject go in enemy)
		{
			go.SetActive(false);
		}
	}

}

