using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectFinishState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        //Debug.Log("ステージシーンへ移行します");
        RemoveUi();
        ChangeScene(SceneList.StageScene,((StageSelectScene)scene_).StageSelectUi.StageId);
    }

    /**
     * @brief   全UIオブジェクトをシーンから削除
     */
    private void RemoveUi()
    {        
        Destroy(((StageSelectScene)scene_).StageSelectUi.StageSelectUiObj.gameObject);
    }
}
