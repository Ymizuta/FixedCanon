using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitState : StateBase {

    private ObjectCreator object_creator_;
    private ObjectParams object_params_;

	// Use this for initialization
	void Start () {
        Init();
        object_creator_ = this.GetComponent<ObjectCreator>();
        object_params_ = this.GetComponent<ObjectParams>();
        object_creator_.CreateObject(object_params_.StageObject);
        scene_.ChangeState(StateList.StageMainState);
    }
}
