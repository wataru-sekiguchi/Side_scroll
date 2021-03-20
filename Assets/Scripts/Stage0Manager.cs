using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Stage0Manager : MonoBehaviour
{

    //public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
