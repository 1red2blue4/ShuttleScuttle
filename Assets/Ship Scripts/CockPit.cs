using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bryan Code mostly untouched
public class CockPit : MonoBehaviour {
	private int counter;
	public Vector3 rotVelocity;
	public Vector3 forwardVelocity;
	public Vector3 rotation;
	public float weight;
	public GameObject ship;
	public float timeStep;
	public bool gravity;
	public float gravityVal=1;
	public bool _fallThrough;
	private Vector3 numerator=Vector3.zero;
	private float demonimator=0.0f;
	public bool _gameOver = false;
	float t=0.0f;
	// Use this for initialization
	void Start () {
		gravity=true;
		counter=2;
		rotation=new Vector3(0,0,0);
		forwardVelocity=new Vector3(0,0,0);
		rotVelocity=new Vector3(0,0,0);

	}


	void Update(){
		if(!gravity){//Make things fall
			gravityVal=1;
		}
		else{//Make things fall faster
			gravityVal+=.2f;
		}
		if(counter>0){//Not doing anything atm
			counter--;

		}
		if (gravityVal <= 0) {
			gravityVal = 0;
			gravity = false;
		} else {
			gravity = true;
		}
		if(forwardVelocity.x==0 && forwardVelocity.y==0 && forwardVelocity.z==0 && !_gameOver){//If not moving, reset
			reset();
		}
		else{
			rotation=new Vector3(rotation.x+rotVelocity.x*timeStep,rotation.y+rotVelocity.y*timeStep,rotation.z+rotVelocity.z*timeStep);//Rotate based on rotational velocity
			transform.rotation=Quaternion.Euler(rotation.x,rotation.y,rotation.z);//set rotation to calculated rotation
			//Note that storing your rotation in a local variable is very important, transform.rotation is inconsistent as a variable

			Vector3 relativeVelocity=Quaternion.Euler(rotation.x,rotation.y,rotation.z)*forwardVelocity;//Relative Velocity is your forward velocity turned to face the direction of the ship
			transform.position=new Vector3(transform.position.x+relativeVelocity.x*timeStep,transform.position.y+relativeVelocity.y*timeStep,transform.position.z+relativeVelocity.z*timeStep);
			//The above line moves the ship based on its relative forward velocity. This also takes into account the time step so you can speed up or slow down the whole system
			if(gravity)transform.position=new Vector3(transform.position.x,transform.position.y-gravityVal*timeStep,transform.position.z);//If you should be falling, fall
			if(transform.position.y<1 && !_fallThrough){//If you hit the ground
				transform.position=new Vector3(transform.position.x,1,transform.position.z);//Don't move below ground level
				rotation.x*=.8f;//Straighten out
				gravityVal*=.7f;//Slow your falling
			}
		}
		Collider[] collider = Physics.OverlapSphere (transform.position, 0.8f);
		int ind = 0;
		while (ind < collider.Length) {
			if (collider [ind].tag == "Pit") {
				_fallThrough = true;
				Debug.Log ("Game over");
			}
			if (collider [ind].tag == "Goal") {
				t += Time.deltaTime;
				foreach (Transform child in ship.transform) {
					if (child.GetComponent<Rocket> ()) {
						float f = child.GetComponent<Rocket> ().rocketForce;
						if(f>0)
							child.GetComponent<Rocket> ().rocketForce = f - Time.deltaTime*3;
					}
				}
				reset ();
				if (t > 10.0f) {
					Debug.Log ("You win");
				}
			}
			ind++;
		}
		//To make sure that the rocket fuel upwards pushes against weight
		foreach (Transform t in transform.GetChild(0)) {
			if (t.GetComponent<Rocket> () && t.GetComponent<Rocket>().on && t.GetComponent<Rocket>().upwards) {
				gravityVal = gravityVal - t.GetComponent<Rocket> ().rocketForce;
			}
		}
	}

	void AddMass(Transform target)
	{
		if (target.GetComponent<Weight> ()) {
			float targetWeight = target.GetComponent<Weight> ().weight;
			numerator += targetWeight * target.transform.position;
			//Debug.Log (target.transform.position+ "," + targetWeight);
			demonimator += targetWeight;
		}
	}

	public void reset(){//Calculate speed, center of mass, and mass
		
		transform.rotation=Quaternion.Euler(Vector3.zero);
		forwardVelocity=new Vector3(0,0,0);
		rotVelocity=new Vector3(0,0,0);

		ship.transform.parent=null;
		transform.parent=ship.transform.GetChild(0);
		transform.localPosition=new Vector3(0,0,0);
		transform.parent=null;
		numerator = new Vector3 (0, 0, 0);
		demonimator = 0.0f;

		for(int i=1;i<ship.transform.childCount;i++){
			Transform temp=ship.transform.GetChild(i);
			AddMass (temp);
		}
		transform.position = numerator / demonimator;

		for(int i=1;i<ship.transform.childCount;i++){
			Transform temp=ship.transform.GetChild(i);

			if(temp.GetComponent<Rocket>()){
				temp.GetComponent<Rocket>().checkOn();
				if(temp.GetComponent<Rocket>().on){
					Vector3 rocketDir;
					//Bryan Code
					rocketDir=new Vector3 (0,0,-1);
					rocketDir*=temp.GetComponent<Rocket> ().rocketForce;
					//end Bryan code

					Vector3 rocketVelocity=(Quaternion.Euler(temp.rotation.eulerAngles.x,temp.rotation.eulerAngles.y,temp.rotation.eulerAngles.z )*rocketDir);
					forwardVelocity+=rocketVelocity;

					Vector3 offset=transform.position-temp.position;

					rotVelocity += new Vector3 (rocketVelocity.y * offset.z + rocketVelocity.z * offset.y * -1,
						rocketVelocity.z * offset.x + rocketVelocity.x * offset.z * -1,
						rocketVelocity.x * offset.y + rocketVelocity.y * offset.x * -1);
					
				}
			}

		}


		ship.transform.parent=transform;
		counter=2;

		forwardVelocity=new Vector3(forwardVelocity.x/demonimator,forwardVelocity.y/demonimator,forwardVelocity.z/demonimator);
		transform.rotation=Quaternion.Euler(rotation.x,rotation.y,rotation.z);
	}
}
