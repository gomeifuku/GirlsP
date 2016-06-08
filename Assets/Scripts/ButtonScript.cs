using UnityEngine;
using System.Collections;
public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick(){
		Debug.Log("Click");
		if(tag=="Start")
			Application.LoadLevel("Main");
		if(tag=="Outline")
			Application.LoadLevel("Explain");
		if(tag=="HowTo")
			Application.LoadLevel("HowTo");
	}
}
