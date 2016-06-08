using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HowToPlayScript : MonoBehaviour {
	private enum StateType{
		TitleFig,
		Arrow,
		EndFig
	}
	public Sprite titleFig;
	public Sprite endFig;
	public SpriteRenderer sr;
	private StateType state;
	private string[] scenarios;
	public Text uiText;

	private Arrow arrow;
	private int currentStep;
	private float animatedRange=0.2f;
	// Use this for initialization
	void Start () {
		state=StateType.TitleFig;
		SetScenarios();
		arrow=transform.root.GetComponent<Arrow>();

		if(!arrow.CheckInCorrect())
			Debug.Log("Arrowを正しく設定してね");
		if(arrow.positions.Length!=scenarios.Length)
			Debug.Log("Textを正しく設定してね");
		//Debug.Log(transform.FindChild ("Child").gameObject.name);
		// sr=transform.FindChild ("Sprite").gameObject.GetComponent<SpriteRenderer>();
		sr.sprite=titleFig;
		currentStep=0;

		SetNextStep();
	}
	
	// Update is called once per frame
	void Update () {
		if(state == StateType.TitleFig){
			if(Input.GetMouseButtonDown(0)){
				sr.enabled=false;
				state=StateType.Arrow;
				SetNextStep();
			}
		}
		else if(state==StateType.Arrow){
			AnimateArrow();
			if(Input.GetMouseButtonDown(0)){
				if(currentStep>arrow.positions.Length-2){
					state=StateType.EndFig;
					sr.sprite=endFig;
					sr.enabled=true;
				}
				SetNextStep();
			}
		}else if(state==StateType.EndFig){
			if(Input.GetMouseButtonDown(0)){
				Application.LoadLevel("Title");
				SetNextStep();
			}
		}
	}
	void SetNextStep(){
		transform.position=arrow.positions[currentStep];
		transform.rotation = Quaternion.AngleAxis(arrow.rotations[currentStep], transform.forward);
		uiText.text=scenarios[currentStep];
		//stransform.Rotate(new Vector3(0,0,1), arrow.rotations[currentStep]);
	//回転させる
		currentStep++;
	}
	void AnimateArrow(){
		Vector3 scale =	transform.localScale;
		scale.x=(arrow.isContrast[currentStep-1] ? -1 : 1 );
		transform.localScale=scale;
		Vector3 pos= arrow.positions[currentStep-1];
		pos=new Vector3(pos.x+animatedRange*Mathf.Cos(Mathf.Deg2Rad*arrow.rotations[currentStep-1])*Mathf.Cos(Time.time*3.5f)-animatedRange,pos.y+animatedRange*Mathf.Sin(Mathf.Deg2Rad*arrow.rotations[currentStep-1])*Mathf.Cos(Time.time*3.5f)-animatedRange,pos.z);
		transform.position=pos;
	}
	void SetScenarios(){
		string[] st=new string[5];
		st[0]="はじめに";
		st[1]="ほおおおおお\nげfeojfijaogijaejgoiawjgoiewagｈづおえほふぃへわふぃおえうぉいｆふぇおいｆほいえうぉいふぉいｇｈヴぉいえｗｈごいえｗｈごいほいｖのしｚんばえ９ｐ＠ｊｋｆまぐぁ";
		st[2]="あべええふぁえあえｗ";
		st[3]="ほんとにほんとにほんとにほんとに";
		st[4]="ライオン";
		scenarios=st;
	}
}
