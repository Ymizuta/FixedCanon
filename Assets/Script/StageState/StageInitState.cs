using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        Debug.Log("ステージメインステートへ移行");
        scene_.ChangeState(StateList.StageMainState);
    }

    // Update is called once per frame
    void Update () {
	}
}
