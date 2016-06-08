using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour {
	[SerializeField]
	 private GameObject player;
	 public float speed;
	 private SideScript sideS;
	 private string state;
	// Use this for initialization
	void Start () {
		sideS=this.transform.parent.GetComponent<EnemiesScript>().sideS;
		transform.LookAt2D(player.transform,Vector2.up);

		GetComponent<Rigidbody2D>().velocity=transform.up*speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){

		if(other.tag=="Warning"||other.tag=="Caution"){
			sideS.addCount(other.tag);
			state=other.tag;
		}
		if(other.tag=="Bullet"){
			//Debug.Log("HIT");
			sideS.redCount(state);
			Destroy(gameObject);
			Camera.main.GetComponent<GameManager>().AddScore();
		}
		if(other.tag=="Player"){
			sideS.GameOver();
			
		}
	}
	public void SetSpeed(float sp){
		speed=sp;
	}
}
