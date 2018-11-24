using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        StageScene stage_scene = ((StageScene)scene_);

        //ステージ初期化
        //オブジェクトパラムスにステージオブジェクトのクローンを渡す
        GameObject stage_object_clone = Instantiate(stage_scene.ObjParams.StageObject);
        stage_scene.ObjParams.Init(stage_object_clone);

        //プレイヤー初期化
        GameObject player_prefab = Resources.Load("Player") as GameObject;
        GameObject player_clone = Instantiate(player_prefab);
        Player player = player_clone.GetComponent<Player>();
        //Playerクラスのメンバ変数に登録
        stage_scene.PlyerClone = player_clone;
        stage_scene.Player = player;

        //Bulletマネージャー初期化
        stage_scene.BulletManager = stage_scene.GetComponent<BulletManager>();
        stage_scene.BulletManager.SetUp();

        //ステート移行
        scene_.ChangeState(StateList.StageMainState,null);
    }    
}
