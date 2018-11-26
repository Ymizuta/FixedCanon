using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StageSelectInitState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        StageSelectScene stage_select_scene = (StageSelectScene)scene_;
        StageSelectUIController ui_controller = stage_select_scene.StageSelectUIController;
        StageSelectUIMethod ui_method = stage_select_scene.StageSelectUIMethod;
        GameObject ui_prefab = Resources.Load("UI\\StageSelectUI") as GameObject;
        ui_controller.StageSelectUI = Instantiate(ui_prefab);
        //各種ボタンオブジェクトを取得
        ui_controller.SelectButton = GameObject.Find("SelectButton").gameObject;
        ui_controller.NextButton = GameObject.Find("NextButton").gameObject;
        ui_controller.BackButton = GameObject.Find("BackButton").gameObject;
        //各種ボタンオブジェクトに関数を登録
        UnityAction PushSelectButton = ui_method.PushSelectButton;
        UnityAction PushNextButton = ui_method.PushNextButton;
        UnityAction PushBackButton = ui_method.PushBackButton;
        ui_controller.SelectButton.GetComponent<Button>().onClick.AddListener(PushSelectButton);
        ui_controller.NextButton.GetComponent<Button>().onClick.AddListener(PushNextButton);
        ui_controller.BackButton.GetComponent<Button>().onClick.AddListener(PushBackButton);

        //ステート移行
        scene_.ChangeState(StateList.StageSelectMainState, null);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
