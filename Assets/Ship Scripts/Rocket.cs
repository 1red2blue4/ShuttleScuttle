using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
	public float rocketForce;
	public bool on;
	public bool upwards;
	GameObject com;
	// Use this for initialization
	void Start () {
		com = GameObject.Find ("Center of Mass");
		transform.GetChild(0).gameObject.SetActive(true);
		on=false;
	}
	
	// Updates and checks every frame whether to run or not
	void FixedUpdate () {
		if(transform.parent==null){
			return;
		}
		if (rocketForce <= 0) {
			rocketForce = 0;
			transform.GetChild (0).GetComponent<ParticleSystem> ().Stop ();
		}
		Vector3 localForward = (transform.position - transform.GetChild(0).transform.position).normalized;
		RaycastHit hit;

		if (Physics.Raycast(transform.position,localForward*-1, out hit, 1,~(1<<12))) 
		if(hit.collider.transform.GetComponent<Weight>()){
			transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
			on=false;
			return;
		}
		if(!on){
		transform.GetChild(0).GetComponent<ParticleSystem>().Play();
			on=true;
		}
			
	}

	//Helper function to check if rocket is on or not when reset() is called
	public void checkOn(){
		Vector3 localForward = (transform.position - transform.GetChild(0).transform.position).normalized;
		RaycastHit hit;

		if (Physics.Raycast(transform.position,localForward*-1, out hit, 1,~(1<<12))) {
			
		if(hit.collider.transform.GetComponent<Weight>()){
				
			transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
			on=false;
			return;
		}
		}
		if(!on){
			transform.GetChild(0).GetComponent<ParticleSystem>().Play();
			on=true;
		}
	}
}
