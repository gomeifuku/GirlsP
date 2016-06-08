using UnityEngine;
using System.Collections;

public class AnimeTest : MonoBehaviour {
	public Sprite[] frames;
	float framePerSecond=60.0f;

	SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		sr= GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		int index =(int)(Time.time*framePerSecond);
		index = index% frames.Length;
		sr.sprite=frames[index];
	
	}
}
