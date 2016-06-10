using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float playerRotationZ;
	public float reloadedSpan;
	private float reloadingTime;
	private bool canFire;
	public GameObject bullet;
	SpriteRenderer sr;
	public Sprite neutralSprite;
	public Sprite firingSprite;
	public Sprite gameoverSprite;
	private bool isAlive;
	Ray2D ray;
	// Use this for initialization
	void Start () {
		GameManager.SetOffset(transform.position.x);
		isAlive=true;
		reloadedSpan=0.6f;
		reloadingTime=0;
		sr= GetComponent<SpriteRenderer>();
		canFire=true;
		playerRotationZ=8f;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isAlive){Debug.DrawRay((Vector2)transform.position, (Vector2)transform.up*5, Color.red);
			if(!canFire){
				reloadingTime+=Time.deltaTime;
				if(reloadingTime>reloadedSpan){
					reloadingTime=0;
					canFire=true;
					sr.sprite=neutralSprite;
				}
			}
			Shot();
			Move();
		}
	}
	void Move(){
		transform.Rotate(new Vector3(0f,0f,playerRotationZ));
	}
	void Shot(){
		if(Input.GetKey(KeyCode.Space)&&canFire){
			Instantiate(bullet,transform.position,transform.rotation);
			canFire=false;
			sr.sprite=firingSprite;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Enemy"&&isAlive){
			Debug.Log("yarareta");
			isAlive=false;
			sr.sprite=gameoverSprite;
			Camera.main.gameObject.GetComponent<GameManager>().SetHighScore();
			Camera.main.gameObject.GetComponent<GameManager>().DisplayGameOver();
		
		}

	}
	void OnGUI() {
		//FIX::キー入力で戻れるようにしたくね？スプライトで表示
		//Fix::そもそもそういうことはGameManagerでしね？
		if(!isAlive){
			int b_h=40;
			int b_w=80;
		    if ( GUI.Button(new Rect(Screen.width-(b_w*3/2), (Screen.height-b_h)/2, b_w, b_h), "Retry") ) {
		          Application.LoadLevel("Main");
		    }
		    if(GUI.Button(new Rect(b_w/2, (Screen.height-b_h)/2, b_w, b_h), "Title")){
		    	  Application.LoadLevel("Title");
		    }
		}
	}
}
