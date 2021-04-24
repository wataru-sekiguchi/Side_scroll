using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private GameObject playerManager;

    private const int SPEED = 1000; //弾の速さ
    private const float ROTATION = 45; // 移動速度固定値
    private int direction = 1; // 発射方向


    private Rigidbody2D rbody;    // 制御用rigidbody2D

    void Awake()
    {
        playerManager = GameObject.Find("Player");
        BulletDirection();

    }


    public void BulletDirection()
    {
        direction = playerManager.GetComponent<PlayerManager>().direction;
        //Debug.Log("direction"+ direction);

        rbody = GetComponent<Rigidbody2D>();   // 開始時にRigidbody2Dコンポーネントをセットし、物理エンジンを利用可能にしている

        // 弾を移動させる
        //rbody.velocity = (transform.right.normalized * SPEED);



        Vector2 v;
        v.x = Mathf.Cos(Mathf.Deg2Rad * ROTATION * direction) * SPEED * direction;
        v.y = Mathf.Sin(Mathf.Deg2Rad * ROTATION * direction) * SPEED * direction;
        rbody.velocity = v;
    }

    // 衝突判定
    void OnTriggerEnter2D(Collider2D col)
    {

        // 地面との衝突判定
        if (col.gameObject.tag == "Tile")
        {
            Destroy(this.gameObject);
        }

        //// アイテムオブジェクトとの衝突判定
        //if (col.gameObject.tag == "Item")
        //{
        //    col.gameObject.GetComponent<ItemManager>().GetItem();
        //    Debug.Log("GetItem");
        //}


        //// ゴール用オブジェクトとの衝突判定
        //if (col.gameObject.tag == "Goal")
        //{
        //    Debug.Log("Clear");
        //}
    }

}
