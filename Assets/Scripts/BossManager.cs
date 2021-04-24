using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

    private Rigidbody2D rbody;          // 制御用rigidbody2D
    private float MOVING_SPEED = 100;

    private GameObject PlayerObject; // playerオブジェクトを受け取る器
    public Transform Player; // プレイヤーの座標情報などを受け取る器

    private float distance;
    private float e_pos;
    private float p_pos;

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
        //Debug.Log(distance);

        // プレイヤーの方向に動くベクトル(move_speedで速度を調整)
        //Vector2 force = (p_pos - e_pos) * MOVING_SPEED;
        if (distance > 50.0f)
        {
            //Debug.Log(distance);
            rbody.velocity = new Vector2(MOVING_SPEED, rbody.velocity.y);
        }
        else if(distance < -50.0f)
        {
            rbody.velocity = new Vector2(MOVING_SPEED * -1, rbody.velocity.y);
        }

        // じわじわ追跡
        //rbody.AddForce(force, ForceMode2D.Force);
    }


    void FixedUpdate()
    {

        //rbody.velocity = new Vector2(MOVING_SPEED, rbody.velocity.y);   // Rigidbody2Dコンポーネントのvelocityに速度を設定、y軸は変更がないのでそのまま

    }


}
