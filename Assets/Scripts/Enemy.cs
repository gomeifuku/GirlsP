using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour {
	[SerializeField]
	 private GameObject player;
	 public float speed;
	 private SideScript sideS;
	 private SpriteRenderer sr;
	 public Sprite neutralSprite;
	 public Sprite defeatedSprite;
	 private string state;
	 private float effectTime=1.3f;
	 private bool isAlive;
	// Use this for initialization
	void Start () {
		isAlive=true;
		sr=GetComponent<SpriteRenderer>();
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
			if(isAlive){
				sideS.redCount(state);
				Camera.main.GetComponent<GameManager>().AddScore();
				isAlive=false;
			}
			StartCoroutine(DefeatedEffect());
		}
		if(other.tag=="Player"){
			sideS.GameOver();
			
		}
	}
	public void SetSpeed(float sp){
		speed=sp;
	}
	IEnumerator DefeatedEffect(){
		float currentTime=Time.time;
		sr.sprite=defeatedSprite;
		GetComponent<Rigidbody2D>().velocity=transform.up*0;
		while(true){
			if(Time.time-currentTime>effectTime){
				Destroy(gameObject);
			}
			yield return new WaitForSeconds(effectTime);
		}
	}
}
