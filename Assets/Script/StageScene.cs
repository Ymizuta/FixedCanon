﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

    //文字列
    private readonly string JSON_PATH = "Assets\\Json\\stageinfo_";
    private readonly string STAGE_OBJ_STR = "StageObject";

    public override void Init()
    {
        //Jsonファイルのデータを反映
        int stage_id = 1;   //本番ではステージセレクトシーンからステージIDを受け取る
        //PathからJsonファイルのデータを取得
        string json = File.ReadAllText(JSON_PATH + stage_id.ToString("00")+".json");
        StageInfo stage_info = new StageInfo();
        //クラスにJsonデータを反映
        JsonUtility.FromJsonOverwrite(json,stage_info);
        //Debug.Log(stage_info.id.ToString("00"));
        //Debug.Log(stage_info.bullet_type[0]);
        //Debug.Log(stage_info.bullet_type[1]);
        //Debug.Log(stage_info.number_of_bullet[0]);
        //Debug.Log(stage_info.number_of_bullet[1]);

        //初期化
        Debug.Log("ステージシーンを生成");
        state_dictionary_[StateList.StageInitState] = stage_init_state_;
        state_dictionary_[StateList.StageMainState] = stage_main_state_;
        state_dictionary_[StateList.StageFinishState] = stage_finish_state_;
        obj_params = this.GetComponent<ObjectParams>();
        
        //ステージオブジェクトをObjectParamsに登録
        obj_params.StageObject = Resources.Load(STAGE_OBJ_STR + stage_info.id.ToString("00")) as GameObject;

        //ゲームリザルトの判定に利用するフラグを設定
        game_over_flag = false;
        game_clear_flag = false;
        //ステート移行
        ChangeState(StateList.StageInitState,null);
    }

    //ステートにObjectParamsを渡すためのプロパティ
    public ObjectParams ObjParams
    {
        get
        {
            return obj_params;
        }
    }

    //ゲームクリアーフラグ（StageFinishStateに渡す）
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
    //ゲームオーバーフラグ（StageFinishStateに渡す）
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
