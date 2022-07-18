using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Set6 : MonoBehaviour
{


    private Sprite Set6OnImg;
    public Sprite Set6OffImg;
    public Button button;
    private bool IsOn = true;   //±âº»°ª ÄÑÁü

    public void Start()
    {
        Set6OnImg = button.GetComponent<Image>().sprite;
    }

    public void OnClick()
    {
        if (IsOn)
        {
            button.GetComponent<Image>().sprite = Set6OffImg;
            IsOn = false;
        }
        else
        {
            button.GetComponent<Image>().sprite = Set6OnImg;
            IsOn = true;
        }
    }
}
