using UnityEngine;
using System.Collections;

public class TitleAnimeScript : MonoBehaviour {
//15秒ごとに秋山がタイトルからランダムでセリフを喋る(うおー血が騒ぐであります！秋山流の力をみせてやるであります！)
	// Use this for initialization
	public GameObject Akiyama;
	public Sprite[] MessageSprite;
	private SpriteRenderer sr;
	private const float WAITTIME=15.0f;
	private float timeLeft;
	void Start () {
		timeLeft=WAITTIME;
		sr=GetComponent<SpriteRenderer>();
		sr.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
	//15秒ごとにコルーチンスタート
		timeLeft-= Time.deltaTime;
		if(timeLeft<=0.0){
			Debug.Log("実行されたよ");
			AkiyamaAnimation();
			timeLeft=WAITTIME;
		}
	}
	void AkiyamaAnimation(){
		SetAkiyama();
		StartCoroutine("ScrollAkiyama");
		StartCoroutine("AnimateAkiyamaMessage");
	}
	void SetAkiyama(){
		Vector3 pos = Akiyama.transform.position;
		pos.x=6f;
		Akiyama.transform.position=pos;
	}
	private IEnumerator ScrollAkiyama(){
		Vector3 pos = Akiyama.transform.position;
		while(pos.x > - 6.0f){
			pos.x-=0.1f;
			Akiyama.transform.position=pos;
			yield return null;  
		}
	
	}
	private IEnumerator AnimateAkiyamaMessage(){
		//指定されたポジションにスプライトを表示、一定秒後に消える
		yield return new WaitForSeconds(1.0f);
		int messeageNum= Random.Range(0, MessageSprite.Length);
		sr.sprite=MessageSprite[messeageNum];
		sr.enabled=true;
		yield return new WaitForSeconds(2.0f);
		sr.enabled=false;
	}
}
