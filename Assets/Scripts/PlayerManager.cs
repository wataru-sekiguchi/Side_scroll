using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject goalManager;

    public LayerMask tileMapLayer;		// ブロックレイヤー

    private Rigidbody2D rbody;          // プレイヤー制御用rigidbody2D
    private const float MOVE_SPEED = 200; // 移動速度固定値
    private float moveSpeed;                   // 移動速度
    private float jumpPower = 30000;      // ジャンプの力
    private bool goJump = false;        // ジャンプしたか否か
    private bool canJump = false;		// ブロックに設置しているか否か
    private bool usingButtons = false;	// ボタンを押しているか否か
 
    public enum MOVE_DIR
    {                      // 移動方向定義、ここで定義したものをmoveDirectionに記録
        STOP,
        LEFT,
        RIGHT,
    };

    private MOVE_DIR moveDirection = MOVE_DIR.STOP;   // 移動方向、開始時は動いていないのでMOVE_DIR.STOPをセット


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();   // 開始時にRigidbody2Dコンポーネントをセットし、物理エンジンを利用可能にしている
    }

    // Update is called once per frame
    void Update()
    {
        // 足元の衝突判定、特定のLayerに属するColliberが存在する場合、trueを返す
        canJump =
        Physics2D.Linecast(transform.position - (transform.right * 100.5f),
               transform.position - (transform.up * 100.3f), tileMapLayer) ||
        Physics2D.Linecast(transform.position + (transform.right * 100.5f),
               transform.position - (transform.up * 100.3f), tileMapLayer);

        if (!usingButtons)
        {
            float x = Input.GetAxisRaw("Horizontal");     // GetAxisRawでキーボードやジョイスティックの状態を取得、Horizontalは左右、Verticalは上下キーの状態を取得、左・下が押されていたら-1、右・上なら1を返す
            if (x == 0)
            {
                moveDirection = MOVE_DIR.STOP;
            }
            else
            {
                if (x < 0)
                {
                    moveDirection = MOVE_DIR.LEFT;
                }
                else
                {
                    moveDirection = MOVE_DIR.RIGHT;
                }
            }
            if (Input.GetKeyDown("space"))
            {
                PushJumpButton();
            }
        }
    }

    void FixedUpdate()
    {
        // 移動方向（moveDirectionに設定されている現在の状態）で処理を分岐
        switch (moveDirection)
        {
            case MOVE_DIR.STOP:   // 停止
                moveSpeed = 0;
                break;
            case MOVE_DIR.LEFT:   // 左に移動
                moveSpeed = MOVE_SPEED * -1;
                //transform.localScale = new Vector2(-1, 1);   // 画像反転処理
                break;
            case MOVE_DIR.RIGHT: // 右に移動
                moveSpeed = MOVE_SPEED;
                //transform.localScale = new Vector2(1, 1);    // 画像反転処理
                break;
        }
        rbody.velocity = new Vector2(moveSpeed, rbody.velocity.y);   // Rigidbody2Dコンポーネントのvelocityに速度を設定、y軸は変更がないのでそのまま

        // ジャンプ処理、ジャンプ中かどうかを持っているgoJumpがtrueだったらrbody.AddForceメソッドに、Vector2.up（上方向）にjumpPower（ジャンプ力）をかけた値を渡す
        if (goJump)
        {
            rbody.AddForce(Vector2.up * jumpPower);
            goJump = false;
        }
    }



    ///////////////////////////////////////////////////////////////
    //
    //         画面上に操作ボタンを置く場合に使用
    //
    ///////////////////////////////////////////////////////////////


    // 左ボタンを押した
    public void PushLeftButton()
    {
        moveDirection = MOVE_DIR.LEFT;
        usingButtons = true;
    }

    ///
    // 右ボタンを押した
    public void PushRightButton()
    {
        moveDirection = MOVE_DIR.RIGHT;
        usingButtons = true;
    }

    // 移動ボタンを放した
    public void ReleaseMoveButton()
    {
        moveDirection = MOVE_DIR.STOP;
        usingButtons = false;
    }

    ///////////////////////////////////////////////////////////////
    //
    //         画面上に操作ボタンを置く場合に使用
    //
    ///////////////////////////////////////////////////////////////


    // ジャンプボタンを押した
    public void PushJumpButton()
    {
        Debug.Log("space");
        Debug.Log(canJump);
        if (canJump)
        {
            goJump = true;
        }
    }






    // 衝突判定
    void OnTriggerEnter2D(Collider2D col)
    {
        if (goalManager.GetComponent<GoalManager>().gameMode != GoalManager.GAME_MODE.PLAY)
        {
            return;
        }


        if (col.gameObject.tag == "Trap")
        {
            Debug.Log("Death");
        }

        // ゴール用のオブジェクトとの衝突判定
        if (col.gameObject.tag == "Goal")
        {
            Debug.Log("Clear");
        }
    }



}
