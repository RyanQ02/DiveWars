using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	private PlayerController thePlayer;

	public AudioSource hurtGroan;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();	
	}
	//if the player runs into an object with this script the player will take damage and play the hurt animation
	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Player"){
            if (!thePlayer.rushing)
            {
				hurtGroan.Play();
				thePlayer.hurt();
				thePlayer.ChangeHealth(-1);
			}				
		}

	}
}
