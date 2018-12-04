using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFinishState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        RemoveUi();
        ChangeScene(SceneList.StageSelectScene, null);
    }

    /**
     * @brief   全UIオブジェクトをシーンから削除
    */
    private void RemoveUi()
    {
        Destroy(((TitleScene)scene_).TitleUi.TitleUiObj.gameObject);
    }
}
