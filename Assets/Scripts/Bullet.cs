using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed;
	public float lifeTime=1.0f;
	// Use this for initialization
	void Start () {
		speed=8f;

		GetComponent<Rigidbody2D>().velocity=transform.up*speed;

        // lifeTime秒後に削除
        Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
