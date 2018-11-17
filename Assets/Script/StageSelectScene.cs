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

    [SerializeField] StateBase stage_select_init_state_ = null;
    [SerializeField] StateBase stage_select_main_state_ = null;
    [SerializeField] StateBase stage_select_finish_state_ = null;

    // Use this for initialization
    void Start () {
        Debug.Log("ステージセレクトシーン");
        state_[StateList.StageSelectInitState] = stage_select_init_state_;
        state_[StateList.StageSelectMainState] = stage_select_main_state_;
        state_[StateList.StageSelectFinishState] = stage_select_finish_state_;
        ChangeState(StateList.StageSelectInitState);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
