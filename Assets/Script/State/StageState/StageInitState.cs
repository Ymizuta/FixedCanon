using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;


public class StageInitState : StateBase {

	// Use this for initialization
	public override void SetUp() {
        Debug.Log("セットアップが呼ばれました");

        StageScene stage_scene = ((StageScene)scene_);

        //ステージ情報取得
        string json = File.ReadAllText("Assets\\Json\\stageinfo.json");
        StageInfoTable stage_info_table = new StageInfoTable();
        stage_info_table.stage_info_list_ = new List<StageInfo>();
        stage_info_table = JsonUtility.FromJson<StageInfoTable>(json);
        ((StageScene)scene_).StageInfo = stage_info_table.stage_info_list_[((StageScene)scene_).StageId - 1];     //後ほど処理を見直し

        //StageScene配下のクラスを初期化
        SetUpStageObjectManager(stage_scene);
        SetUpPlayer(stage_scene);
        SetUpBulletManager(stage_scene);

        //UIオブジェクトを初期化
        stage_scene.StageUi = Instantiate(Resources.Load("UI/StageUI")) as GameObject;
        stage_scene.FireButton = GameObject.Find(UiList.FireButton).gameObject;
        stage_scene.ChangeButton = GameObject.Find(UiList.ChangeButton).gameObject;

        //ステート移行
        scene_.ChangeState(StateList.StageMainState,null);
    }

    //StageObjectマネージャー初期化
    private void SetUpStageObjectManager(StageScene stage_scene)
    {
        //ステージ初期化
        stage_scene.StageObjectManager = stage_scene.GetComponent<StageObjectManager>();
        stage_scene.StageObjectManager.Setup();

        //初期化処理：要修正
        string STAGE_OBJ_STR = "StageObject";
        stage_scene.StageObjectManager.Params.StageObject
            = Resources.Load(STAGE_OBJ_STR + stage_scene.StageInfo.StageID.ToString("00")) as GameObject;
 
        //オブジェクトパラムスにステージオブジェクトのクローンを渡す
        GameObject stage_object_clone
            = Instantiate(stage_scene.StageObjectManager.Params.StageObject);
        stage_scene.StageObjectManager.Params.Init(stage_object_clone);
    }

    //プレイヤー初期化
    private void SetUpPlayer(StageScene stage_scene)
    {
        //Playerクラスのメンバ変数に登録
        stage_scene.PlyerClone = GetPlayerClone();
        stage_scene.Player = stage_scene.PlyerClone.GetComponent<Player>();
        stage_scene.Player.SetUp();
    }

    //Bulletマネージャー初期化
    private void SetUpBulletManager(StageScene stage_scene)
    {
        stage_scene.BulletManager = stage_scene.GetComponent<BulletManager>();
        stage_scene.BulletManager.SetUp();
        //要修正
        stage_scene.BulletManager.Params.InitParams(stage_scene.StageInfo);
    }
    
    private GameObject GetPlayerClone()
    {
        GameObject player_prefab = Resources.Load("Player") as GameObject;
        return Instantiate(player_prefab);
    }
}
