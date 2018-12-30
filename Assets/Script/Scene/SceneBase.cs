using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneBase : MonoBehaviour {

    protected Dictionary<string, StateBase> state_dictionary_ = new Dictionary<string, StateBase>();
    private StateBase current_state_;
    private string state_name_;

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
        state_name_ = state_name;

        RemoveState();

        //Destroyメソッドの実行を待つため一瞬待機
        Invoke("AddState", 0.1f);

        //AddState();
        //AddState(state_name);
        //current_state_.scene_ = this;
        //current_state_.scene_ = SceneManager.getInstance().CurrentScene;
        //current_state_.SetUp();
    }

    //private void AddState(string state_name)
    //{
    //    GameObject current_state_obj = Resources.Load("State\\"+state_name) as GameObject;
    //    current_state_ = (StateBase)current_state_obj.GetComponent(System.Type.GetType(state_name));
    //    //current_state_ = Instantiate(state_dictionary_[state_name]);
    //}

    private void AddState()
    {
        GameObject current_state_obj = Resources.Load("State/" + state_name_) as GameObject;
        current_state_ = (StateBase)current_state_obj.GetComponent(System.Type.GetType(state_name_));
        //current_state_ = Instantiate(state_dictionary_[state_name]);
        //current_state_.scene_ = this;
        current_state_.scene_ = SceneManager.getInstance().CurrentScene;
        current_state_.SetUp();
    }


        private void RemoveState()
    {
        if (current_state_ != null)
        {
            //Destroy(current_state_.gameObject);
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
