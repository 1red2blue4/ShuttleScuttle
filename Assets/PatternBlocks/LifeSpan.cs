using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//USELESS
public class LifeSpan : MonoBehaviour {
	private int counter;
	// Use this for initialization
	void Start () {
		counter=0;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if(counter>60){
			Destroy(transform.gameObject);
		}
	}
}
