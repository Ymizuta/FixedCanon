using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInitState : StateBase {

    /// <summary>
    /// スタブモジュール
    /// </summary>

    private void Start()
    {
        Init();
    }

    private void Update()
    {

    }

    private void Init()
    {
        Debug.Log("初期化処理");
    }

    private void ChangeState()
    {
        scene_.ChangeState(StateList.StageMainState);
    }

}
