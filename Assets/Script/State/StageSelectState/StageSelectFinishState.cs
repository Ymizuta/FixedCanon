using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectFinishState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        //Debug.Log("ステージシーンへ移行します");
        RemoveUi();
        ChangeScene(SceneList.StageScene,((StageSelectScene)scene_).StageSelectUIController.StageId);
    }

    private void RemoveUi()
    {
        //UIオブジェクトをシーンから削除
        Destroy(((StageSelectScene)scene_).StageSelectUIController.StageSelectUI.gameObject);
    }
}
