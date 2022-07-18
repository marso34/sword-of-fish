using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart__ : MonoBehaviour
{
    public GameObject StopPanel;
    void Start()
    {
        
    }

    // Update is called once per frame   
    public void OnClick()
    {
        Time.timeScale = 1;
        StopPanel.SetActive(false);
    }
}
