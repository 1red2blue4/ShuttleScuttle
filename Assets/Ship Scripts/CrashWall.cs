using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashWall : MonoBehaviour {
	
	GameObject cPivot;
		// Use this for initialization
		void Start () {
		cPivot = GameObject.Find ("Camera Pivot");
		}

		// Update is called once per frame
		void Update () {

		} 
		//Blast everything to smithereens
		void OnCollisionEnter(Collision collision) {


			if(collision.transform.name=="Center of Mass"){
				
				foreach(Transform child in collision.transform.GetChild(0)){
				//Cloning parts and blasting each part
				if (child.name != "Main Camera") {
					GameObject clone = Instantiate (child.gameObject, child.transform.position,child.rotation);
					child.gameObject.SetActive (false);
					clone.gameObject.AddComponent<Rigidbody> ();
					clone.GetComponent<Rigidbody> ().mass = 1;
					Vector3 explosion = new Vector3 (Random.Range (-10, 10), Random.Range (-10, 10), Random.Range (-10, 10)) * 100;

					clone.transform.parent = null;

					clone.GetComponent<Rigidbody> ().AddForce (explosion);
					//Destroy the blasted pieces and detroy on pressing Q in Camera Pivot
					cPivot.GetComponent<CameraPivot>().residualPieces.Add (clone);
				} else {
					child.parent = collision.transform.GetChild(0).transform;
				}
				}
			//Partciles and post blasting code
			collision.gameObject.GetComponent<CockPit> ().forwardVelocity = new Vector3 (0, 0, 0);
			collision.gameObject.GetComponent<CockPit> ()._gameOver = true;
			transform.GetChild (0).gameObject.GetComponent<ParticleSystem> ().Play ();
			transform.GetChild (0).gameObject.transform.position = collision.contacts [0].point;
			}
		}
}
