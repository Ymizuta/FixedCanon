using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageSelectUIMethod : MonoBehaviour {

    private StageSelectScene stage_select_scene_;
    public System.Action OnPshuSelectButton;

    public void PushNextButton()
    {
        StageSelectUIController ui_controller = stage_select_scene_.StageSelectUIController;

        if (ui_controller.StageId < 5)
        {
            ui_controller.StageId++;
            ui_controller.SelectButtonText.text
                = StageSelectUIController.SelectButtonStr + ui_controller.StageId.ToString("00");
            return;
        }
        else if (ui_controller.StageId >= 5)
        {
            ui_controller.StageId = ui_controller.DefaultStageId;
            ui_controller.SelectButtonText.text
                = StageSelectUIController.SelectButtonStr + ui_controller.DefaultStageId.ToString("00");
            return;
        }
    }

    public void PushBackButton()
    {
        StageSelectUIController ui_controller = stage_select_scene_.StageSelectUIController;

        if (ui_controller.StageId > ui_controller.DefaultStageId)
        {
            ui_controller.StageId--;
            ui_controller.SelectButtonText.text
                = StageSelectUIController.SelectButtonStr + ui_controller.StageId.ToString("00");
            return;
        }
        else if (ui_controller.StageId == ui_controller.DefaultStageId)
        {
            //後ほど修正
            ui_controller.StageId = 5;
            ui_controller.SelectButtonText.text
                = StageSelectUIController.SelectButtonStr + ui_controller.StageId.ToString("00");
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

    public StageSelectScene StageSelectScene
    {
        set
        {
            stage_select_scene_ = value;
        }
    }
}
