using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USELESS
public class UIController : MonoBehaviour {
	public GameObject camera;
	public int screen; //0==place 1====roll
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool placing=camera.GetComponent<CameraPivot>().placing;

		switch (screen)
		{
		case 0:
			if(placing){
				foreach(Transform child in transform){
					child.gameObject.SetActive(true);
				}
			}
			else{
				foreach(Transform child in transform){
					child.gameObject.SetActive(false);
				}
			}
			break;
		case 1:
			
			if(!placing){
				foreach(Transform child in transform){
					child.gameObject.SetActive(true);
				}
			}
			else{
				foreach(Transform child in transform){
					child.gameObject.SetActive(false);
				}
			}
			break;
		}
	}
}
