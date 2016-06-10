using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※ここを追加する

public class MyCanvas : MonoBehaviour {

  static Canvas _canvas;
  public int TBcount=4;
  void Start () {
    // Canvasコンポーネントを保持
    _canvas = GetComponent<Canvas>();
    for(int tbNum=TBcount;tbNum>0;tbNum--){
    	//Debug.Log(TBcount);
    	SetActive("TB"+tbNum.ToString(), false);
	}
  }

  /// 表示・非表示を設定する
  public void SetActive(string name, bool b) {
    foreach(Transform child in _canvas.transform) {
      // 子の要素をたどる
      if(child.name == name) {
        // 指定した名前と一致
        // 表示フラグを設定
        child.gameObject.SetActive(b);
        // おしまい
        return;
      }
    }
    // 指定したオブジェクト名が見つからなかった
    Debug.LogWarning("Not found objname:"+name);
  }
}