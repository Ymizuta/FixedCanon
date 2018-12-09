using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TestScript : MonoBehaviour {

    //private TestState test_state;
    //private TestComponent test_comp;
    private TestState a;
    private TestState b;

    // Use this for initialization
    void Start () {

        GameObject test = Resources.Load("TestState") as GameObject;
        a = test.GetComponent<TestState>();
        Debug.Log("aの中身は" + a);
        b = a;
        Debug.Log("bの中身は" + b);
        b = null;
        Debug.Log("aの中身は" + a);
        Debug.Log("bの中身は" + b);

        //Enemy enemy_1 = new Enemy("スライム", 1,new string[]{"体当たり"});
        //Enemy enemy_2 = new Enemy("ゴーレム", 100, new string[] { "ぶん殴る","防御" });
        //TestInfo test_info_1 = new TestInfo();
        //test_info_1.enemy_ = new List<Enemy>();
        //test_info_1.enemy_.Add(enemy_1);
        //test_info_1.enemy_.Add(enemy_2);

        //string str = JsonUtility.ToJson(test_info_1);
        //Debug.Log(str);

        //string json = File.ReadAllText("Assets\\_Test\\testjson.json");
        //TestInfo test_info_1 = new TestInfo();
        //test_info_1.enemy_ = new List<Enemy>();
        //test_info_1 = JsonUtility.FromJson<TestInfo>(json);
        //Debug.Log(test_info_1.enemy_.Count);
        //Debug.Log(test_info_1.enemy_[0].name_);
        //Debug.Log(test_info_1.enemy_[1].name_);
        //Debug.Log(test_info_1.enemy_[2].name_);

        ////PathからJsonファイルのデータを取得
        //string json = File.ReadAllText("Assets\\_Test\\testjson.json");
        ////インスタンス生成
        //TestInfo test_info = new TestInfo();
        //test_info.enemy_ = new List<Enemy>();
        ////クラスにJsonデータを反映
        ////List<Enemy> enemy_list = JsonUtility.FromJson<List<Enemy>>(json);
        //JsonUtility.FromJsonOverwrite(json, test_info.enemy_);
        ////検証
        ////Debug.Log(test_info.enemy_.Count);
        //Debug.Log(test_info.enemy_.Count);
        ////foreach (int i in test_info.test_data)
        ////    Debug.Log(i);

        //GameObject test_state_prefab = Resources.Load("TestState") as GameObject;
        ////GameObject test_clone = Instantiate(test_state_prefab);
        ////test_state = test_clone.GetComponent<TestState>();
        //test_state = test_state_prefab.GetComponent<TestState>();
    }

    // Update is called once per frame
    void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("サーイエッサー！");           
        //    test_comp = ((TestComponent)test_state.gameObject.AddComponent(System.Type.GetType("TestComponent")));
        //}
    }
}
