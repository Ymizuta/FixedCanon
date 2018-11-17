using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScene : SceneBase {

    /// <summary>
    /// テスト用ドライバモジュール
    /// </summary>

    /// <summary>
    ///各ステートの役割は下記の通り。
    /// [init_state]ゲームスタート表示・オブジェクトの設置（プレイヤー、ターゲット等）・各種パラメータ設定
    /// [main_state]ゲームプレイ
    /// [finish_state]クリア→次のステージへ　ゲームオーバー→リトライORステージセレクトへ　　
    /// </summary>

    [SerializeField] StateBase stage_init_state_ = null;
    [SerializeField] StateBase stage_main_state_ = null;
    [SerializeField] StateBase stage_finish_state_ = null;

    private void Start()
    {
        Debug.Log("ステージシーンを生成");
        state_[StateList.StageInitState] = stage_init_state_;
        state_[StateList.StageMainState] = stage_main_state_;
        state_[StateList.StageFinishState] = stage_finish_state_;
        ChangeState(StateList.StageInitState);
    }
}
