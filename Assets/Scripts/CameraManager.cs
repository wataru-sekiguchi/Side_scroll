using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (player.transform.position.x > 480 && player.transform.position.x < 1480)
        {
            transform.position = new Vector3(player.transform.position.x, 320, -10);
        }




    }
}
