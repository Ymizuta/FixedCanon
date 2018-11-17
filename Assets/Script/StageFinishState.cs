using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFinishState : StateBase {

    private void Start()
    {
        Debug.Log("フィニッシュステート");        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("リトライ");
            scene_.ChangeState(StateList.StageMainState);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("ステージセレクトへ");
            scene_.scene_manager.NextScene(SceneList.StageSelectScene,null);
        }
    }

}
