using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USELESS
public class Avoid : MonoBehaviour {
	private int counter;
	// Use this for initialization
	void Start () {
		counter=0;
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, .7f);
		int i = 0;
		if(hitColliders.Length>0){
			counter=10;

		}
		if(counter>0){
			counter--;
		}
		if(counter==1){
			transform.parent.GetComponent<TargetMaster>().reset();
		}
	}

}
