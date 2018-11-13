using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    private SceneBase current_scene_;

    public void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {          
            NextScene("TitleScene",null);
        }

        if (Input.GetMouseButtonDown(1))
        {
            NextScene("StageScene", null);
        }
    }

    private void Init()
    {
        
    }

    public void NextScene(string scene_name,object scene_params)
    {
        RemoveScene(current_scene_);
        AddScene(scene_name,scene_params);
    }

    private void AddScene(string scene_name, object scene_params)
    {
        string className_ = scene_name;
        System.Type type_ = System.Type.GetType(className_);
        current_scene_ = (SceneBase)System.Activator.CreateInstance(type_);        
    }

    private void RemoveScene(SceneBase scene_)
    {
        Debug.Log(current_scene_ + "削除");
        current_scene_ = null;
    }

}
