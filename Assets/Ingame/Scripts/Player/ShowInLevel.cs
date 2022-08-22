using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowInLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QM;
    public bool inflag;
    public Text T;
    public Color c;
    void Start()
    {
        T = GetComponent<Text>();
        QM = GameObject.FindGameObjectWithTag("QM");
        //c = T.GetComponent<Text>().color;
        Debug.Log(c);
    }

    // Update is called once per frame
    
    void unlookthis()
    {
        GetComponent<Text>().color = new Color(0, 0, 0, 0);
    }
    public void showText(string arr)
    {
        // Debug.Log(c);
        GetComponent<Text>().color = c;
        GetComponent<Text>().text = arr;
        Invoke("unlookthis", 2f);
    }
}
