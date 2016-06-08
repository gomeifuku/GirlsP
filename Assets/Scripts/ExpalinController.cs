using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ExpalinController : MonoBehaviour {
	private string[] scenarios;
	public Text uiText;
	[SerializeField][Range(0.001f, 0.3f)]
	float intervalForCharacterDisplay = 0.05f;	// 1文字の表示にかかる時間

	private string currentText;
	private float timeUntilDisplay;
	private float timeElapsed;
	private int lastUpdateCharacter;
	private	int currentLine;
	// Use this for initialization
	void Start () {
		SetScenarios();
		currentText=string.Empty;
		timeUntilDisplay=0;
		timeElapsed=1;
		currentLine=0;
		lastUpdateCharacter=-1;

		SetNextLine();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if(currentLine<scenarios.Length){
				SetNextLine();
			}else{
				Application.LoadLevel("Title");
			}
		}
			// クリックから経過した時間が想定表示時間の何%か確認し、表示文字数を出す
		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
		
		// 表示文字数が前回の表示文字数と異なるならテキストを更新する
		if( displayCharacterCount != lastUpdateCharacter ){
			uiText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}

	}
	void SetNextLine()
	{
		// 現在の行のテキストをuiTextに流し込み、現在の行番号を一つ追加する
		currentText = scenarios[currentLine];
		currentLine ++;

		// 想定表示時間と現在の時刻をキャッシュ
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		
		// 文字カウントを初期化
		lastUpdateCharacter = -1;
	}
	//FIX::Csvとかから入力
	void SetScenarios(){
		string[] st=new string[4];
		st[0]="ほおおおおお\nげfeojfijaogijaejgoiawjgoiewagｈづおえほふぃへわふぃおえうぉいｆふぇおいｆほいえうぉいふぉいｇｈヴぉいえｗｈごいえｗｈごいほいｖのしｚんばえ９ｐ＠ｊｋｆまぐぁ";
		st[1]="あべええふぁえあえｗ";
		st[2]="ほんとにほんとにほんとにほんとに";
		st[3]="ライオン";
		scenarios=st;
	}
}
