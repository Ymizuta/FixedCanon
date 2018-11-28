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

        //UIのプレハブを生成後、各種ボタンオブジェクトを取得
        ui_controller.StageSelectUI = Instantiate(ui_prefab);
        ui_controller.SelectButton = GameObject.Find(UiList.SelectButton).gameObject;
        ui_controller.NextButton = GameObject.Find(UiList.NextButton).gameObject;
        ui_controller.BackButton = GameObject.Find(UiList.BackButton).gameObject;
        ui_controller.TextObj = GameObject.Find(UiList.SelectButton + "/" +UiList.TextObj ).gameObject;
        ui_controller.SelectButtonText = ui_controller.TextObj.GetComponent<Text>();
        ui_controller.StageId = ui_controller.DefaultStageId;
        ui_controller.SelectButtonText.text = StageSelectUIController.SelectButtonStr + ui_controller.DefaultStageId.ToString("00");
        //各種ボタンオブジェクトに関数を登録
        UnityAction PushSelectButton = ui_method.PushSelectButton;
        UnityAction PushNextButton = ui_method.PushNextButton;
        UnityAction PushBackButton = ui_method.PushBackButton;
        ui_controller.SelectButton.GetComponent<Button>().onClick.AddListener(PushSelectButton);
        ui_controller.NextButton.GetComponent<Button>().onClick.AddListener(PushNextButton);
        ui_controller.BackButton.GetComponent<Button>().onClick.AddListener(PushBackButton);
        //メソッド管理クラスの初期化
        stage_select_scene.StageSelectUIMethod.StageSelectScene = stage_select_scene;
        //ステート移行
        scene_.ChangeState(StateList.StageSelectMainState, null);
    }
}
