using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneBase : MonoBehaviour {

    protected Dictionary<string, StateBase> state_dictionary_ = new Dictionary<string, StateBase>();
    private StateBase current_state_;

    public void ChangeState(string state_name)
    {
        RemoveState();
        AddState(state_name);
        current_state_.scene_ = this;
    }

    private void AddState(string state_name)
    {
        current_state_ = Instantiate(state_dictionary_[state_name]);
    }

    private void RemoveState()
    {
        if (current_state_ != null)
        {
            Destroy(current_state_.gameObject);
            current_state_ = null;
        }
    }

    public abstract void Init();
}
