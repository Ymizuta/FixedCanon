using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StageFinishState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        ((StageScene)scene_).StageResultUi = ((StageScene)scene_).GetComponent<StageResultUi>();
        if (scene_.GetComponent<StageScene>().IsGameClear)
        {
            Debug.Log("フィニッシュ：ゲームクリア！");
            //ステージUIのゲームオブジェクトを取得
            ((StageScene)scene_).StageResultUi.ClearUiObj = GetResouceInstance("UI/ClearUi");
            ((StageScene)scene_).StageResultUi.NextStageButton = GameObject.Find("NextStageButton");
            ((StageScene)scene_).StageResultUi.ToStageSelectButton = GameObject.Find("ToStageSelectButton");
            ((StageScene)scene_).StageResultUi.RetryButton = GameObject.Find("RetryButton");
            //UIボタンに関数を登録
            ((StageScene)scene_).StageResultUi.NextStageButton.GetComponent<Button>().onClick.AddListener(((StageScene)scene_).StageResultUi.PushNextStageButton);
            ((StageScene)scene_).StageResultUi.ToStageSelectButton.GetComponent<Button>().onClick.AddListener(((StageScene)scene_).StageResultUi.PushToStageSelectButton);
            ((StageScene)scene_).StageResultUi.RetryButton.GetComponent<Button>().onClick.AddListener(((StageScene)scene_).StageResultUi.PushRetryButton);
        }
        else
        if (scene_.GetComponent<StageScene>().IsGameOver)
        {
            Debug.Log("フィニッシュ：ゲームオーバー！");
        }
        else
        Debug.LogError("フラグが登録されていません。");
    }

    /**
     * @brief   Resourcesファルダのオブジェクトを実体化したインスタンスを返す
     * @GetResouceInstance[in] resource_path Resources内のオブジェクトのパス
     */
    private GameObject GetResouceInstance(string resource_path)
    {
        GameObject clear_ui_prefab = Resources.Load(resource_path) as GameObject;
        return Instantiate(clear_ui_prefab);
    }
}
