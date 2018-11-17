using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitState : StateBase {

    /// <summary>
    /// テスト用スタブモジュール
    /// </summary>

    private void Start()
    {
        scene_.ChangeState(StateList.StageMainState);
    }
}
