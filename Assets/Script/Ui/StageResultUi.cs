using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageResultUi : MonoBehaviour {

    private GameObject clear_ui_obj_;
    private GameObject game_over_ui_obj_;
    private GameObject next_stage_button_;
    private GameObject to_stage_select_button_;
    private GameObject retry_button_;
    public UnityAction OnpushNextStageButton;
    public UnityAction OnPushStageSelectButton;
    public UnityAction OnpushRetryButton;

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
        //Debug.Log("ネクストステージ！");
        if (OnpushNextStageButton != null)
        {
            OnpushNextStageButton();
        }
    }

    public void PushToStageSelectButton()
    {
        if (OnPushStageSelectButton != null)
        {
            OnPushStageSelectButton();
        }
    }

    public void PushRetryButton()
    {
        Debug.Log("リトライ！");
        if (OnpushRetryButton != null)
        {
            OnpushRetryButton();
        }
    }

    public void RemoveStageResultUi()
    {
        if(clear_ui_obj_ != null)Destroy(clear_ui_obj_.gameObject);
        clear_ui_obj_ = null;
        if(game_over_ui_obj_ != null)Destroy(game_over_ui_obj_.gameObject);
        game_over_ui_obj_ = null;
        next_stage_button_ = null;
        to_stage_select_button_ = null;
        retry_button_ = null;
    }

}
