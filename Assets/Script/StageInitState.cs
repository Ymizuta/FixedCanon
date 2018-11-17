using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitState : StateBase {

    /// <summary>
    /// テスト用スタブモジュール
    /// </summary>

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            scene_.ChangeState();
        }
    }

}
