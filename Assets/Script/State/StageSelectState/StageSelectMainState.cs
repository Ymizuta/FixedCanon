using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectMainState : StateBase {

    private bool flag_;

	// Use this for initialization
	public override void SetUp() {
        ((StageSelectScene)scene_).StageSelectUi.OnPshuSelectButton += OnPshuSelectButtonCallBack;
    }

    /**
     * @brief   ユーザが選択ボタンUIを押下した際に呼び出される処理。次Stateへの遷移を実行。
     */
    private void OnPshuSelectButtonCallBack()
    {         
        if (IsMainState())
        {
            scene_.ChangeState(StateList.StageSelectFinishState, null);
        }
    }

    /**
     * @ brief  現在のステート(CurrentState)がMainStateかを判定
     * @ detail バグにより、処理が繰り返し実行されることを防止
    */
    private bool IsMainState()
    {
        return ((StageSelectScene)scene_).CurrentState == ((StageSelectScene)scene_).StateDictionary[StateList.StageSelectMainState];
    }

}
