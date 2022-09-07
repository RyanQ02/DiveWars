using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour {

	public GameObject explosion;
	public AudioSource explode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player"){
			explode.Play();
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			Destroy (gameObject, 1);
			Instantiate (explosion, gameObject.transform.position, gameObject.transform.rotation);
		}	
	}
}
