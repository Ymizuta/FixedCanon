using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectMainState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        ((StageSelectScene)scene_).StageSelectUIMethod.OnPshuSelectButton += OnPshuSelectButtonCallBack;
        //scene_.ChangeState(StateList.StageSelectFinishState,null);
    }

    private void OnPshuSelectButtonCallBack()
    {
        scene_.ChangeState(StateList.StageSelectFinishState, null);
    }

}
