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
        StageSelectUi stage_select_ui = stage_select_scene.StageSelectUi;
        GameObject ui_prefab = Resources.Load("UI\\StageSelectUI") as GameObject;
        //UIのプレハブ生成/各種ボタンオブジェクト取得/パラメータ初期化
        stage_select_ui.StageSelectUiObj = Instantiate(ui_prefab);
        stage_select_ui.SelectButton = GameObject.Find(UiList.SelectButton).gameObject;
        stage_select_ui.NextButton = GameObject.Find(UiList.NextButton).gameObject;
        stage_select_ui.BackButton = GameObject.Find(UiList.BackButton).gameObject;
        stage_select_ui.TextObj = GameObject.Find(UiList.SelectButton + "/" +UiList.TextObj ).gameObject;
        stage_select_ui.SelectButtonText = stage_select_ui.TextObj.GetComponent<Text>();
        stage_select_ui.StageId = stage_select_ui.DefaultStageId;
        stage_select_ui.SelectButtonText.text 
            = StageSelectUi.SelectButtonStr + stage_select_ui.DefaultStageId.ToString("00");
        //各種ボタンオブジェクトに関数を登録
        UnityAction PushSelectButton = stage_select_ui.PushSelectButton;
        UnityAction PushNextButton = stage_select_ui.PushNextButton;
        UnityAction PushBackButton = stage_select_ui.PushBackButton;
        stage_select_ui.SelectButton.GetComponent<Button>().onClick.AddListener(PushSelectButton);
        stage_select_ui.NextButton.GetComponent<Button>().onClick.AddListener(PushNextButton);
        stage_select_ui.BackButton.GetComponent<Button>().onClick.AddListener(PushBackButton);
        //ステート移行
        scene_.ChangeState(StateList.StageSelectMainState, null);
    }
}
