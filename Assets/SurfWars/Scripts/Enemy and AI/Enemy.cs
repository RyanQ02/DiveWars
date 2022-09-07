using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private PlayerController thePlayer;
	public GameObject death;
	public GameObject mainBodyArea;

	public float speed = 0.3f;
	
	public float timeTrigger;

	private Rigidbody2D myRigidbody;

	public int health = 100;

	public AudioSource killed;


	
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();	
		myRigidbody = GetComponent<Rigidbody2D> ();
		
		timeTrigger = 3f;
		 
	}

    private void Update()
    {
        
    }

    // When Spear or Rush is within the collider of the Enemy then Damage is done.
    void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Player" && thePlayer.rushing){
			TakeDamage(30);
		}

	}

	// Health is reduced when damage from the Spear prefab or rushing is done.
	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			killed.Play();
			Die();
		}
	}
	
	// When Health is 0, Enemy Game Object will be destroyed and the score counter will go up by 1.
	void Die()
	{
		mainBodyArea.GetComponent<SpriteRenderer>().enabled = false;
		Destroy(mainBodyArea, 0.2f);
		Destroy(gameObject, 0.2f);
		Score.scoreValue += 1;
	}
}
