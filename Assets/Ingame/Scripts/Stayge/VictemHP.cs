using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
public class VictemHP : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject VT;
    void Start()
    {
        // VT = GameObject.FindGameObjectWithTag("Victem");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = VT.GetComponent<VictemScript>().HP.ToString() + " / " + "10";
    }
}
