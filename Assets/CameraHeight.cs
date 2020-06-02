using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeight : MonoBehaviour {
	float height;
	public bool _rotChange=true;
	Vector3 prevRot;
	GameObject cockpit;
	float dist;
	// Use this for initialization
	void Start () {
		height = transform.position.y;
		cockpit = transform.parent.parent.gameObject;
		dist = (cockpit.transform.position - transform.position).z;
	}
	
	// To Lerp and pivot camera based on the ship's rotation and position. Also Lerp at different speeds to give zoom and pan effect.
	void Update () {


		//Vector3 pos = new Vector3 (transform.position.x, height, transform.position.z);
		transform.position = new Vector3 (transform.position.x, height, transform.position.z);//Vector3.Lerp (transform.position, pos, Time.deltaTime*5);
		Quaternion rot = Quaternion.Euler (new Vector3 (28f + cockpit.GetComponent<CockPit> ().rotation.x*1.2f, 180, 0));
		transform.localRotation = Quaternion.Lerp (transform.localRotation,rot,Time.deltaTime*10);
	}
}
