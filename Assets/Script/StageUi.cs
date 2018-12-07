using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUi : MonoBehaviour {

    private GameObject clear_ui_;
    private GameObject game_over_ui_;    
    private GameObject next_stage_button_;
    private GameObject to_stage_select_button_;
    private GameObject retry_button_;
    
    public GameObject ClearUi
    {
        get
        {
            return clear_ui_;
        }
        set
        {
            clear_ui_ = value;
        }
    }

    public GameObject GameOverUi
    {
        get
        {
            return game_over_ui_;
        }
        set
        {
            game_over_ui_ = value;
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

    }

    public void PushToStageSelectButton()
    {

    }

    public void PushRetryButton()
    {

    }
}
