using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {
int xpos;
//FIX!!!!!!!!!!!!!!!!bgSpeed!!!!!!!!!!!!!!
float bgSpeed;
float width;
Vector3 bg_size;
public BackManager bmg;
	// Use this for initialization
	void Start () {
		bmg=this.transform.parent.gameObject.GetComponent<BackManager>();
		// SpriteをPrefabとしてLoad
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		bgSpeed=0.01f; 
		Vector3 bottomRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    // 上下反転させる
    	bottomRight.Scale(new Vector3(1f, -1f, 1f));
    	width=bottomRight.x;
    	bg_size=renderer.bounds.size;
	}
	
	// Update is called once per frame
	void Update () {
		Scroll();
	}
	void Scroll(){
		Vector3 pos = transform.position;
		pos.x=pos.x+bgSpeed;
		//Debug.Log(pos.x);
		if(pos.x>width+bg_size.x/2){
			Debug.Log(pos.x);
			float ePos=bmg.GetLeftEdgePoint();
			pos.x=ePos-bg_size.x+0.05f;
		 }
		transform.position=pos;
	}

}

