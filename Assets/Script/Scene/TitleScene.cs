﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : SceneBase {

    private StateBase title_init_state_ = null;
    private StateBase title_main_state_ = null;
    private StateBase title_finish_state_ = null;

    //文字列
    private readonly string STATE_PATH = "State\\";

    /// <summary>
    /// 各ステートの役割は下記の通り。
    /// [init_state]TAP TO START　ボタンを表示
    /// [main_state]ボタン押下を受け付け
    /// [finish_state]ボタン押下を受けてシーン遷移をトリガー
    /// </summary>

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
	}

    public override void Init(object scene_params)
    {
        //配下のステートを取得
        title_init_state_ = GetState(STATE_PATH, StateList.TitleInitState);
        title_main_state_ = GetState(STATE_PATH, StateList.TitleMainState);
        title_finish_state_ = GetState(STATE_PATH, StateList.TitleFinishState);

        Debug.Log("タイトルシーン生成");
        state_dictionary_[StateList.TitleInitState] = title_init_state_;
        state_dictionary_[StateList.TitleMainState] = title_main_state_;
        state_dictionary_[StateList.TitleFinishState] = title_finish_state_;
        ChangeState(StateList.TitleInitState,null);
    }

}
