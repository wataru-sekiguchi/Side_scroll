using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

    private Rigidbody2D rbody;          // 制御用rigidbody2D
    private float MOVING_SPEED = 100;

    private GameObject playerObject; // playerオブジェクトを受け取る器
    private GameObject gameManager; // playerオブジェクトを受け取る器

    private Transform Player; // プレイヤーの座標情報などを受け取る器

    private float distance;
    private float e_pos;
    private float p_pos;

    private int jumpOn;
    private float jumpPower = 35000;      // ジャンプの力
    private bool canJump = false;       // ブロックに設置しているか否か
    public LayerMask tileMapLayer;      // ブロックレイヤー

    private int hitCount;      // リンゴが当たった回数

    private float stopTime = 0.8f;   // 点滅時間
    private float timeMeasurement;   // 時間計測
    private bool isDamaged = false; // 弾に当たったか

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();   // 開始時にRigidbody2Dコンポーネントをセットし、物理エンジンを利用可能にしている

        // playerのGameObjectを探して取得
        playerObject = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        // playerのTransform情報を取得
        Player = playerObject.transform;
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

        //弾に当たった時の処理
        if (isDamaged)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 20));
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, level);
            timeMeasurement += Time.deltaTime;
            //Debug.Log(timeMeasurement);
            if (timeMeasurement > stopTime)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                timeMeasurement = 0.0f;
                isDamaged = false;
            }
        }



    }




    // 衝突判定
    void OnTriggerEnter2D(Collider2D col)
    {
        // リンゴと衝突判定
        if (col.gameObject.tag == "BulletApple")
        {
            hitCount += 1;
            isDamaged = true;
            //Debug.Log("Hit = " + hitCount);

            if (hitCount == 5)
            {                
                Destroy(this.gameObject);
                gameManager.GetComponent<GameManager>().GameClear(0);
            }

        }

    }



}
