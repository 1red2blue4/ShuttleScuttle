using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USELESS
public class Collect : MonoBehaviour {
	public GameObject particle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f);

		if(hitColliders.Length>0){
			Instantiate(particle,transform.position,Quaternion.Euler(-90,0,0));
			transform.gameObject.SetActive(false);
		}

	}
}
