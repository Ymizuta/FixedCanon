using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInitState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        StageScene stage_scene = ((StageScene)scene_);
        
        SetUpStageObjectManager(stage_scene);
        SetUpPlayer(stage_scene);
        SetUpBulletManager(stage_scene);
        //UIオブジェクトを初期化
        stage_scene.StageUi = Instantiate(Resources.Load("UI/StageUI")) as GameObject;
        stage_scene.FireButton = GameObject.Find(UiList.FireButton).gameObject;

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
        GameObject player_prefab = Resources.Load("Player") as GameObject;
        GameObject player_clone = Instantiate(player_prefab);
        Player player = player_clone.GetComponent<Player>();
        //Playerクラスのメンバ変数に登録
        stage_scene.PlyerClone = player_clone;
        stage_scene.Player = player;
    }

    //Bulletマネージャー初期化
    private void SetUpBulletManager(StageScene stage_scene)
    {
        stage_scene.BulletManager = stage_scene.GetComponent<BulletManager>();
        stage_scene.BulletManager.SetUp();
        //要修正
        stage_scene.BulletManager.Params.InitParams(stage_scene.StageInfo);
    }
}
