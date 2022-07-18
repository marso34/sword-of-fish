using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Set3 : MonoBehaviour
{

    private Sprite Set3OnImg;
    public Sprite Set3OffImg;
    public Button button;
    private bool IsOn = true;   //±âº»°ª ÄÑÁü

    public void Start()
    {
        Set3OnImg = button.GetComponent<Image>().sprite;
    }

    public void OnClick()
    {
        if (IsOn)
        {
            button.GetComponent<Image>().sprite = Set3OffImg;
            IsOn = false;
        }
        else
        {
            button.GetComponent<Image>().sprite = Set3OnImg;
            IsOn = true;
        }
    }
}
