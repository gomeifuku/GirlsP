using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	[SerializeField]
	 GameObject player;
	 public float speed;
	// Use this for initialization
	void Start () {
		speed=0.2f;
		transform.LookAt2D(player.transform,Vector2.up);

		GetComponent<Rigidbody2D>().velocity=transform.up*speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Bullet"){
			Debug.Log("HIT");
			Destroy(gameObject);
			Camera.main.GetComponent<GameManager>().AddScore();
		}
	}
}
