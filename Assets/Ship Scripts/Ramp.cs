using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour {
	public int width;
	public int length;
	public int slope;
	public GameObject ship;
	public GameObject cam;
	private float angle;
	float oldAngle;
	float newAngle;
	// Use this for initialization
	void Start () {
	}

	//Ramp Physics to NOT be a cone, IRRESPECTIVE of weight. Change wdith and/or length if Ramp scale changes.
	void LateUpdate() {
			Vector3 orientationRamp = transform.forward;
			Vector3 VectorBetweenShipAndRamp = ship.transform.position - transform.position;
			oldAngle = Vector3.Angle (orientationRamp, VectorBetweenShipAndRamp);
			float angleThreshold = Mathf.Rad2Deg * Mathf.Atan2 (width, length);
			float angleBetween = Vector3.Angle (orientationRamp, VectorBetweenShipAndRamp);
			if (Mathf.Abs (ship.transform.position.x - transform.position.x) < width && Mathf.Abs (ship.transform.position.z - transform.position.z) < length && angleThreshold >= angleBetween && newAngle - oldAngle < 0) {
			ship.GetComponent<CockPit> ().rotation.x = ship.GetComponent<CockPit> ().rotation.x * .8f + .2f * slope;
			ship.GetComponent<CockPit> ().gravity = false;
			} else {
			ship.GetComponent<CockPit> ().gravity = true;
			}
			newAngle = oldAngle;
	}
}
