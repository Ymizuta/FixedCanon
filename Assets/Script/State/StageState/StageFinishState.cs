using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFinishState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        if (scene_.GetComponent<StageScene>().IsGameClear)
        {
            Debug.Log("フィニッシュ：ゲームクリア！");
            return;
        }else
        if (scene_.GetComponent<StageScene>().IsGameOver)
        {
            Debug.Log("フィニッシュ：ゲームオーバー！");
            return;
        }
        Debug.LogError("フラグが登録されていません。");
    }
}
