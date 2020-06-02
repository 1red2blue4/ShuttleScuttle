using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USELESS
public class PatternToggle : MonoBehaviour {
	private GameObject cameraMaster;
	public Material rocket;
	public Material steel;
	public Material cement;
	// Use this for initialization
	void Start () {
		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		foreach (object o in obj)
		{
			GameObject g = (GameObject) o;
			if(g.transform.GetComponent<CameraPivot>())
				cameraMaster=g;
		}
	}

	// Update is called once per frame
	void Update () {
		string patternName=cameraMaster.GetComponent<CameraPivot>().patternSelected;
		if(patternName=="steel"){
			transform.GetComponent<MeshRenderer>().material=steel;
		}
		else if(patternName=="cement"){
			transform.GetComponent<MeshRenderer>().material=cement;
		}
		else{
			transform.GetComponent<MeshRenderer>().material=rocket;
		}
	}
}
