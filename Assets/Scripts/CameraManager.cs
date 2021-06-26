using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Stage3")
        {
            if (player.transform.position.x > 480 && player.transform.position.x < 3360)
            {
                transform.position = new Vector3(player.transform.position.x, 320, -10);
            }
        }





    }
}
