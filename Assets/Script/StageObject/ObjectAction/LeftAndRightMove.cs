using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAndRightMove : MonoBehaviour {

    private float first_position_x;
    [SerializeField] private float move_speed_ = 10f;
    [SerializeField] private float MAX_DISTANCE = 5f;
    [SerializeField] private float MIN_DISTANCE = -5f;
    private bool is_x_plus_move_ = true;

    // Update is called once per frame
    private void Start()
    {
        first_position_x = this.gameObject.transform.position.x;
        is_x_plus_move_ = true;
    }

    void Update () {
        if (is_x_plus_move_)
        {
            Vector3 obj_position = this.gameObject.transform.position;
            float obj_position_x = obj_position.x;
            obj_position_x += move_speed_ * Time.deltaTime;
            obj_position.x = obj_position_x;
            this.gameObject.transform.position = obj_position;
            if( this.gameObject.transform.position.x > first_position_x + MAX_DISTANCE)
            {
                obj_position = this.gameObject.transform.position;
                obj_position.x = first_position_x + MAX_DISTANCE;
                this.gameObject.transform.position = obj_position;
                is_x_plus_move_ = false;
            }
        }else
        if (!is_x_plus_move_)
        {
            Vector3 obj_position = this.gameObject.transform.position;
            float obj_position_x = obj_position.x;
            obj_position_x -= move_speed_ * Time.deltaTime;
            obj_position.x = obj_position_x;
            this.gameObject.transform.position = obj_position;
            if (this.gameObject.transform.position.x < first_position_x + MIN_DISTANCE)
            {
                obj_position = this.gameObject.transform.position;
                obj_position.x = first_position_x + MIN_DISTANCE;
                this.gameObject.transform.position = obj_position;
                is_x_plus_move_ = true;
            }
        }
    }
}
