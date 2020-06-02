using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//APPLY to ALL parts EXCEPT Cockpit
public class Breaker : MonoBehaviour {

	GameObject com;
	// Use this for initialization
	void Start () {
		com = GameObject.Find ("Ship");
		//if (com != null)
			//Debug.Log ("Hello");
	}
	
	// Break if contact is made with same colored screen
	void Update () {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.8f);
		int j = 0;
		while (j < hitColliders.Length)
		{
			if(hitColliders[j].tag==transform.tag && hitColliders[j].transform!=transform && hitColliders[j].transform.parent!=transform.parent){
			if(transform.parent==null){
				return;
			}
			GameObject CockPit=transform.parent.gameObject;
			
				GetComponent<BoxCollider> ().enabled = false;
				if(GetComponent<Weight>())
					Destroy (GetComponent<Weight> ());
				transform.parent = null;
				Destroy (com.GetComponent<Rigidbody> ());
				CockPit.transform.parent.GetComponent<CockPit>().reset();
				//Debug.Log ("Hit");
			}
			j++;
		}
			
	}


}
