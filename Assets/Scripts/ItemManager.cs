using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    private GameObject itemBoxManager;
    private int getApple = 1;      // 


    // Start is called before the first frame update
    void Start()
    {
        itemBoxManager = GameObject.Find("ItemBoxManager");
    }

    // Update is called once per frame
    void Update()
    {

    }


    // アイテム獲得時の処理
    public void GetItem()
    {
        Destroy(this.gameObject);    // アイテムオブジェクトの削除
        //Debug.Log("GetItem");
        itemBoxManager.GetComponent<ItemBoxManager>().AddCount(getApple);    // ItemBoxManagerの獲得数カウント処理に獲得数量を渡す
    }






}
