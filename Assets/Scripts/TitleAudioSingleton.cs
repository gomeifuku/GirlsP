using UnityEngine;
using System.Collections;

public class TitleAudioSingleton : MonoBehaviour {
	public AudioClip clip;
	private AudioSource source;

	private static TitleAudioSingleton instance = null;
	public static TitleAudioSingleton Instance{
		get{return instance;}
	}
	void Awake(){
		if(instance!=null&& instance!=this){
			Destroy(this.gameObject);
			return;
		}else{
			instance=this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	// Use this for initialization
	void Start () {
		source=gameObject.GetComponent<AudioSource>();
		source.clip=clip;
		source.loop=true;
		source.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
