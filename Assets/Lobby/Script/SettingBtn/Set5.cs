using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Set5 : MonoBehaviour
{

    private Sprite Set5OnImg;
    public Sprite Set5OffImg;
    public Button button;
    private bool IsOn = true;   //±âº»°ª ÄÑÁü

    public void Start()
    {
        Set5OnImg = button.GetComponent<Image>().sprite;
    }

    public void OnClick()
    {
        if (IsOn)
        {
            button.GetComponent<Image>().sprite = Set5OffImg;
            IsOn = false;
        }
        else
        {
            button.GetComponent<Image>().sprite = Set5OnImg;
            IsOn = true;
        }
    }
}
