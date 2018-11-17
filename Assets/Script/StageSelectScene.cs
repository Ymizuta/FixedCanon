using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectScene : SceneBase {

    /// <summary>
    ///各ステートの役割は下記の通り。
    /// [init_state]ステージセレクト画面を表示（各ステージボタン）
    /// [main_state]ボタン押下を受け付け
    /// [finish_state]ボタン押下を受けて任意のシーンへの遷移をトリガー
    /// </summary>

    // Use this for initialization
    void Start () {
        Debug.Log("ステージセレクトシーン");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
