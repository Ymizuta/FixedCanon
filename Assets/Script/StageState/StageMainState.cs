using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMainState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        scene_.ChangeState(StateList.StageFinishState);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
