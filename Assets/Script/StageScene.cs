using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScene : SceneBase {

    /// <summary>
    /// テスト用ドライバモジュール
    /// </summary>

    [SerializeField] StateBase init_state_;
    [SerializeField] StateBase main_state_;
    [SerializeField] StateBase finish_state_;

    private void Start()
    {
        current_state_ = Instantiate(init_state_);
        //current_state_ = gameObject.AddComponent<StageInitState>();
        current_state_.scene_ = this;
    }

    public override void ChangeState()
    {
        Debug.Log("チェンジ");
        GameObject.Destroy(current_state_.gameObject);
        current_state_ = null;
        current_state_ = Instantiate(main_state_);
        //current_state_ = gameObject.AddComponent<StageMainState>();
    }
}
