using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectFinishState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        ChangeScene(SceneList.StageScene);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
