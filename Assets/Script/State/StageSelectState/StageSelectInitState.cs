using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StageSelectInitState : StateBase {

	// Use this for initialization
	public override void SetUp () {
        StageSelectScene stage_select_scene = (StageSelectScene)scene_;
        StageSelectUi stage_select_ui = stage_select_scene.StageSelectUi;
        GameObject ui_prefab = Resources.Load("UI\\StageSelectUI") as GameObject;

        GetSaveData();

        //UIのプレハブ生成/各種ボタンオブジェクト取得/パラメータ初期化
        stage_select_ui.StageSelectUiObj = Instantiate(ui_prefab);

        //SELECTボタンを取得・初期化
        stage_select_ui.SelectButton = GameObject.Find(UiList.SelectButton).gameObject;
        stage_select_ui.TextObj = GameObject.Find(UiList.SelectButton + "/" +UiList.TextObj ).gameObject;
        stage_select_ui.SelectButtonText = stage_select_ui.TextObj.GetComponent<Text>();
        stage_select_ui.StageId = stage_select_ui.DefaultStageId;
        stage_select_ui.SelectButtonText.text 
            = StageSelectUi.SelectButtonStr + stage_select_ui.DefaultStageId.ToString("00");

        //NEXTボタンを取得
        stage_select_ui.NextButton = GameObject.Find(UiList.NextButton).gameObject;

        //BACKTボタンを取得
        stage_select_ui.BackButton = GameObject.Find(UiList.BackButton).gameObject;

        //各種ボタンオブジェクトに関数を登録
        SetUpButtonUi(stage_select_ui.SelectButton, stage_select_ui.PushSelectButton);
        SetUpButtonUi(stage_select_ui.NextButton, stage_select_ui.PushNextButton);
        SetUpButtonUi(stage_select_ui.BackButton, stage_select_ui.PushBackButton);
        //ステート移行
        scene_.ChangeState(StateList.StageSelectMainState, null);
    }

    /*
     * @ brief  ボタンオブジェクトに関数を登録する 
     */
    private void SetUpButtonUi(GameObject button_obj,UnityAction PushMethod)
    {
        button_obj.GetComponent<Button>().onClick.AddListener(PushMethod);
    }

    /*
     * @ brief  最新のクリア済みステージIDを返す
     */
    private void GetSaveData()
    {
         ((StageSelectScene)scene_).StageSelectUi.SavedStageId = PlayerPrefs.GetInt(GameConfig.SAVE_DATA);
    }
}
