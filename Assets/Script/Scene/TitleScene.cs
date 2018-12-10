using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : SceneBase {

    //private StateBase title_init_state_ = null;
    //private StateBase title_main_state_ = null;
    //private StateBase title_finish_state_ = null;
    private TitleUi title_ui_;

    //文字列
    private readonly string STATE_PATH = "State\\";

    /// <summary>
    /// 各ステートの役割は下記の通り。
    /// [init_state]TAP TO START　ボタンを表示
    /// [main_state]ボタン押下を受け付け
    /// [finish_state]ボタン押下を受けてシーン遷移をトリガー
    /// </summary>

    public TitleUi TitleUi
    {
        get
        {
            return title_ui_;
        }
    }

    public override void Init(object scene_params)
    {
        Debug.Log("タイトルシーン生成");

        //配下のステートを取得
        //title_init_state_ = GetState(STATE_PATH, StateList.TitleInitState);
        //title_main_state_ = GetState(STATE_PATH, StateList.TitleMainState);
        //title_finish_state_ = GetState(STATE_PATH, StateList.TitleFinishState);
        //ディクショナリ登録
        state_dictionary_[StateList.TitleInitState] = GetState(STATE_PATH, StateList.TitleInitState);
        state_dictionary_[StateList.TitleMainState] = GetState(STATE_PATH, StateList.TitleMainState);
        state_dictionary_[StateList.TitleFinishState] = GetState(STATE_PATH, StateList.TitleFinishState);
        //TitleUiクラスを取得
        title_ui_ = this.GetComponent<TitleUi>();
        //初期化ステートへ遷移
        ChangeState(StateList.TitleInitState,null);
    }
}
