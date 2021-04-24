using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

    private Rigidbody2D rbody;          // 制御用rigidbody2D
    private float MOVING_SPEED = 100;

    private GameObject PlayerObject; // playerオブジェクトを受け取る器
    private Transform Player; // プレイヤーの座標情報などを受け取る器

    private float distance;
    private float e_pos;
    private float p_pos;

    private int jumpOn;
    private float jumpPower = 35000;      // ジャンプの力
    private bool canJump = false;       // ブロックに設置しているか否か
    public LayerMask tileMapLayer;		// ブロックレイヤー

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();   // 開始時にRigidbody2Dコンポーネントをセットし、物理エンジンを利用可能にしている

        // playerのGameObjectを探して取得
        PlayerObject = GameObject.Find("Player");
        // playerのTransform情報を取得
        Player = PlayerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // -----------------
        // 追跡
        // -----------------
        //Vector2 e_pos = transform.position.x;  // 自分(敵キャラクタ)の世界座標
        //Vector2 p_pos = Player.position.x;  // プレイヤーの世界座標
        e_pos = transform.position.x;  // 自分(敵キャラクタ)の世界座標
        p_pos = Player.position.x;  // プレイヤーの世界座標

        distance = p_pos - e_pos;



        // じわじわ追跡
        //rbody.AddForce(force, ForceMode2D.Force);



        // 足元の衝突判定、特定のLayerに属するColliberが存在する場合、trueを返す
        canJump =
        Physics2D.Linecast(transform.position - (transform.right * 100.5f),
               transform.position - (transform.up * 100.3f), tileMapLayer) ||
        Physics2D.Linecast(transform.position + (transform.right * 100.5f),
               transform.position - (transform.up * 100.3f), tileMapLayer);

        jumpOn = Random.Range(0, 1000);


        if (canJump)
        {
            if (jumpOn == 0)
            {
                //Debug.Log("jump");
                rbody.AddForce(Vector2.up * jumpPower);
            }

            // プレイヤーの方向に動く(move_speedで速度を調整)
            if (distance > 50.0f)
            {
                //Debug.Log(distance);
                rbody.velocity = new Vector2(MOVING_SPEED, rbody.velocity.y);
            }
            else if (distance < -50.0f)
            {
                rbody.velocity = new Vector2(MOVING_SPEED * -1, rbody.velocity.y);
            }


        }



    }


    void FixedUpdate()
    {

        //rbody.velocity = new Vector2(MOVING_SPEED, rbody.velocity.y);   // Rigidbody2Dコンポーネントのvelocityに速度を設定、y軸は変更がないのでそのまま

    }



}
