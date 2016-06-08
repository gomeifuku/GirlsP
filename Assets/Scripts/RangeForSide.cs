using UnityEngine;
using System.Collections;

public class RangeForSide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		//if(other.tag=="Enemy")
		//Debug.Log(tag+": Enter");

	}
	void OnTriggerStay2D(Collider2D other){
		//Debug.Log(tag+": Enter");
	}
	void OnTriggerExit2D(Collider2D other){
		//if(other.tag=="Enemy")
		//	Debug.Log(tag+": Exit");
	}
}
