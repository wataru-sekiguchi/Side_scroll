using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum GAME_MODE
    {
        PLAY,
        CLEAR,
    };

    public GAME_MODE gameMode = GAME_MODE.PLAY;

    public void GameClear()
    {
        gameMode = GAME_MODE.CLEAR;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
    }
}
