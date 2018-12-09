using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class StageFinishState : StateBase {

	// Use this for initialization
	public override void SetUp () {
        ((StageScene)scene_).StageResultUi = ((StageScene)scene_).GetComponent<StageResultUi>();

        if (scene_.GetComponent<StageScene>().IsGameClear)
        {
            Debug.Log("フィニッシュ：ゲームクリア！");
            CreateClearUi();
        }
        else
        if (scene_.GetComponent<StageScene>().IsGameOver)
        {
            Debug.Log("フィニッシュ：ゲームオーバー！");
            CreateGameOverUi();
        }
        else
        Debug.LogError("フラグが登録されていません。");
    }

    /**
     * @brief   ゲームクリア時のリザルト画面の表示 
     */
    private void CreateClearUi()
    {
        //ステージUIのゲームオブジェクトを取得
        ((StageScene)scene_).StageResultUi.ClearUiObj = GetResouceInstance("UI/ClearUi");
        ((StageScene)scene_).StageResultUi.NextStageButton = GameObject.Find("NextStageButton");
        ((StageScene)scene_).StageResultUi.ToStageSelectButton = GameObject.Find("ToStageSelectButton");
        ((StageScene)scene_).StageResultUi.RetryButton = GameObject.Find("RetryButton");
        //UIボタンに関数を登録
        ((StageScene)scene_).StageResultUi.NextStageButton.GetComponent<Button>().onClick.AddListener(((StageScene)scene_).StageResultUi.PushNextStageButton);
        ((StageScene)scene_).StageResultUi.ToStageSelectButton.GetComponent<Button>().onClick.AddListener(((StageScene)scene_).StageResultUi.PushToStageSelectButton);
        ((StageScene)scene_).StageResultUi.RetryButton.GetComponent<Button>().onClick.AddListener(((StageScene)scene_).StageResultUi.PushRetryButton);
        //コールバック関数を登録
        ((StageScene)scene_).StageResultUi.OnpushNextStageButton += OnPushNextStageButtonCallBack;
        ((StageScene)scene_).StageResultUi.OnPushStageSelectButton += OnPushStageSelectButtonCallBack;
        //((StageScene)scene_).StageResultUi.OnpushNextStageButton
    }

    /**
     * @brief   ゲームオーバー時のリザルト画面の表示 
     */
    private void CreateGameOverUi()
    {
        //ステージUIのゲームオブジェクトを取得
        ((StageScene)scene_).StageResultUi. GameOverUiObj = GetResouceInstance("UI/GameOverUi");
        ((StageScene)scene_).StageResultUi.ToStageSelectButton = GameObject.Find("ToStageSelectButton");
        ((StageScene)scene_).StageResultUi.RetryButton = GameObject.Find("RetryButton");
        //UIボタンに関数を登録
        ((StageScene)scene_).StageResultUi.ToStageSelectButton.GetComponent<Button>().onClick.AddListener(((StageScene)scene_).StageResultUi.PushToStageSelectButton);
        ((StageScene)scene_).StageResultUi.RetryButton.GetComponent<Button>().onClick.AddListener(((StageScene)scene_).StageResultUi.PushRetryButton);
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

    private void OnPushNextStageButtonCallBack()
    {
        /*
         * ステート切り替えパターン
         */
        ////プレイヤー初期化
        Destroy(((StageScene)scene_).PlyerClone.gameObject);
        ((StageScene)scene_).PlyerClone = null;
        ((StageScene)scene_).Player = null;

        ////1フレーム待機
        //GlobalCoroutine.Go(DelayMethod(1, () =>
        //{
        //    Debug.Log("Delay call");
        //}));

        ((StageScene)scene_).BulletManager = null;

        Destroy(((StageScene)scene_).StageObjectManager.Params.StageObjClone);
        ((StageScene)scene_).StageObjectManager.Params.StageObjClone = null;
        ((StageScene)scene_).StageObjectManager.Params.StageObject = null;
        ((StageScene)scene_).StageObjectManager.Params.TargetObjectList = null;
        ((StageScene)scene_).StageObjectManager.Params.NormalObjectList = null;
        ((StageScene)scene_).StageObjectManager.Params = null;
        ((StageScene)scene_).StageObjectManager = null;

        Destroy(((StageScene)scene_).StageUi.gameObject);
        ((StageScene)scene_).StageUi = null;
        ((StageScene)scene_).StageInfo = null;
        ((StageScene)scene_).StageResultUi.RemoveStageResultUi();
        ((StageScene)scene_).StageResultUi = null;
        ((StageScene)scene_).StageId++;
        scene_.ChangeState(StateList.StageInitState, null);
        scene_ = null;

        /**
         * ステージ切り替えパターン
         */
        //((StageScene)scene_).ResetScene();
        //////1フレーム待機
        ////GlobalCoroutine.Go(DelayMethod(10, () =>
        ////{
        ////    Debug.Log("Delay call");
        ////}));
        //((StageScene)scene_).StageId++;
        //ChangeScene(SceneList.StageScene, ((StageScene)scene_).StageId);
        //scene_.CurrentState = null;
        //scene_ = null;
    }

    private void OnPushStageSelectButtonCallBack()
    {
        ChangeScene(SceneList.StageSelectScene,null);
        //処理の呼び方・内容については要検討
        ((StageScene)scene_).ResetScene();
        scene_ = null;
    }

    private void OnPushRetryButtonCallBack()
    {

    }

    //１フレーム待機
    private IEnumerator DelayMethod(int delayFrameCount, Action action)
    {
        for (var i = 0; i < delayFrameCount; i++)
        {
            yield return null;
        }
        action();
    }
}
