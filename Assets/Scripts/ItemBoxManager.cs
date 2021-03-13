using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ItemBoxManager : MonoBehaviour
{
    public GameObject getAppleText;
    private int getApplesCount = 0;      // 


    // Start is called before the first frame update
    void Start()
    {
        RefreshItemCount();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshItemCount();
    }


    public void AddCount(int val)
    {
        getApplesCount += val;
        Debug.Log(getApplesCount);
    }


    // 
    public void RefreshItemCount()
    {
        getAppleText.GetComponent<Text>().text = getApplesCount.ToString();
    }


}
