using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMainState : StateBase {

	// Use this for initialization
	public override void  SetUp () {
        //スタートボタン押下時にTitleUiクラスからコールバックされる処理を登録
        ((TitleScene)scene_).TitleUi.OnPushStartButton += OnpushStartButtonCallBack;
    }

    /**
     * @brief   スタートボタン押下時に実行される処理
     */ 
    private void OnpushStartButtonCallBack()
    {
        scene_.ChangeState(StateList.TitleFinishState, null);
    }
}
