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
	private int score; //スコア計算用変数
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
		scoreText.text = "Score: 0";
		
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
			totalTime += Time.deltaTime;
			PopCharManager();
		
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
	static public void SetOffset(float offX){
		offsetX=offX;
	}

}
