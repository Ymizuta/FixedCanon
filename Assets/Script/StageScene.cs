using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScene : SceneBase {

    /// <summary>
    ///各ステートの役割は下記の通り。
    /// [init_state]ゲームスタート表示・オブジェクトの設置（プレイヤー、ターゲット等）・各種パラメータ設定
    /// [main_state]ゲームプレイ
    /// [finish_state]クリア→次のステージへ　ゲームオーバー→リトライORステージセレクトへ　　
    /// </summary>

    [SerializeField] StateBase stage_init_state_ = null;    //エディターから登録
    [SerializeField] StateBase stage_main_state_ = null;    //エディターから登録
    [SerializeField] StateBase stage_finish_state_ = null;  //エディターから登録
    private ObjectParams obj_params;                        //ステージオブジェクトのプレハブ、クローンを管理
    private bool game_clear_flag;
    private bool game_over_flag;

    public override void Init()
    {
        //throw new System.NotImplementedException();
        Debug.Log("ステージシーンを生成");
        state_dictionary_[StateList.StageInitState] = stage_init_state_;
        state_dictionary_[StateList.StageMainState] = stage_main_state_;
        state_dictionary_[StateList.StageFinishState] = stage_finish_state_;
        obj_params = this.GetComponent<ObjectParams>();
        game_over_flag = false;
        game_clear_flag = false;
        ChangeState(StateList.StageInitState,null);
    }

    public ObjectParams ObjParams
    {
        get
        {
            return obj_params;
        }
    }

    public bool GameClearFlag
    {
        get
        {
            return game_clear_flag;
        }
        set
        {
            game_clear_flag = value;
        }
    }

    public bool GameOverFlag
    {
        get
        {
            return game_over_flag;
        }
        set
        {
            game_over_flag = value;
        }
    }

}
