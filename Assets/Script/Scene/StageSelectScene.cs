using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectScene : SceneBase {

    /// <summary>
    ///各ステートの役割は下記の通り。
    /// [init_state]ステージセレクト画面を表示（各ステージボタン）
    /// [main_state]ボタン押下を受け付け
    /// [finish_state]ボタン押下を受けて任意のシーンへの遷移をトリガー
    /// </summary>

    private StateBase stage_select_init_state_ = null;
    private StateBase stage_select_main_state_ = null;
    private StateBase stage_select_finish_state_ = null;
    private readonly string STATE_PATH = "State\\";
    private StageSelectUIController stage_select_ui_;
    private StageSelectUIMethod stage_select_ui_method_;

    private void OnDestroy()
    {
        stage_select_init_state_ = null;
        stage_select_main_state_ = null;
        stage_select_finish_state_ = null;
        stage_select_ui_ = null;
        stage_select_ui_method_ = null;                    
    }

    public StageSelectUIController StageSelectUIController
    {
        get
        {
            return stage_select_ui_;
        }
        set
        {
            stage_select_ui_ = value;
        }
    }

    public StageSelectUIMethod StageSelectUIMethod
    {
        get
        {
            return stage_select_ui_method_;
        }
    }

    public override void Init(object scene_params)
    {
        //throw new System.NotImplementedException();
        Debug.Log("ステージセレクトシーン生成");
        //配下のステートを取得
        stage_select_init_state_ = GetState(STATE_PATH, StateList.StageSelectInitState);
        stage_select_main_state_ = GetState(STATE_PATH, StateList.StageSelectMainState);
        stage_select_finish_state_ = GetState(STATE_PATH, StateList.StageSelectFinishState);
        //ディクショナリ登録
        state_dictionary_[StateList.StageSelectInitState] = stage_select_init_state_;
        state_dictionary_[StateList.StageSelectMainState] = stage_select_main_state_;
        state_dictionary_[StateList.StageSelectFinishState] = stage_select_finish_state_;
        //クラス取得
        stage_select_ui_ = this.GetComponent<StageSelectUIController>();
        stage_select_ui_method_ = this.GetComponent<StageSelectUIMethod>();
        //ステート移行
        ChangeState(StateList.StageSelectInitState,null);
    }

}
