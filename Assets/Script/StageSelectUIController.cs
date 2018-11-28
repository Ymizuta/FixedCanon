using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectUIController : MonoBehaviour {

    private GameObject stage_select_ui_;        //StageSelectSceneのUIを格納する空のオブジェクト
    private GameObject select_button_;          //選択ボタンオブジェクト
    private GameObject next_button_;            //ネクストボタンオブジェクト
    private GameObject back_button_;            //バックボタンオブジェクト
    private GameObject text_obj_;               //選択ボタンのテキストオブジェクト
    private Text select_button_text_;
    private int default_stage_id_ = 1;
    private int stage_id_;
    public static readonly string SelectButtonStr = "STAGE:";

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

    public GameObject TextObj
    {
        get
        {
            return text_obj_;
        }
        set
        {
            text_obj_ = value;
        }
    }

    public Text SelectButtonText
    {
        get
        {
            return select_button_text_;
        }
        set
        {
            select_button_text_ = value;
        }
    }

    public int DefaultStageId
    {
        get
        {
            return default_stage_id_;
        }
    }

    public int StageId
    {
        get
        {
            return stage_id_;
        }
        set
        {
            stage_id_ = value;
        }
    }

    private void OnDestroy()
    {
        Destroy(stage_select_ui_);
        stage_select_ui_ = null;
        select_button_ = null;
        next_button_ = null;
        back_button_ = null;
        text_obj_ = null;
        select_button_text_ = null;
    }
}
