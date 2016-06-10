using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public AudioClip intro;
    public AudioClip loop;

    AudioSource[] audioSource = new AudioSource[2];
    public GameObject Enemies;
	public GameObject enemyprefab;
	public float radius;

	public float totalTime;
	private float nextPopTime;
	public static float offsetX;
	private int step;
	public int nextStepScore=20;
	[SerializeField, Range(0.2f, 3f)]
	private float nextPopInterval;
	private float BASESPEED=0.15f;
	public Text scoreText; //Text用変数
	public Text highScoreText;
	private int score; //スコア計算用変数
	private int highScore=0;
	private string highScoreKey="HighScore";
	private int scorePool;
	public float enemySpeed;
	// Use this for initialization
	void Start () {
		step=1;
		totalTime=0;
		nextPopTime=0;
		score=0;
		scorePool=0;
		nextPopInterval=2.0f;
		radius=4.6f;
		enemySpeed=BASESPEED;
		scoreText.text = "Score: "+score.ToString();
		highScore=PlayerPrefs.GetInt(highScoreKey,0);
		highScoreText.text="Best: "+highScore.ToString();
		
		audioSource[0] = this.gameObject.AddComponent<AudioSource>();
        audioSource[1] = this.gameObject.AddComponent<AudioSource>();
    
        if(intro != null){
            audioSource[0].playOnAwake = false;
            audioSource[0].clip = intro;
            audioSource[0].Play();
            if(loop != null){
                audioSource[1].playOnAwake = false;
                audioSource[1].clip = loop;
                audioSource[1].loop = true;
                audioSource[1].PlayScheduled(AudioSettings.dspTime + intro.length);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
			CheckStep();
			float accelByScore=0.05f*step;//(score/nextStepScore);
			enemySpeed=BASESPEED+accelByScore;
			scoreText.text = "Score: "+score.ToString();
			highScoreText.text="Best: "+highScore.ToString();
			totalTime += Time.deltaTime;
			PopCharManager();
			if(Input.GetKey(KeyCode.Escape))
				Application.LoadLevel("Title");
		
	}
	void PopCharManager(){
		if(totalTime >nextPopTime){
			GameObject enemy= (GameObject)Instantiate(enemyprefab, GetPosition(), Quaternion.identity);
			enemy.GetComponent<Enemy>().SetSpeed(enemySpeed);
			enemy.transform.parent=Enemies.transform;
			nextPopTime+=Random.Range(nextPopInterval,nextPopInterval+0.3f);
		}
	}
	public Vector3 GetPosition() {
		float angle=Random.Range(0, 360);
	    float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
	    float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
	    return new Vector3 (x+offsetX, y, 0);
	}
	private void CheckStep(){
		if(scorePool>=nextStepScore*step){
			scorePool=scorePool-(nextStepScore*step);
			step++;
		}
	}
	public void AddScore(){
		score+=step;
		scorePool+=step;
	}
	public int GetScore(){
		return score;
	}
	static public void SetOffset(float offX){
		offsetX=offX;
	}
	public void SetHighScore(){
		if(highScore<score){
			PlayerPrefs.SetInt(highScoreKey, score);
			highScore=score;
			//おめでとうてきすぷらいとえふぇくとあってもいいよね
		}
	}
	public void DisplayGameOver(){
		MyCanvas canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<MyCanvas>();
		Debug.Log("TBcount::"+canvas.TBcount.ToString());
		for(int tbNum=canvas.TBcount;tbNum>0;tbNum--){

		   	canvas.SetActive("TB"+tbNum.ToString(), true);
		}

	}

}
