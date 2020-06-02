using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Apply to new part prefab
public class CubeProperties : MonoBehaviour {
	public string color;
	public string pattern;
	//Add new material where necessary if new part is added
	public Material rocket;
	public Material steel;
	public Material cement;
	public Material rocketBack;
	public Material rocketFront;

	Color p,g,w;
	//Rocket
	//Steel
	//Cement
	// Use this for initialization
	void Start () {
		Color p = new Color (1, 0, 1, 1);
		Color g = Color.green;
		Color w = Color.white;
	}

	
	// Update is called once per frame
	void Update () {
		if (color == "white") {
			gameObject.tag = "White";
		} else if (color == "purple") {
			gameObject.tag = "Purple";
		} else if(color=="green"){
			gameObject.tag = "Green";
		}
		//if(gameObject.GetComponent<Breaker>())
			//gameObject.AddComponent<Breaker> ();
		bool transparent=!transform.GetComponent<BoxCollider>().enabled;
		int i = 0;
		if(pattern=="rocket"){
			foreach (Transform obj in transform) {
				if (i == 0)
					continue;
				else if(i==5)
					transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material=rocketBack;
				else if(i==6)
					transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material=rocketFront;
				else
					transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material=rocket;
				i++;
			}
		}
		else if(pattern=="cement"){
			transform.GetComponent<MeshRenderer>().material=cement;
		}
		else{
			transform.GetComponent<MeshRenderer>().material=steel;
		}

		if(color=="purple"){
			if (transparent) {
				if(pattern!="rocket")
					transform.GetComponent<MeshRenderer> ().material.color = new Color (1, 0, 1, 0.5f);
				else
					transform.GetChild(1).GetComponent<MeshRenderer> ().material.color = new Color (1, 0, 1,0.25f);

			} else {
				if(pattern!="rocket")
					transform.GetComponent<MeshRenderer> ().material.color = new Color (1, 0, 1, 1f);
				else
					transform.GetChild(1).GetComponent<MeshRenderer> ().material.color = new Color (1, 0, 1,0.25f);
			}
		}
		else if(color=="green"){
			if (transparent) {
				
				if(pattern!="rocket")
					transform.GetComponent<MeshRenderer> ().material.color = new Color (0, 1, 0, 0.5f);
				else
					transform.GetChild(1).GetComponent<MeshRenderer> ().material.color = new Color (0, 1, 0,0.25f);
				
			} else {
				
				if(pattern!="rocket")
					transform.GetComponent<MeshRenderer> ().material.color = new Color (0, 1, 0, 1f);
				else
					transform.GetChild(1).GetComponent<MeshRenderer> ().material.color = new Color (0, 1, 0,0.25f);

			}
		}
		else if(color=="white"){
			if (transparent) {
				
				if(pattern!="rocket")
					transform.GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1, 0.5f);
				else
					transform.GetChild(1).GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1,0.25f);

			} else {
				
				if(pattern!="rocket")
					transform.GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1, 1f);
				else
					transform.GetChild(1).GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1,0.25f);
			
			}
		}
	}
}
