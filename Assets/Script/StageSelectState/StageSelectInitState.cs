using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectInitState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        scene_.ChangeState(StateList.StageSelectMainState,null);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
