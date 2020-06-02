using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorToggle : MonoBehaviour {
	private GameObject cameraMaster;
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
		string colorName=cameraMaster.GetComponent<CameraPivot>().colorSelected;
		if(colorName=="purple"){
			transform.GetComponent<SpriteRenderer>().color=new Color(1,0,1);
		}
		else if(colorName=="green"){
			transform.GetComponent<SpriteRenderer>().color=new Color(0,1,0);
		}
		else{
			transform.GetComponent<SpriteRenderer>().color=new Color(1,1,1);
		}
	}
}
