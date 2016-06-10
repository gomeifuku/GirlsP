using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackManager : MonoBehaviour {
	List<GameObject> backList;
	// Use this for initialization
	void Start () {
		backList = GetAllChildren.GetAll(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}
	//一番左端のBackのGameObjectがいるpositionを返す
	public float GetLeftEdgePoint(){
		float ePos=10;
		foreach(GameObject ob in backList){
			if(ePos>ob.transform.position.x){
				ePos=ob.transform.position.x;
			}
		}
			return ePos;
	}
}
