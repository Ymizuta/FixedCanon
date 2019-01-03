using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingUi : MonoBehaviour {

    /// <summary>
    /// @ brief     アタッチしたTextオブジェクトを点滅させるクラス
    /// @ detail    colorのalfa値をUpdateで増減
    /// </summary>

    private Text text_;                     //点滅させるテキストオブジェクト
    private float add_alfa_value_ = 1.0f;   //一秒間に点滅させる頻度を調整するための値

	// Use this for initialization
	void Start () {
        text_ = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        float alfa_value_ = text_.color.a;
        if (alfa_value_ < 0 || 1 < alfa_value_)
        {
            add_alfa_value_ = add_alfa_value_ * -1;
        }
        alfa_value_ += (add_alfa_value_ * Time.deltaTime);
        Color text_color = text_.color;
        text_color.a = alfa_value_;
        text_.color = text_color;
    }
}
