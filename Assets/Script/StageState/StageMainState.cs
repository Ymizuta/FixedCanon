using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMainState : StateBase {

    [SerializeField] GameObject player_ = null;
    private GameObject player_clone_;

	// Use this for initialization
	void Start () {
        Init();
        player_clone_ = Instantiate(player_) as GameObject;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ゲームクリアORゲームオーバー");
            scene_.ChangeState(StateList.StageFinishState);
        }
    }
}
