using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    private static FlagManager instance = null; // シングルトン唯一のインスタンスを宣言
    public static FlagManager Instance  //  インスタンス（instance）を、プロパティ（Instance）でのみ取得させるプロパティ
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<FlagManager>(); // Component「FlagManager」を持っているGameObjectを検索

                if (instance == null)
                {
                    instance = new GameObject("FlagManager").AddComponent<FlagManager>(); // GameObject「FlagManager」に、Component「FlagManager」を追加
                }
            }
            return instance;
        }
    }

    void Awake()    // シーン間でもインスタンスのオブジェクトが1つになるようにする
    {
        if (Instance == this)    // 変数instanceにFlagManagerが入っていたら
        {
            DontDestroyOnLoad(gameObject);    // GameObjectを破棄しない
        }
        else
        {
            Destroy(gameObject);    // GameObjectを破棄
        }
    }

    public bool[] flags = new bool[128];    // 配列「flags」にbool型で要素数を指定
    public int[] ItemFlags = new int[10];
    public Dictionary<string, int> itemFlags = new Dictionary<string, int>();   // Dictionaryの宣言

    [ContextMenu("ResetFlags")]    // inspector上で右クリックした際のメニューを追加
    public void ResetFlags()
    {
        flags = new bool[flags.Length];    // 現在の要素数と同じ数の要素を指定し値をクリア
    }
}
