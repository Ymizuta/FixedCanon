using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleInitState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        scene_.ChangeState(StateList.TitleMainState);
    }

    // Update is called once per frame
    void Update () {
    }
}
