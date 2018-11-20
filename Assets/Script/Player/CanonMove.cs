using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonMove : MonoBehaviour {

    //砲台の水平角度
    [SerializeField] GameObject canon_base_ = null; //砲台オブジェクト（エディターから登録）
    private Vector3 canon_base_angle;               //砲台の角度
    private float horizon_angle_value;              //砲台の水平角度の値
    private float add_canon_base_angle = 1f;        //回転の係数(数値変更で回転速度調整)
    const float max_horizontal_angle = 45f;         //回転範囲
    const float min_horizontal_angle = -45f;        //回転範囲

    //砲台の仰角
    [SerializeField] GameObject barrel_base_ = null;     //砲身オブジェクト（エディターから登録）
    private Vector3 canon_angle;                    //仰角度
    private float canon_evelation_angle;            //砲身の仰角値
    private float default_canon_evalation_angle;    //砲台の仰角の初期値
    private float add_evelation_angle = -1f;        //仰角の係数(数値変更で回転速度調整)
    const float min_elevation_angle = 0f;           //仰角範囲
    const float max_elevation_angle = 90f;          //仰角範囲

    private void Start()
    {
        ////砲台の初期角度
        //canon_base_angle = canon_base_.transform.rotation.eulerAngles;

        ////砲身の初期仰角        
        //canon_angle = barrel_.transform.rotation.eulerAngles;
    }

    //砲台の左右回転
    public void HorizontalMove(float horizontal_direction)
    {
        horizon_angle_value = canon_base_angle.y + (add_canon_base_angle * horizontal_direction);

        //砲台の角度制限
        if (horizon_angle_value >= max_horizontal_angle)
        {
            horizon_angle_value = max_horizontal_angle;
        }
        else
        if (horizon_angle_value <= min_horizontal_angle)
        {
            horizon_angle_value = min_horizontal_angle;
        }

        canon_base_angle.y = horizon_angle_value;
        canon_base_angle.x = 0;
        canon_base_angle.z = 0;
        canon_base_.transform.rotation = Quaternion.Euler(canon_base_angle);
    }

    //砲身の仰角調整
    public void VerticalMove(float vertical_direction)
    {
        canon_angle = barrel_base_.transform.rotation.eulerAngles;
        canon_evelation_angle = canon_angle.x + (add_evelation_angle * vertical_direction);

        //仰角の角度制限
        if (canon_evelation_angle <= 315f && canon_evelation_angle >= 180f)
        {
            canon_evelation_angle = 315f;
        }
        else
        if (canon_evelation_angle < 180f && canon_evelation_angle >= 0f)
        {
            canon_evelation_angle = 0f;
        }
        canon_angle.x = canon_evelation_angle;
        canon_angle.z = 0f;
        barrel_base_.transform.rotation = Quaternion.Euler(canon_angle);
    }

    //メインステート初期化時に取得
    public GameObject CanonBase
    {
        set
        {
            canon_base_ = value;
            //砲台の初期角度
            canon_base_angle = canon_base_.transform.rotation.eulerAngles;
        }
    }
    //メインステート初期化時に取得
    public GameObject BarrelBase
    {
        set
        {
            barrel_base_ = value;
            //砲身の初期仰角        
            canon_angle = barrel_base_.transform.rotation.eulerAngles;
        }
    }

}
