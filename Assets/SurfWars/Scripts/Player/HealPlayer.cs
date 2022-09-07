using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{

	private PlayerController thePlayer;
	public AudioSource healthSound;

	// Use this for initialization
	void Start()
	{
		thePlayer = FindObjectOfType<PlayerController>();
	}
	//if the player touches it and is damaged they will pickup the object and get 1 health
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && thePlayer.currentHealth < thePlayer.maxHealth)
		{
			healthSound.Play();
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			thePlayer.ChangeHealth(1);
			Destroy(gameObject, 1);
		}

	}
}