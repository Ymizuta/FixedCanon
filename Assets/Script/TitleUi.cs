using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleUi : MonoBehaviour {

    private GameObject title_ui_obj_;
    private GameObject start_button_;
    public System.Action OnPushStartButton;

    /**
     * @brief   生成したUIオブジェクトのプロパティ
     * @detail  空のオブジェクト。画面に表示される各種表示、ボタン等のUIを一式格納。
     *          InitStateでの初期化時にResourcesディレクトリからプレハブを取得、初期化を実施。    
     */
    public GameObject TitleUiObj
    {
        get
        {
            return title_ui_obj_;
        }
        set
        {
            title_ui_obj_ = value;
        }
    }

    /**
    * @brief   STARTボタンオブジェクトを格納。
    */
    public GameObject StartButton
    {
        get
        {
            return start_button_;
        }
        set
        {
            start_button_ = value;
        }
    }

    /**
    * @brief   STARTボタン押下時の処理実行。TitleSceneへコールバック。
    */
    public void PushStartButton()
    {
        if (OnPushStartButton != null)
        {
            OnPushStartButton();
        }
    }
}
