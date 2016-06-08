using UnityEngine;
using System.Collections;
public class EnemiesScript : MonoBehaviour {
	public GameObject sideGoj;
	public SideScript sideS;
	// Use this for initialization
	void Start () {
		sideS=sideGoj.GetComponent<SideScript>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
