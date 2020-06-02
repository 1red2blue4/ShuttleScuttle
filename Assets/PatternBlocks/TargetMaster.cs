using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USELESS
public class TargetMaster : MonoBehaviour {
	public GameObject camera1;
	public GameObject victoryScreen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool win=true;
		foreach(Transform child in transform){
			if(child.GetComponent<Collect>() && child.gameObject.activeSelf){
				win=false;
			}
		}
		if(win)victoryScreen.SetActive(true);
		float min=transform.GetChild(0).position.y;
		float max=transform.GetChild(0).position.y;
		foreach(Transform child in transform){
			if(child.position.y>max)max=child.position.y;
			if(child.position.y<min)min=child.position.y;
		}

		foreach(Transform child in transform){
			float colorVal=child.position.y;
			colorVal-=min;
			colorVal/=(max-min);
			colorVal+=.1f;
			colorVal*=.8f;
			if(child.GetComponent<MeshRenderer>())
			child.GetComponent<MeshRenderer>().material.color=new Color(.8f,0,.9f);
		}

	}

	public void reset(){
		foreach(Transform child in transform){
			child.gameObject.SetActive(true);
			camera1.transform.GetComponent<CameraPivot>().resetCamera();
		}
	}

	public void scaleSpiral(int procedural){
		int first=procedural/100;
		int second=(procedural/10)%10;
		int third=procedural%10;
		int scaleX=0;
		int scaleY=0;
		int scaleZ=0;
		if(first>6){
			scaleX=Random.Range(-5,5);
		}
		else{
			scaleX=Random.Range(1,5);
		}
		if(second==first){
			scaleY=scaleX;
		}
		else if(second>6){
			scaleY=Random.Range(-5,5);
		}
		else{
			scaleY=Random.Range(1,5);
		}
		if(third==second){
			scaleZ=scaleY;
		}
		else if(third==first){
			scaleZ=scaleX;
		}
		else if(third>6){
			scaleZ=Random.Range(-5,5);
		}
		else{
			scaleZ=Random.Range(1,5);
		}
		if(scaleX==0)scaleX=1;
		if(scaleY==0)scaleY=1;
		if(scaleZ==0)scaleZ=1;
		transform.localScale=new Vector3(scaleX,scaleY,scaleZ);
		foreach(Transform child in transform){
			if(child.GetComponent<Collect>())
			child.localScale=new Vector3(1f/scaleX,1f/scaleY,1f/scaleZ);
		}
	}
}
