using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    [SerializeField] SceneBase title_scene = null;
    [SerializeField] SceneBase stage_scene = null;
    [SerializeField] SceneBase stage_select_scene = null;
    Dictionary<string, SceneBase> scene_ = new Dictionary<string, SceneBase>();
    private SceneBase current_scene_;

    private void Start()
    {
        scene_[SceneList.TitleScene] = title_scene;
        scene_[SceneList.StageSelectScene] = stage_scene;
        scene_[SceneList.StageScene] = stage_select_scene;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextScene(SceneList.StageScene, null);
        }
    }

    public void NextScene(string scene_name, object scene_params)
    {
        RemoveScene();
        AddScene(scene_name, scene_params);
    }

    private void AddScene(string scene_name, object scene_params)
    {
        //string className_ = scene_name;
        //System.Type type_ = System.Type.GetType(className_);
        //current_scene_ = (SceneBase)System.Activator.CreateInstance(type_);
        current_scene_ = Instantiate(scene_[scene_name]);
    }

    private void RemoveScene()
    {
        if(current_scene_ != null)
        {
        GameObject.Destroy(current_scene_.gameObject);
        current_scene_ = null;
        }
    }
    private void Init()
    {

    }
}
