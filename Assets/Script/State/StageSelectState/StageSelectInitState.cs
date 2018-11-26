using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectInitState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        StageSelectScene stage_select_scene = (StageSelectScene)scene_;
        StageSelectUIController ui_controller = stage_select_scene.StageSelectUIController;
        GameObject ui_prefab = Resources.Load("UI\\StageSelectUI") as GameObject;
        ui_controller.StageSelectUI = Instantiate(ui_prefab);
        //各種ボタンオブジェクトを取得
        ui_controller.SelectButton = GameObject.Find("SelectButton").gameObject;
        ui_controller.NextButton = GameObject.Find("NextButton").gameObject;
        ui_controller.BackButton = GameObject.Find("BackButton").gameObject;
        //ステート移行
        //scene_.ChangeState(StateList.StageSelectMainState,null);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
