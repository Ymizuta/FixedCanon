using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUIController : MonoBehaviour {

    private GameObject stage_select_ui_;
    private GameObject select_button_;
    private GameObject next_button_;
    private GameObject back_button_;

    public GameObject StageSelectUI
    {
        get
        {
            return stage_select_ui_;
        }
        set
        {
            stage_select_ui_ = value;
        }
    }

    public GameObject SelectButton
    {
        get
        {
            return select_button_;
        }
        set
        {
            select_button_ = value;
        }
    }

    public GameObject NextButton
    {
        get
        {
            return next_button_;
        }
        set
        {
            next_button_ = value;
        }
    }

    public GameObject BackButton
    {
        get
        {
            return back_button_;
        }
        set
        {
            back_button_ = value;
        }
    }
}
