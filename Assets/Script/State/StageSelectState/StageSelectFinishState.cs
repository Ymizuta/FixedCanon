using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectFinishState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        RemoveUi();
        ChangeScene(SceneList.StageScene,((StageSelectScene)scene_).StageSelectUi.StageId);
        Destroy(scene_.CurrentState.gameObject);
    }

    /**
     * @brief   全UIオブジェクトをシーンから削除
    */
    private void RemoveUi()
    {        
        Destroy(((StageSelectScene)scene_).StageSelectUi.StageSelectUiObj.gameObject);
    }
}
