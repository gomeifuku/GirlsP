using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public AudioClip intro;
    public AudioClip loop;

    AudioSource[] audioSource = new AudioSource[2];

	public GameObject enemy;
	public float radius;
	public float totalTime=0;
	private float nextPopTime=0;
	public float y_offset;
	[SerializeField, Range(0.2f, 3f)]
	private float nextPopInterval;

	public Text scoreText; //Text用変数
	private int score = 0; //スコア計算用変数
	
	// Use this for initialization
	void Start () {
		nextPopInterval=2.0f;

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
		radius=4f;
	}
	
	// Update is called once per frame
	void Update () {
			scoreText.text = "Score: "+score.ToString();
			totalTime += Time.deltaTime;
			PopCharManager();
		
	}
	void PopCharManager(){
		if(totalTime >nextPopTime){
			Instantiate(enemy, GetPosition(), Quaternion.identity);
			nextPopTime+=Random.Range(nextPopInterval,nextPopInterval+0.3f);
		}
	}
	public Vector3 GetPosition() {
		float angle=Random.Range(0, 360);
	    float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
	    float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
	    return new Vector3 (x, y, 0);
	}
	public void AddScore(){
		score++;
	}

}
