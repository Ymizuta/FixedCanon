﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization;
using System.Text;

public class StageScene : SceneBase {

    /// <summary>
    ///各ステートの役割は下記の通り。
    /// [init_state]ゲームスタート表示・オブジェクトの設置（プレイヤー、ターゲット等）・各種パラメータ設定
    /// [main_state]ゲームプレイ
    /// [finish_state]クリア→次のステージへ　ゲームオーバー→リトライORステージセレクトへ　　
    /// </summary>

    private StateBase stage_init_state_ = null;    
    private StateBase stage_main_state_ = null;  
    private StateBase stage_finish_state_ = null;

    private Player player_;
    private GameObject player_clone_;
    private BulletManager bullet_manager_;
    private StageObjectParams stage_obj_params_;          //ステージオブジェクトのプレハブ、クローンを管理
    private bool is_game_clear_;                          //StageFinishStateでリザルトを判定するフラグ
    private bool is_game_over_;                           //StageFinishStateでリザルトを判定するフラグ

    //Jsonファイルからデータを反映させるインスタンス
    private StageInfo stage_info_ = new StageInfo();

    //文字列
    private readonly string STATE_PATH = "State\\";
    private readonly string JSON_PATH = "Assets\\Json\\stageinfo_";
    private readonly string STAGE_OBJ_STR = "StageObject";

    public Player Player
    {
        get
        {
            return player_;
        }
        set
        {
            player_ = value;
        }
    }

    public GameObject PlyerClone
    {
        get
        {
            return player_clone_;
        }
        set
        {
            player_clone_ = value;
        }
    }

    public BulletManager BulletManager
    {
        get
        {
            return bullet_manager_;
        }
        set
        {
            bullet_manager_ = value;
        }
    }

    public override void Init()
    {
        //配下のステートを取得
        stage_init_state_ = GetState(STATE_PATH, StateList.StageInitState);
        stage_main_state_ = GetState(STATE_PATH, StateList.StageMainState);
        stage_finish_state_ = GetState(STATE_PATH, StateList.StageFinishState);

        //テストスクリプト
        //string tmp_json = File.ReadAllText("Assets\\Json\\stageinfo.json");
        //Stage stage = new Stage();
        //JsonUtility.FromJsonOverwrite(tmp_json, stage);
        //string tmp_json = File.ReadAllText("Assets\\Json\\stageinfo.json");
        //var stream = new FileStream("Assets\\Json\\stageinfo.json",FileM);
        //var serializer = new DataContractSerializer(typeof(Stage));

        //Jsonファイルのデータを反映
        int stage_id = 1;   //本番ではステージセレクトシーンからステージIDを受け取る
        //PathからJsonファイルのデータを取得
        string json = File.ReadAllText(JSON_PATH + stage_id.ToString("00")+".json");
        //クラスにJsonデータを反映
        JsonUtility.FromJsonOverwrite(json,stage_info_);
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
        stage_obj_params_ = this.GetComponent<StageObjectParams>();
        
        //ステージオブジェクトをObjectParamsに登録
        stage_obj_params_.StageObject = Resources.Load(STAGE_OBJ_STR + stage_info_.id.ToString("00")) as GameObject;

        //ゲームリザルトの判定に利用するフラグを設定
        is_game_over_ = false;
        is_game_clear_ = false;

        //ステート移行
        ChangeState(StateList.StageInitState,null);
    }

    //ステートにObjectParamsを渡すためのプロパティ
    public StageObjectParams ObjParams
    {
        get
        {
            return stage_obj_params_;
        }
    }

    //ゲームクリアーフラグ（StageFinishStateに渡す）
    public bool IsGameClear
    {
        get
        {
            return is_game_clear_;
        }
        set
        {
            is_game_clear_ = value;
        }
    }
    //ゲームオーバーフラグ（StageFinishStateに渡す）
    public bool IsGameOver
    {
        get
        {
            return is_game_over_;
        }
        set
        {
            is_game_over_ = value;
        }
    }

    public StageInfo StageInfo
    {
        get
        {
            return stage_info_;
        }
    }

    private void OnDestroy()
    {
        stage_init_state_ = null;
        stage_main_state_ = null;
        stage_finish_state_ = null;
        player_ = null;
        player_clone_ = null;
        bullet_manager_ = null;
        stage_obj_params_ = null;
        stage_info_ = null;
    }
}
