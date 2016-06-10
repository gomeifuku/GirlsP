using UnityEngine;
using System.Collections;

public class TwitterButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//FIX::Playerがやられたときに表示されるように
	//FIX::アタッチされてるbuttonオブジェクトのタグによりツイートする内容を変える
	//FIX::scoreをツイートするためにGameManagerクラスをゲットする

	public void onClick(){
		int score=Camera.main.transform.gameObject.GetComponent<GameManager>().GetScore();
		Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL("これはテスト投稿です "+score.ToString()+"#がるぱんいいぞ"));
	}
}
