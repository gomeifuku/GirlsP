using UnityEngine;
using System.Collections;

public class SideScript : MonoBehaviour {
	private enum StatusType{
		Safe,
		Caution,
		Warning,
		GameOver
	}

	SpriteRenderer sr;
	public Sprite[] SideSprites; 
	private int warningCount;
	private int cautionCount;
	private bool isAlivePlayer;
	private StatusType prevStatus;
	private StatusType status;
	// Use this for initialization
	void Start () {
		isAlivePlayer=true;
		sr= GetComponent<SpriteRenderer>();
		prevStatus=StatusType.Safe;
		status=StatusType.Safe;

	}
	
	// Update is called once per frame
	void Update () {
			CheckStatus();
	}
	public void addCount(string tag){
		if(tag=="Warning"){
			warningCount++;
		}else if(tag=="Caution"){
			cautionCount++;
		}
		//Debug.Log("ADD::Caution"+cautionCount.ToString()+"Warning:"+warningCount.ToString());
	}
	public void redCount(string tag){
		if(tag=="Caution"){
			cautionCount--;
		}else if(tag=="Warning"){
			warningCount--;
			cautionCount--;
		}
		//Debug.Log("RED::Caution"+cautionCount.ToString()+"Warning:"+warningCount.ToString());
	}
	private void CheckStatus(){
		if(isAlivePlayer){
			status=SideStaus();
			if(prevStatus!=status){
				Debug.Log("CheckStatus::"+status.ToString());
				ChangeSideSprite(status);
			}
			prevStatus=status;
		}
		
	}
	private StatusType SideStaus(){
		if(warningCount!=0){
			return StatusType.Warning;
		}else if(cautionCount!=0){
			return StatusType.Caution;
		}
		return StatusType.Safe;
	}
	private void ChangeSideSprite(StatusType status){
		sr.sprite=SideSprites[(int)status];
	}
	public void GameOver(){
		isAlivePlayer=false;
		ChangeSideSprite(StatusType.GameOver);
		status=StatusType.GameOver;
	}
}

