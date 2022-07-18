using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Set1 : MonoBehaviour
{

    private Sprite Set1OnImg;
    public Sprite Set1OffImg;
    public Button button;
    private bool IsOn = true;   //±âº»°ª ÄÑÁü

    public void Start()
    {
        Set1OnImg = button.GetComponent<Image>().sprite;
    }

    public void OnClick()
    {
        if(IsOn)
        {
            button.GetComponent<Image>().sprite = Set1OffImg;
            IsOn = false;
        }
        else
        {
            button.GetComponent<Image>().sprite = Set1OnImg;
            IsOn = true;
        }
    }
}
