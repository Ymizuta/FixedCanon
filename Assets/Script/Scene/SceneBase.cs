using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneBase : MonoBehaviour {

    protected Dictionary<string, StateBase> state_dictionary_ = new Dictionary<string, StateBase>();
    private StateBase current_state_;

    public StateBase CurrentState
    {
        get
        {
            return current_state_;
        }
        set
        {
            current_state_ = value;
        }
    }

    public void ChangeState(string state_name,object parm)
    {
        RemoveState();
        AddState(state_name);
        current_state_.scene_ = this;
        current_state_.SetUp();
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

    protected StateBase GetState(string resource_path,string state_name)
    {
        GameObject state_obj = Resources.Load(resource_path + state_name) as GameObject;
        return ((StateBase)state_obj.GetComponent(System.Type.GetType(state_name)));
    }

    public abstract void Init(object scene_params);
}
