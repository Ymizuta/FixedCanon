using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFinishState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        ChangeScene(SceneList.StageSelectScene,null);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
