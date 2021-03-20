using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{

    //インスタンス用
    public static Save instance;
    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Vector3 tmp = GameObject.Find("TX Village Props Scarecrow").transform.position;

        PlayerPrefs.SetFloat("Player_x", PlayerPrefs.GetFloat("Player_x"));
        PlayerPrefs.SetString("Stage", PlayerPrefs.GetString("Stage"));

        GameObject.Find("TX Village Props Scarecrow").transform.position = new Vector3(tmp.x = PlayerPrefs.GetFloat("Player_x"), tmp.y, tmp.z);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClickSave()
    {
        Vector3 tmp = GameObject.Find("TX Village Props Scarecrow").transform.position;

        //座標保存
        Debug.Log("★ステージと座標のSAVE");
        PlayerPrefs.SetFloat("Player_x", tmp.x);
        PlayerPrefs.SetString("Stage", SceneManager.GetActiveScene().name);
        Debug.Log(PlayerPrefs.GetFloat("Player_x"));
        Debug.Log(PlayerPrefs.GetString("Stage"));

    }
    public void OnClickLoad()
    {
        Debug.Log("★ステージと座標のLOAD");
        Debug.Log(PlayerPrefs.GetFloat("Player_x"));
        Debug.Log(PlayerPrefs.GetString("Stage"));

        SceneManager.LoadScene(PlayerPrefs.GetString("Stage"));
    }
}
