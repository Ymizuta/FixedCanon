using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParams : MonoBehaviour {

    private GameObject[] bullets_obj_ = null;           //砲弾のプレハブオブジェクト
    private BulletBase[] bullets_ = null;               //砲弾のインスタンス
    private int[] number_of_bullet_;                    //砲弾の弾数
    private BulletBase loadedbullet_;                   //現在装備している砲弾
    private int bullet_index_;                          //砲弾のプレハブ/弾数のリストのインデックス(装備砲弾の変更時にインデックスを前に進める)
    private int default_bullet_index_ = 0;              //初期のインデックス
    private readonly string BULLET_PATH = "Bullet/";    //Resourcesフォルダ以下のパス

    public void AddBullet(int bullet_index)
    {
        { number_of_bullet_[bullet_index] += 3; }
    }

    //装備中の砲弾の弾数を減少
    public void ReduceBullet()
    {
        if (number_of_bullet_[bullet_index_] > 0)
        { number_of_bullet_[bullet_index_]--; }
    }

    //次のインデックス番号の砲弾を装備する
    public void SetBullet()
    {
        //配列のインデックスを１つ進める
        bullet_index_++;
        if (bullet_index_ >= bullets_.Length)
        { bullet_index_ = default_bullet_index_; }

        loadedbullet_ = bullets_[bullet_index_];
        Debug.Log("現在の弾は" + loadedbullet_);
    }

    //パラメータの初期化
    public void InitParams(StageInfo stage_info)
    {
        //配列を初期化
        bullets_obj_ = new GameObject[stage_info.UsableBullets.Length];
        bullets_ = new BulletBase[bullets_obj_.Length];
        number_of_bullet_ = new int[bullets_.Length];
        //ステージで利用可能な砲弾を取得
        for (int i = 0; i < stage_info.UsableBullets.Length; i++)
        {
            //Bulletのプレハブオブジェクトを取得
            bullets_obj_[i] = Resources.Load(BULLET_PATH + stage_info.UsableBullets[i]) as GameObject;
            //Bulletの種類ごとのコンポーネントを取得
            bullets_[i] = (BulletBase)bullets_obj_[i].GetComponent(System.Type.GetType(stage_info.UsableBullets[i]));
            //各砲弾の弾数設定
            number_of_bullet_[i] = stage_info.NumberObBullets[i];
        }
        //初期装備の弾を装備      
        bullet_index_ = default_bullet_index_;
        loadedbullet_ = bullets_[bullet_index_];        
    }

    public BulletBase LoadedBullet
    {
        get
        {
            return loadedbullet_;
        }
    }

    public BulletBase[] Bullets
    {
        get
        {
            return bullets_;
        }
    }
    public int[] NumberOfBullets
    {
        get
        {
            return number_of_bullet_;
        }
    }

    public int BulletIndex
    {
        get
        {
            return bullet_index_;
        }
    }

    private void OnDestroy()
    {
        bullets_obj_ = null;
        bullets_ = null;
        number_of_bullet_ = null;
        loadedbullet_ = null;
    }
}
