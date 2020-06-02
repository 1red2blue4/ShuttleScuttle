using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USELESS
public class SphereHamster : MonoBehaviour {
	public int movement;
	public float counter;
	private int procedural;
	public GameObject TargetMaster;
	// Use this for initialization
	void Start () {
		transform.rotation=Quaternion.Euler(0,0,0);
		procedural=Random.Range(0,9);
		procedural*=10;
		procedural+=Random.Range(0,9);
		procedural*=10;
		procedural+=Random.Range(0,9);
		if(movement==3){
			TargetMaster.GetComponent<TargetMaster>().scaleSpiral(procedural);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position==new Vector3(100,1000,100)){
			counter=0;
		}
		if(movement==1){
			moveone();
		}
		if(movement==2){
			movetwo();
		}
		if(movement==3){
			movethree();
		}
		if(movement==4){
			movefour();
		}
		if(movement==5){
			movefive();
		}

	}

	void moveone(){
		float amplitude=0;
		float speed=0;
		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		foreach (object o in obj)
		{
			Transform temp = ((GameObject) o).transform;
			if(temp.GetComponent<CubeProperties>() && temp.GetComponent<BoxCollider>().enabled){
				if(temp.GetComponent<CubeProperties>().color=="blue"){
					speed+=1;
				}
				if(temp.GetComponent<CubeProperties>().pattern=="polka"){
					amplitude+=2f;
				}
			}
		}
		if(amplitude*Mathf.Sin(counter/10)>0)
			transform.position=new Vector3(transform.position.x+speed/5,1000+amplitude*Mathf.Sin(counter/10),101);
		else
			transform.position=new Vector3(transform.position.x+speed/5,1000,101);
		counter++;
	}

	void movetwo(){
		float amplitudeY=0;
		float amplitudeZ=0;
		float speed=0;
		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		foreach (object o in obj)
		{
			Transform temp = ((GameObject) o).transform;
			if(temp.GetComponent<CubeProperties>() && temp.GetComponent<BoxCollider>().enabled){
				if(temp.GetComponent<CubeProperties>().color=="red"){
					speed+=1;
				}
				amplitudeY+=temp.transform.position.y;
				amplitudeZ+=temp.transform.position.z;
			}
		}
		transform.position=new Vector3(transform.position.x+speed/5,1000+amplitudeY*Mathf.Sin(counter/10),101+amplitudeZ*Mathf.Cos(counter/10));
		counter++;
	}

	void movethree(){
		float amplitudeY=0;
		float amplitudeZ=0;
		float speed=0;
		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		foreach (object o in obj)
		{
			Transform temp = ((GameObject) o).transform;
			if(temp.GetComponent<CubeProperties>() && temp.GetComponent<BoxCollider>().enabled){
				int first=procedural/100;
				int second=(procedural/10)%10;
				int third=procedural%10;
				switch(first){
				case 0:
					if(temp.GetComponent<CubeProperties>().color=="red") speed+=1;
					break;
				case 1:
					if(temp.GetComponent<CubeProperties>().color=="blue") speed+=1;
					break;
				case 2:
					if(temp.GetComponent<CubeProperties>().color=="green") speed+=1;
					break;
				case 3:
					if(temp.GetComponent<CubeProperties>().color=="neutral") speed+=1;
					break;
				case 4:
					if(temp.GetComponent<CubeProperties>().pattern=="polka") speed+=1;
					break;
				case 5:
					if(temp.GetComponent<CubeProperties>().pattern=="checker") speed+=1;
					break;
				case 6:
					if(temp.GetComponent<CubeProperties>().pattern=="neutral") speed+=1;
					break;
				case 7:
					if(temp.position.x>0) speed+=1;
					if(temp.position.x<0) speed-=1;
					break;
				case 8:
					if(temp.position.y>0) speed+=1;
					if(temp.position.y<0) speed-=1;
					break;
				case 9:
					if(temp.position.z>0) speed+=1;
					if(temp.position.z<0) speed-=1;
					break;
				}

				switch(second){
				case 0:
					if(temp.GetComponent<CubeProperties>().color=="red") amplitudeY+=1;
					break;
				case 1:
					if(temp.GetComponent<CubeProperties>().color=="blue") amplitudeY+=1;
					break;
				case 2:
					if(temp.GetComponent<CubeProperties>().color=="green") amplitudeY+=1;
					break;
				case 3:
					if(temp.GetComponent<CubeProperties>().color=="neutral") amplitudeY+=1;
					break;
				case 4:
					if(temp.GetComponent<CubeProperties>().pattern=="polka") amplitudeY+=1;
					break;
				case 5:
					if(temp.GetComponent<CubeProperties>().pattern=="checker") amplitudeY+=1;
					break;
				case 6:
					if(temp.GetComponent<CubeProperties>().pattern=="neutral") amplitudeY+=1;
					break;
				case 7:
					if(temp.position.x>0) amplitudeY+=1;
					if(temp.position.x<0) amplitudeY-=1;
					break;
				case 8:
					if(temp.position.y>0) amplitudeY+=1;
					if(temp.position.y<0) amplitudeY-=1;
					break;
				case 9:
					if(temp.position.z>0) amplitudeY+=1;
					if(temp.position.z<0) amplitudeY-=1;
					break;
				}

				switch(third){
				case 0:
					if(temp.GetComponent<CubeProperties>().color=="red") amplitudeZ+=1;
					break;
				case 1:
					if(temp.GetComponent<CubeProperties>().color=="blue") amplitudeZ+=1;
					break;
				case 2:
					if(temp.GetComponent<CubeProperties>().color=="green") amplitudeZ+=1;
					break;
				case 3:
					if(temp.GetComponent<CubeProperties>().color=="neutral") amplitudeZ+=1;
					break;
				case 4:
					if(temp.GetComponent<CubeProperties>().pattern=="polka") amplitudeZ+=1;
					break;
				case 5:
					if(temp.GetComponent<CubeProperties>().pattern=="checker") amplitudeZ+=1;
					break;
				case 6:
					if(temp.GetComponent<CubeProperties>().pattern=="neutral") amplitudeZ+=1;
					break;
				case 7:
					if(temp.position.x>0) amplitudeZ+=1;
					if(temp.position.x<0) amplitudeZ-=1;
					break;
				case 8:
					if(temp.position.y>0) amplitudeZ+=1;
					if(temp.position.y<0) amplitudeZ-=1;
					break;
				case 9:
					if(temp.position.z>0) amplitudeZ+=1;
					if(temp.position.z<0) amplitudeZ-=1;
					break;
				}
			}
		}
		transform.position=new Vector3(transform.position.x+speed/5,1000+amplitudeY*Mathf.Sin(counter/10),101+amplitudeZ*Mathf.Cos(counter/10));
		counter++;
	}
	void movefour(){
		float amplitudeY=0;
		float amplitudeZ=0;
		float speed=0;
		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		foreach (object o in obj)
		{
			Transform temp = ((GameObject) o).transform;
			if(temp.GetComponent<CubeProperties>() && temp.GetComponent<BoxCollider>().enabled){
				int first=procedural/100;
				int second=(procedural/10)%10;
				int third=procedural%10;
				speed=2;

				amplitudeY=2;

				switch(third){
				case 0:
					if(temp.GetComponent<CubeProperties>().color=="red") amplitudeZ+=1;
					break;
				case 1:
					if(temp.GetComponent<CubeProperties>().color=="blue") amplitudeZ+=1;
					break;
				case 2:
					if(temp.GetComponent<CubeProperties>().color=="green") amplitudeZ+=1;
					break;
				case 3:
					if(temp.GetComponent<CubeProperties>().color=="neutral") amplitudeZ+=1;
					break;
				case 4:
					if(temp.GetComponent<CubeProperties>().pattern=="polka") amplitudeZ+=1;
					break;
				case 5:
					if(temp.GetComponent<CubeProperties>().pattern=="checker") amplitudeZ+=1;
					break;
				case 6:
					if(temp.GetComponent<CubeProperties>().pattern=="neutral") amplitudeZ+=1;
					break;
				case 7:
					if(temp.position.x>0) amplitudeZ+=1;
					if(temp.position.x<0) amplitudeZ-=1;
					break;
				case 8:
					if(temp.position.y>0) amplitudeZ+=1;
					if(temp.position.y<0) amplitudeZ-=1;
					break;
				case 9:
					if(temp.position.z>0) amplitudeZ+=1;
					if(temp.position.z<0) amplitudeZ-=1;
					break;
				}
			}
		}
		transform.position=new Vector3(transform.position.x+speed/5,1000+amplitudeY*Mathf.Sin(counter/10),101+amplitudeZ*Mathf.Cos(counter/10));
		counter++;
	}

	void movefive(){
		float amplitudeY=0;
		float amplitudeZ=0;
		float speed=0;
		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		foreach (object o in obj)
		{
			Transform temp = ((GameObject) o).transform;
			if(temp.GetComponent<CubeProperties>() && temp.GetComponent<BoxCollider>().enabled){
				int first=procedural/100;
				int second=(procedural/10)%10;
				int third=procedural%10;
				speed=2;

				switch(second){
				case 0:
					if(temp.GetComponent<CubeProperties>().color=="red") amplitudeY+=1;
					break;
				case 1:
					if(temp.GetComponent<CubeProperties>().color=="blue") amplitudeY+=1;
					break;
				case 2:
					if(temp.GetComponent<CubeProperties>().color=="green") amplitudeY+=1;
					break;
				case 3:
					if(temp.GetComponent<CubeProperties>().color=="neutral") amplitudeY+=1;
					break;
				case 4:
					if(temp.GetComponent<CubeProperties>().pattern=="polka") amplitudeY+=1;
					break;
				case 5:
					if(temp.GetComponent<CubeProperties>().pattern=="checker") amplitudeY+=1;
					break;
				case 6:
					if(temp.GetComponent<CubeProperties>().pattern=="neutral") amplitudeY+=1;
					break;
				case 7:
					if(temp.position.x>0) amplitudeY+=1;
					if(temp.position.x<0) amplitudeY-=1;
					break;
				case 8:
					if(temp.position.y>0) amplitudeY+=1;
					if(temp.position.y<0) amplitudeY-=1;
					break;
				case 9:
					if(temp.position.z>0) amplitudeY+=1;
					if(temp.position.z<0) amplitudeY-=1;
					break;
				}

				switch(third){
				case 0:
					if(temp.GetComponent<CubeProperties>().color=="red") amplitudeZ+=1;
					break;
				case 1:
					if(temp.GetComponent<CubeProperties>().color=="blue") amplitudeZ+=1;
					break;
				case 2:
					if(temp.GetComponent<CubeProperties>().color=="green") amplitudeZ+=1;
					break;
				case 3:
					if(temp.GetComponent<CubeProperties>().color=="neutral") amplitudeZ+=1;
					break;
				case 4:
					if(temp.GetComponent<CubeProperties>().pattern=="polka") amplitudeZ+=1;
					break;
				case 5:
					if(temp.GetComponent<CubeProperties>().pattern=="checker") amplitudeZ+=1;
					break;
				case 6:
					if(temp.GetComponent<CubeProperties>().pattern=="neutral") amplitudeZ+=1;
					break;
				case 7:
					if(temp.position.x>0) amplitudeZ+=1;
					if(temp.position.x<0) amplitudeZ-=1;
					break;
				case 8:
					if(temp.position.y>0) amplitudeZ+=1;
					if(temp.position.y<0) amplitudeZ-=1;
					break;
				case 9:
					if(temp.position.z>0) amplitudeZ+=1;
					if(temp.position.z<0) amplitudeZ-=1;
					break;
				}
			}
		}
		transform.position=new Vector3(transform.position.x+speed/5,1000+amplitudeY*Mathf.Sin(counter/10),101+amplitudeZ*Mathf.Cos(counter/10));
		counter++;
	}

}
