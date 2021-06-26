using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverText;
    public GameObject gameClearText;

    private float create_Timer;
    private float INTERVAL = 1.0f;
    private int SceneNo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (create_Timer > 0)
        {
            //Debug.Log("create_Timer = " + create_Timer);
            create_Timer -= Time.deltaTime;            
        }
        if (create_Timer < 0)
        {
            //Debug.Log("AfterCountFadeOut");
            FadeManager.FadeOut(SceneNo);
        }

    }

    public enum GAME_MODE
    {
        PLAY,
        CLEAR,
    };

    public GAME_MODE gameMode = GAME_MODE.PLAY;

    public void GameClear(int SceneNo)
    {
        gameMode = GAME_MODE.CLEAR;
        gameClearText.SetActive(true);
        create_Timer = INTERVAL;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        create_Timer = INTERVAL;
        SceneNo = 0;
    }
}
