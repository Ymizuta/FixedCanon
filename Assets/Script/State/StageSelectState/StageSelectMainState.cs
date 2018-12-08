using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectMainState : StateBase {

	// Use this for initialization
	public override void SetUp() {
        ((StageSelectScene)scene_).StageSelectUi.OnPshuSelectButton += OnPshuSelectButtonCallBack;
    }

    /**
     * @brief   ユーザが選択ボタンUIを押下した際に呼び出される処理。次Stateへの遷移を実行。
     */
    private void OnPshuSelectButtonCallBack()
    {
        scene_.ChangeState(StateList.StageSelectFinishState, null);
    }
}
