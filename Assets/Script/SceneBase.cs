using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneBase : MonoBehaviour {

    /// <summary>
    /// ドライバモジュール
    /// </summary>

    private StateBase current_state_;

    private void Init()
    {

    }
}
