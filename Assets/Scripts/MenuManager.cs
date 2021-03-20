using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject MenuBG;
    public GameObject MenuOpenButton;
    public GameObject MenuCloseButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickMenuOpenButton()
    {
        MenuBG.SetActive(true);
        MenuOpenButton.SetActive(false);
        MenuCloseButton.SetActive(true);
    }
    public void OnClickMenuCloseButton()
    {
        MenuBG.SetActive(false);
        MenuOpenButton.SetActive(true);
        MenuCloseButton.SetActive(false);
    }

    public void OnClickTitleBackButton()
    {
        SceneManager.LoadScene("Title");
    }
}
