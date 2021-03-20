using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickOpBtn() {
        Debug.Log("OnClickOpBtn");
        PlayerPrefs.SetFloat("Player_x", 0);
        SceneManager.LoadScene("Stage0");

        
    }
    public void OnClickLoadBtn()
    {
        Debug.Log("OnClickLoadBtn");
        SceneManager.LoadScene("Stage0");
    }

}
