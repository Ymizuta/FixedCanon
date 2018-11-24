using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        //オブジェクトパラムスにステージオブジェクトのクローンを渡す
        GameObject stage_object_clone = Instantiate(((StageScene)scene_).ObjParams.StageObject);
        ((StageScene)scene_).ObjParams.Init(stage_object_clone);
        //ステート移行
        scene_.ChangeState(StateList.StageMainState,null);
    }    
}
