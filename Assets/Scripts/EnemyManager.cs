using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private Rigidbody2D rbody;          // 制御用rigidbody2D

    private float arrowSpeed = -1000;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();   // 開始時にRigidbody2Dコンポーネントをセットし、物理エンジンを利用可能にしている
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {

        rbody.velocity = new Vector2(arrowSpeed, rbody.velocity.y);   // Rigidbody2Dコンポーネントのvelocityに速度を設定、y軸は変更がないのでそのまま

    }




}
