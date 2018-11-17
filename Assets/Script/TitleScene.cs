using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : SceneBase {

    [SerializeField] StateBase title_init_state_ = null;
    [SerializeField] StateBase title_main_state_ = null;
    [SerializeField] StateBase title_finish_state_ = null;

    /// <summary>
    /// 各ステートの役割は下記の通り。
    /// [init_state]TAP TO START　ボタンを表示
    /// [main_state]ボタン押下を受け付け
    /// [finish_state]ボタン押下を受けてシーン遷移をトリガー
    /// </summary>

    // Use this for initialization
    void Start () {
        Debug.Log("タイトルシーン生成");
        state_[StateList.TitleInitState] = title_init_state_;
        state_[StateList.TitleMainState] = title_main_state_;
        state_[StateList.TitleFinishState] = title_finish_state_;
        ChangeState(StateList.TitleInitState);
    }

    // Update is called once per frame
    void Update () {
	}
     
}
