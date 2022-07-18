using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Set4 : MonoBehaviour
{

    private Sprite Set4OnImg;
    public Sprite Set4OffImg;
    public Button button;
    private bool IsOn = true;   //±âº»°ª ÄÑÁü

    public void Start()
    {
        Set4OnImg = button.GetComponent<Image>().sprite;
    }

    public void OnClick()
    {
        if (IsOn)
        {
            button.GetComponent<Image>().sprite = Set4OffImg;
            IsOn = false;
        }
        else
        {
            button.GetComponent<Image>().sprite = Set4OnImg;
            IsOn = true;
        }
    }
}
