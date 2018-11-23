using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFinishState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        if (scene_.GetComponent<StageScene>().GameClearFlag)
        {
            Debug.Log("フィニッシュ：ゲームクリア！");
            return;
        }else
        if (scene_.GetComponent<StageScene>().GameOverFlag)
        {
            Debug.Log("フィニッシュ：ゲームオーバー！");
            return;
        }
        Debug.LogError("フラグが登録されていません。");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
