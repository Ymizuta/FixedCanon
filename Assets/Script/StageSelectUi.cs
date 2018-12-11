using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectUi : MonoBehaviour {

    private GameObject stage_select_ui_obj_;    //StageSelectSceneのUIを格納する空のオブジェクト
    private GameObject select_button_;          //選択ボタンオブジェクト
    private GameObject next_button_;            //ネクストボタンオブジェクト
    private GameObject back_button_;            //バックボタンオブジェクト
    private GameObject text_obj_;               //選択ボタンのテキストオブジェクト
    private Text select_button_text_;
    private int default_stage_id_ = 1;
    private int stage_id_;
    private int saved_stage_id_;
    public System.Action OnPshuSelectButton;
    public static readonly string SelectButtonStr = "STAGE:";

    /**
     * @brief   生成したUIオブジェクトのプロパティ
     * @detail  空のオブジェクト。画面に表示される各種表示、ボタン等のUIを一式格納。
     *          InitStateでの初期化時にResourcesディレクトリからプレハブを取得、初期化を実施。    
     */
    public GameObject StageSelectUiObj
    {
        get
        {
            return stage_select_ui_obj_;
        }
        set
        {
            stage_select_ui_obj_ = value;
        }
    }
    
    /**
     * @brief   セレクトボタンオブジェクトを格納。
     */
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
    
    /**
     * @brief   NEXTボタンオブジェクトを格納。
     */
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
    
    /**
     * @brief   BACKボタンオブジェクトを格納。
     */
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
    
    /**
     * @brief   SELECTボタンオブジェクトの紐づくTEXTオブジェクトを格納。
     */
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
    
    /**
     * @brief   SELECTボタンオブジェクトの紐づくTEXTオブジェクトのテキストコンポーネントを格納。
     */
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
    
    /**
     * @brief   SELECTボタンに表示されるステージ番号の初期値。
     */
    public int DefaultStageId
    {
        get
        {
            return default_stage_id_;
        }
    }

    /**
     * @brief   SELECTボタンに表示されるステージ番号。NEXT/BACKボタンに連動して増減。
     */
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

    /**
     * @brief   セーブデータから最新のクリア済みステージIDを格納する。
     */
    public int SavedStageId
    {
        get
        {
            return saved_stage_id_;
        }
        set
        {
            saved_stage_id_ = value;
        }
    }

    /**
     * @brief   NEXTボタン押下時の処理実行。一つ次ステージを表示。
     */
    public void PushNextButton()
    {
        if (stage_id_ < saved_stage_id_)
        {
            stage_id_++;
            select_button_text_.text = SelectButtonStr + stage_id_.ToString("00");
            return;
        }
        else if (stage_id_ >= saved_stage_id_)
        {
            stage_id_ = default_stage_id_;
            select_button_text_.text = SelectButtonStr + default_stage_id_.ToString("00");
            return;
        }
    }

    /**
     * @brief   BACKボタン押下時の処理実行。一つ前のステージを表示。
     */
    public void PushBackButton()
    {
        if (stage_id_ > default_stage_id_)
        {
            stage_id_--;
            select_button_text_.text = SelectButtonStr + stage_id_.ToString("00");
            return;
        }
        else if (stage_id_ == default_stage_id_)
        {
            //後ほど修正
            stage_id_ = 5;
            select_button_text_.text = SelectButtonStr + stage_id_.ToString("00");
            return;
        }
    }

    public void PushSelectButton()
    {
        if (OnPshuSelectButton != null)
        {
            OnPshuSelectButton();
        }
    }

    private void OnDestroy()
    {
        Destroy(stage_select_ui_obj_);
        stage_select_ui_obj_ = null;
        select_button_ = null;
        next_button_ = null;
        back_button_ = null;
        text_obj_ = null;
        select_button_text_ = null;
    }
}
