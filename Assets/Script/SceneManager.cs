using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager{

    Dictionary<string, SceneBase> scene_dictionary 
        = new Dictionary<string, SceneBase>();              //SceneListに登録している文字列をキーにしてシーンを登録するディクショナリ
    private GameObject current_scene_obj_;                  //現在のシーンクラスを持つオブジェクト
    private SceneBase current_scene_;                       //現在のシーン（シーン移行時に利用）
    private static SceneManager instance_;                  //Singleton用のインスタンス

    public SceneBase CurrentScene
    {
        get
        {
            return current_scene_;
        }
    }

    //Singleton
    public static SceneManager getInstance()
    {
        if (instance_== null)
        {
            instance_ = new SceneManager();
        }
        if (instance_ == null)
        {
            Debug.LogError("SceneManagerが存在しません。");
        }
        return instance_;
    }

    public void NextScene(string scene_name, object scene_params)
    {
        RemoveScene();
        AddScene(scene_name, scene_params);
        //Debug.Log(scene_name);
        current_scene_.Init(scene_params);
    }

    private void AddScene(string scene_name, object scene_params)
    {
        if (Resources.Load(scene_name) == null){
            Debug.LogError("Resourcesにプレハブが存在しません");
        }
        current_scene_obj_ = (GameObject)Resources.Load(scene_name);
        current_scene_ = (SceneBase)current_scene_obj_.GetComponent(System.Type.GetType(scene_name));
        scene_dictionary[scene_name] = current_scene_;        
    }

    private void RemoveScene()
    {
        if(current_scene_ != null)
        {
            current_scene_obj_ = null;
            current_scene_ = null;
        }
    }
    private void Init()
    {

    }
}

