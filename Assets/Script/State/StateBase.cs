using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour {

    public SceneBase scene_;

    protected void Init()
    {
        //Debug.Log(this + "が生成された");
    }

    public virtual void SetUp(){}

    //フィニッシュステートでの処理時等にシーン遷移を実行
    protected void ChangeScene(string scene_name,object scene_params)
    {
        SceneManager.getInstance().NextScene(scene_name, scene_params);
        //Destroy(this.gameObject);
    }
}
