using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        scene_.ChangeState(StateList.StageMainState);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
