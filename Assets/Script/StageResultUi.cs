using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageResultUi : MonoBehaviour {

    private GameObject clear_ui_obj_;
    private GameObject game_over_ui_obj_;
    private GameObject next_stage_button_;
    private GameObject to_stage_select_button_;
    private GameObject retry_button_;
    
    public GameObject ClearUiObj
    {
        get
        {
            return clear_ui_obj_;
        }
        set
        {
            clear_ui_obj_ = value;
        }
    }

    public GameObject GameOverUiObj
    {
        get
        {
            return game_over_ui_obj_;
        }
        set
        {
            game_over_ui_obj_ = value;
        }
    }

    public GameObject NextStageButton
    {
        get
        {
            return next_stage_button_;
        }
        set
        {
            next_stage_button_ = value;
        }
    }

    public GameObject ToStageSelectButton
    {
        get
        {
            return to_stage_select_button_;
        }
        set
        {
            to_stage_select_button_ = value;
        }
    }

    public GameObject RetryButton
    {
        get
        {
            return retry_button_;
        }
        set
        {
            retry_button_ = value;
        }
    }

    public void PushNextStageButton()
    {
        Debug.Log("ネクストステージ！");
    }

    public void PushToStageSelectButton()
    {
        Debug.Log("ステージセレクト！");
    }

    public void PushRetryButton()
    {
        Debug.Log("リトライ！");
    }
}
