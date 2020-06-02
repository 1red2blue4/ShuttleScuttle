using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
	//List<GameObject> stuff=new List<GameObject>();
	GameObject cPivot;
	// Use this for initialization
	void Start () {
		cPivot = GameObject.Find ("Camera Pivot");
	}
	
	// Update is called once per frame
	void Update () {
		
	} 

	//Very similar to Crash Wall EXCEPT particle system is doubled
	void OnCollisionEnter(Collision collision) {

		if(collision.transform.name=="Center of Mass"){
			Debug.Log ("Hello");
			foreach(Transform child in collision.transform.GetChild(0)){
				if (child.name != "Main Camera") {
					GameObject clone = Instantiate (child.gameObject,child.position,child.rotation);
					child.gameObject.SetActive (false);
					clone.gameObject.AddComponent<Rigidbody> ();
					clone.GetComponent<Rigidbody> ().mass = 1;
					Vector3 explosion = new Vector3 (Random.Range (-10, 10), Random.Range (-10, 10), Random.Range (-10, 10)) * 100;
					clone.transform.parent = null;
					clone.GetComponent<Rigidbody> ().AddForce (explosion);
					//Vector3 pos = clone.transform.localPosition;

					//clone.transform.position = pos;
					cPivot.GetComponent<CameraPivot>().residualPieces.Add (clone);
				} else {
					child.parent = collision.transform.GetChild(0).transform;
				}
			}
			collision.gameObject.GetComponent<CockPit> ().forwardVelocity = new Vector3 (0, 0, 0);
			collision.gameObject.GetComponent<CockPit> ()._gameOver = true;
			transform.GetChild (0).gameObject.SetActive (false);
			transform.GetChild (1).gameObject.GetComponent<ParticleSystem> ().Play ();
			transform.GetChild (2).gameObject.GetComponent<ParticleSystem> ().Play ();
			transform.GetChild (1).gameObject.transform.position = collision.contacts [0].point;
			transform.GetChild (2).gameObject.transform.position = collision.contacts [0].point;
		}
	}
}
