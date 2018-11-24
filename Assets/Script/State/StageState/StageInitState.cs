using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitState : StateBase {

    private ObjectCreator object_creator_;
    public GameObject stage_object_;

	// Use this for initialization
	void Start () {
        Init();
        object_creator_ = this.GetComponent<ObjectCreator>();
        //オブジェクトパラムスにステージオブジェクトのクローンを渡す
        //((StageScene)scene_).ObjParams.StageObjectClone 
        //    =  object_creator_.CreateObject(((StageScene)scene_).ObjParams.StageObject);
        GameObject stage_object_clone = object_creator_.CreateObject(((StageScene)scene_).ObjParams.StageObject);
        ((StageScene)scene_).ObjParams.Init(stage_object_clone);

        scene_.ChangeState(StateList.StageMainState,null);
    }    

}
