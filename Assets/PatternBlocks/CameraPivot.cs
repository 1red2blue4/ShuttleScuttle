using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mostly Bryan Code but changes have been commented
/// </summary>//
public class CameraPivot : MonoBehaviour
{
	private Vector3 rotation;
	public GameObject target;
	private float camDistance;
	private bool normalSelected;
	public bool placing;
	public GameObject centerCube;
	public GameObject ship;
	public GameObject SphereHamster;
	public GameObject cubePrefab;
	public string colorSelected;
	public string patternSelected;
	public GameObject environment;
	public GameObject gtaCam;

	public GameObject rocketPrefab;
	public GameObject cementPrefab;
	public GameObject steelPrefab;
	GameObject ccClone;

	int rotCount=0;
	float lpDist=Mathf.Infinity;
	GameObject lastPiece;
	//Blasted pieces to cleanup when go back to edit mode
	public List<GameObject> residualPieces=new List<GameObject>();

	// Use this for initialization
	void Start ()
	{
		lastPiece = centerCube;
		camDistance=-7;
		placing = true;
		rotation = new Vector3 (0, 0, 0);
		target = Instantiate (steelPrefab);
	}
		
	private void moveBackToEdit()
	{
		camDistance=-7;
		SphereHamster.transform.rotation = Quaternion.Euler (0, 0, 0);
		transform.GetChild (0).localPosition = new Vector3 (0, 0, camDistance);
		placing = true;
		rotation = new Vector3 (0, 0, 0);
		target = Instantiate (steelPrefab);
		colorSelected = "white";
		patternSelected = "steel";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (placing) {//Placing
			gtaCam.gameObject.SetActive (false);
			SphereHamster.SetActive(false);//Deactivate Rolling Ball
			environment.SetActive(false);
			transform.GetChild (0).gameObject.SetActive (true);
			//Camera Control
			if(Input.GetMouseButton(0)){
			if (Input.mousePosition.x > (Screen.width * 2 / 3)) {
				rotation.y--;
			}
			if (Input.mousePosition.x < (Screen.width * 1 / 3)) {
				rotation.y++;
			}

			if (Input.mousePosition.y > (Screen.height * 2 / 3)) {
				rotation.x++;
			}
			if (Input.mousePosition.y < (Screen.height * 1 / 3)) {
				rotation.x--;
			}
			if (rotation.x > 30)
				rotation.x = 30;
			if (rotation.x < -30)
				rotation.x = -30;
			}
			transform.rotation = Quaternion.Euler (rotation.x, rotation.y, rotation.z);
			//Camera Control
			target.GetComponent<CubeProperties>().color=colorSelected;
			target.GetComponent<CubeProperties>().pattern=patternSelected;

			//Expand colors HERE!
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				switch(colorSelected){
				case "purple":
					colorSelected = "green";
					break;
				case "green":
					colorSelected = "white";
					break;
				case "white":
					colorSelected = "purple";
					break;
				}

			}

			//Expand parts HERE!
			if(Input.GetKeyDown(KeyCode.Alpha2)){
				switch(patternSelected){
				case "rocket":
					patternSelected = "cement";
					if (target != null) {
						Destroy (target);
						target = Instantiate (cementPrefab);
					}
					break;
				case "cement":
					patternSelected = "steel";
					if (target != null) {
						Destroy (target);
						target = Instantiate (steelPrefab);
					}
					break;
				case "steel":
					patternSelected = "rocket";
					if (target != null) {
						Destroy (target);
						target = Instantiate (rocketPrefab);
						target.transform.eulerAngles = new Vector3 (0, 180, 0);
					} 
					break;
				}

			}
			placeCubes();

			if(Input.GetMouseButtonDown (1)){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

				if (Physics.Raycast (ray, out hit, 500) && hit.transform!=centerCube.transform) {
					if(camDistance>=-7f)
						camDistance+=.4f;
					Destroy(hit.transform.gameObject);
				}
			}
			//Rotate for ROCKET
			if (Input.GetMouseButtonDown (2)) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit, 500)
					&& hit.transform.GetComponent<CubeProperties>() && hit.transform.gameObject.GetComponent<CubeProperties> ().pattern == "rocket") {
					rotCount++;
					if (rotCount <= 4) {
						hit.transform.rotation = Quaternion.Euler (0, 180 + 90 * rotCount, 0);
						hit.transform.GetComponent<Rocket> ().upwards = false;
					}
					else if (rotCount == 5) {
						hit.transform.rotation = Quaternion.Euler (90, 180, 0);
						hit.transform.GetComponent<Rocket> ().upwards = true;
					}
					else if (rotCount == 6) {
						hit.transform.rotation = Quaternion.Euler (-90, 180, 0);
						hit.transform.GetComponent<Rocket> ().upwards = false;
						rotCount = 0;
					}
				}
			}
			RaycastHit hit1;
			Ray ray1 = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray1, out hit1, 500)) {
				if (Input.GetMouseButtonDown (0) && target!=null && target.transform.position.x<200) {//Place Gear on Click
					target.GetComponent<BoxCollider> ().enabled = true;
					if (patternSelected == "steel") {
						target = Instantiate (steelPrefab);
					} else if (patternSelected == "cement") {
						target = Instantiate (cementPrefab);
					}
					else {
						target = Instantiate (rocketPrefab);
						target.transform.eulerAngles = new Vector3 (0, 180, 0);
					}
					rotCount = 0;
					camDistance-=.4f;
					transform.GetChild (0).localPosition = new Vector3 (0, 0, camDistance);
				}
			}
				
			if(Input.GetKeyDown(KeyCode.Q)){
				SphereHamster.GetComponent<CockPit> ().gravity = true;
				SphereHamster.GetComponent<CockPit> ()._fallThrough = false;
				SphereHamster.GetComponent<CockPit> ().rotation = new Vector3 (0, 0, 0);
				SphereHamster.GetComponent<CockPit> ().forwardVelocity = new Vector3 (0, 0, 0);
				SphereHamster.GetComponent<CockPit> ().rotVelocity = new Vector3 (0, 0, 0);
				SphereHamster.GetComponent<CockPit> ()._gameOver = false;
				SphereHamster.GetComponent<CockPit> ().gravityVal = 1;
				ship.SetActive (true);
				gtaCam.transform.localPosition = new Vector3 (0, 9.6f, 16.3f);
				Destroy(target);
				target=null;
				placing=false;
				//Setting position of Centre of Mass is HARDCODED! Change depending on level
				SphereHamster.transform.position=new Vector3(254.17f,7,240.9f);
				transform.GetChild(0).localPosition=new Vector3(0,0,-50);
				transform.rotation=Quaternion.Euler(0,0,0);
				SphereHamster.SetActive(true);
				Vector3 vReverse = new Vector3 (0, 180, 0);
				ccClone = Instantiate (centerCube);
				ccClone.transform.parent = ship.transform;
				ccClone.transform.localPosition = new Vector3 (0, 0, 0);
				ccClone.transform.localRotation = Quaternion.Euler (vReverse);
				foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject))) {
					if (obj.GetComponent<CubeProperties> () && obj.GetComponent<BoxCollider>().enabled) {
						GameObject objClone = Instantiate (obj);
						Vector3 pos = obj.transform.position;
						Vector3 angle = obj.transform.eulerAngles;
					
						objClone.AddComponent<Breaker> ();
						objClone.transform.parent = ship.transform;
						objClone.transform.localPosition = new Vector3(-pos.x,pos.y,-pos.z);
						objClone.transform.localRotation = Quaternion.Euler (angle.x,angle.y-180,0);

					}
				}

			}
		}



		else{//Rolling
			SphereHamster.SetActive(true);
			environment.SetActive (true);
			transform.GetChild (0).gameObject.SetActive (false);
			//Eagle view cam
			if (Input.GetKey (KeyCode.R)) {
				environment.transform.GetChild (0).gameObject.SetActive (true);
				gtaCam.gameObject.SetActive (false);
			} 
			//GTA Cam view
			else {
				environment.transform.GetChild (0).gameObject.SetActive (false);
				gtaCam.gameObject.SetActive (true);
			}
			object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
			if(Input.GetKeyDown(KeyCode.Q)){
				SphereHamster.GetComponent<CockPit> ().gravity = true;
				SphereHamster.GetComponent<CockPit> ().gravityVal = 1;
				SphereHamster.GetComponent<CockPit> ()._fallThrough = false;
				SphereHamster.GetComponent<CockPit> ().rotation = new Vector3 (0, 0, 0);
				SphereHamster.GetComponent<CockPit> ().forwardVelocity = new Vector3 (0, 0, 0);
				SphereHamster.GetComponent<CockPit> ().rotVelocity = new Vector3 (0, 0, 0);
				SphereHamster.GetComponent<CockPit> ()._gameOver = false;
				//Clean up
				foreach (GameObject go in residualPieces) {
					Destroy (go);
				}
				residualPieces.Clear ();
				foreach (object o in obj)
				{
					Transform temp = ((GameObject) o).transform;
					if (temp.GetComponent<CubeProperties> () && !temp.GetComponent<BoxCollider> ().enabled && temp.name != "Cockpit") {
						Destroy (temp.gameObject);
					}
					if (temp.GetComponent<Bomb> ()) {
						temp.transform.GetChild (0).gameObject.SetActive (true);
						temp.transform.GetChild (1).gameObject.GetComponent<ParticleSystem> ().Stop ();
						temp.transform.GetChild (2).gameObject.GetComponent<ParticleSystem> ().Stop ();
					}
				}
				for (int i = 1; i < ship.transform.childCount; i++) {
					Destroy (ship.transform.GetChild (i).gameObject);
				}
				//transform.parent=null;
				moveBackToEdit();
				placing=true;
			}
		}
	}

	public void resetCamera(){
		if(target!=null && !target.GetComponent<BoxCollider>().enabled){
			Destroy(target);
		}
		transform.parent=null;
		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		foreach (object o in obj)
		{
			GameObject g = (GameObject) o;
			if(g.transform.GetComponent<SphereHamster>()){
				g.transform.rotation=Quaternion.Euler(0,0,0);
			}
		}
		transform.position=new Vector3(0,0,0);
		transform.GetChild(0).localPosition=new Vector3(0,0,camDistance);
		target=null;
		target = Instantiate (cubePrefab);
		target.GetComponent<BoxCollider> ().enabled = false;
		placing=true;
	}

	private void placeCubes(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit, 500)) {
			Vector3 offset = hit.point - hit.transform.position;
			if (Mathf.Abs (offset.x) >= Mathf.Abs (offset.y) && Mathf.Abs (offset.x) >= Mathf.Abs (offset.z)) {
				if (offset.x > 0) {
					target.transform.position = new Vector3 (hit.transform.position.x + 1, hit.transform.position.y, hit.transform.position.z);
				} else {
					target.transform.position = new Vector3 (hit.transform.position.x - 1, hit.transform.position.y, hit.transform.position.z);
				}
			}
			if (Mathf.Abs (offset.y) >= Mathf.Abs (offset.x) && Mathf.Abs (offset.y) >= Mathf.Abs (offset.z)) {
				if (offset.y > 0) {
					target.transform.position = new Vector3 (hit.transform.position.x, hit.transform.position.y + 1, hit.transform.position.z);
				} else {
					target.transform.position = new Vector3 (hit.transform.position.x, hit.transform.position.y - 1, hit.transform.position.z);
				}
			}
			if (Mathf.Abs (offset.z) > Mathf.Abs (offset.y) && Mathf.Abs (offset.z) > Mathf.Abs (offset.x)) {
				if (offset.z > 0) {
					target.transform.position = new Vector3 (hit.transform.position.x, hit.transform.position.y, hit.transform.position.z + 1);
				} else {
					target.transform.position = new Vector3 (hit.transform.position.x, hit.transform.position.y, hit.transform.position.z - 1);
				}
			}

		}
		else{
			target.transform.position = new Vector3 (300,0,0);
		}
	}
}
