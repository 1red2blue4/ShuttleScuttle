using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USELESS!!!!!!!!! NOTE USELESS!!!!!!!
public class Goal : MonoBehaviour {
	
	public GameObject victoryScreen;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision collision) {


		if(collision.transform.name=="Center of Mass"){
			victoryScreen.SetActive(true);
		}
	}
}
