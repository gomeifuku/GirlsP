using UnityEngine;
using System.Collections;
public class ButtonScript : MonoBehaviour {
	GameObject audioGoj;
	// Use this for initialization
	void Start () {
		audioGoj=GameObject.FindGameObjectWithTag("Audio");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick(){
		Debug.Log("Click");
		if(tag=="Start"){
			Application.LoadLevel("Main");
			Destroy(audioGoj);
		}
		if(tag=="Outline")
			Application.LoadLevel("Explain");
		if(tag=="HowTo")
			Application.LoadLevel("HowTo");
	}
}
