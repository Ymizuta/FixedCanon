using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TitleInitState : StateBase {

	// Use this for initialization
	void Start () {
        Init();
        //scene_.ChangeState(StateList.TitleMainState,null);
        TitleScene title_scene = ((TitleScene)scene_);
        GameObject title_ui_prefab = Resources.Load("UI\\TitleUi") as GameObject;
        title_scene.TitleUi.TitleUiObj = Instantiate(title_ui_prefab);
        title_scene.TitleUi.StartButton = GameObject.Find(UiList.StartButton).gameObject;
        UnityAction PushStartButton = title_scene.TitleUi.PushStartButton;
        title_scene.TitleUi.StartButton.GetComponent<Button>().onClick.AddListener(PushStartButton);
        //ステート移行
        scene_.ChangeState(StateList.TitleMainState, null);
    }
}
