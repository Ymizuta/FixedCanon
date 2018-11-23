using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectMainState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        scene_.ChangeState(StateList.StageSelectFinishState,null);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
