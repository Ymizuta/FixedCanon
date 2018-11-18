using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonMove : MonoBehaviour {

    [SerializeField] GameObject canon_base_;        //砲台オブジェクト（エディターから登録）
    private Vector3 canon_base_angle;               //砲台の角度
    private float horizon_angle_value;              //砲台の水平角度の値
    private float add_canon_base_angle = 1f;        //回転の係数(数値変更で回転速度調整)
    const float max_horizontal_angle = 45f;         //回転範囲
    const float min_horizontal_angle = -45f;        //回転範囲

    private void Start()
    {
        //砲台の初期角度
        canon_base_angle = canon_base_.transform.rotation.eulerAngles;
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

    public void Move()
    {
        Debug.Log("Move");
    }

}
