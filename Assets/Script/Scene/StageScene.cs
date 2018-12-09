using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;

public class StageScene : SceneBase {

    /// <summary>
    ///各ステートの役割は下記の通り。
    /// [init_state]ゲームスタート表示・オブジェクトの設置（プレイヤー、ターゲット等）・各種パラメータ設定
    /// [main_state]ゲームプレイ
    /// [finish_state]クリア→次のステージへ　ゲームオーバー→リトライORステージセレクトへ　　
    /// </summary>

    //private StateBase stage_init_state_ = null;    
    //private StateBase stage_main_state_ = null;  
    //private StateBase stage_finish_state_ = null;

    private Player player_;
    private GameObject player_clone_;
    private BulletManager bullet_manager_;
    private StageObjectManager stage_obj_manager;
    private GameObject stage_ui_;                   //ステージシーンのUIオブジェクトを持つ空オブジェクト
    private GameObject fire_button_;                //発射ボタンオブジェクト
    private GameObject change_button_;              //砲弾変更ボタンオブジェクト
    private bool is_game_clear_;                    //StageFinishStateでリザルトを判定するフラグ
    private bool is_game_over_;                     //StageFinishStateでリザルトを判定するフラグ

    private int stage_id_;
    private StageResultUi stage_result_ui_;

    //Jsonファイルからデータを反映させるインスタンス
    private StageInfo stage_info_ = new StageInfo();

    //文字列
    private readonly string STATE_PATH = "State\\";
    private readonly string JSON_PATH = "Assets\\Json\\stageinfo_";
    //private readonly string STAGE_OBJ_STR = "StageObject";
    
    public Dictionary<string,StateBase> StateDictionary
    {
        get
        {
            return state_dictionary_;
        }        
    }

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

    public StageObjectManager StageObjectManager
    {
        get
        {
            return stage_obj_manager;
        }
        set
        {
            stage_obj_manager = value;
        }
    }

    public GameObject StageUi
    {
        get
        {
            return stage_ui_;
        }
        set
        {
            stage_ui_ = value;
        }
    }

    public GameObject FireButton
    {
        get
        {
            return fire_button_;        
        }
        set
        {
            fire_button_ = value;
        }
    }

    public GameObject ChangeButton
    {
        get
        {
            return change_button_;
        }
        set
        {
            change_button_ = value;
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
        set
        {
            stage_info_ = value;
        }
    }

    public int StageId
    {
        get
        {
            return stage_id_;
        }
        set
        {
            stage_id_ = value;
        }
    }

    public StageResultUi StageResultUi
    {
        get
        {
            return stage_result_ui_;
        }
        set
        {
            stage_result_ui_ = value;
        }
    }

    public override void Init(object scene_params)
    {
        //配下のステートを取得
        //この処理が不要なのでは？？
        //stage_init_state_ = GetState(STATE_PATH, StateList.StageInitState);
        //stage_main_state_ = GetState(STATE_PATH, StateList.StageMainState);
        //stage_finish_state_ = GetState(STATE_PATH, StateList.StageFinishState);

        //ステージ情報取得
        stage_id_ = (int)scene_params;
        //string json = File.ReadAllText("Assets\\Json\\stageinfo.json");
        //StageInfoTable stage_info_table = new StageInfoTable();
        //stage_info_table.stage_info_list_ = new List<StageInfo>();
        //stage_info_table = JsonUtility.FromJson<StageInfoTable>(json);
        //stage_info_ = stage_info_table.stage_info_list_[stage_id_ - 1];     //後ほど処理を見直し

        //初期化
        Debug.Log("ステージシーンを生成");
        state_dictionary_[StateList.StageInitState] = GetState(STATE_PATH, StateList.StageInitState);
        state_dictionary_[StateList.StageMainState] = GetState(STATE_PATH, StateList.StageMainState);
        state_dictionary_[StateList.StageFinishState] = GetState(STATE_PATH, StateList.StageFinishState);
        
        //ゲームリザルトの判定に利用するフラグを設定
        is_game_over_ = false;
        is_game_clear_ = false;

        //ステート移行
        ChangeState(StateList.StageInitState,null);
    }

    public void ResetScene()
    {
        //stage_init_state_ = null;
        //stage_main_state_ = null;
        //stage_finish_state_ = null;
        state_dictionary_[StateList.StageInitState] = null;
        state_dictionary_[StateList.StageMainState] = null;
        state_dictionary_[StateList.StageFinishState] = null;
        Destroy(player_clone_.gameObject);
        player_clone_ = null;
        player_ = null;
        bullet_manager_ = null;
        Destroy(stage_obj_manager.Params.StageObjClone);
        stage_obj_manager.Params.StageObjClone = null;
        stage_obj_manager.Params.StageObject = null;
        stage_obj_manager.Params.TargetObjectList = null;
        stage_obj_manager.Params.NormalObjectList = null;
        stage_obj_manager.Params = null;
        stage_obj_manager = null;
        Destroy(stage_ui_.gameObject);
        stage_ui_ = null;
        stage_info_ = null;
        stage_result_ui_.RemoveStageResultUi();
        stage_result_ui_ = null;
    }
}
