using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneBase : MonoBehaviour {

    /// <summary>
    /// テスト用ドライバモジュール
    /// </summary>

    protected StateBase current_state_;

    private void Init()
    {

    }

    public abstract void ChangeState();

}
