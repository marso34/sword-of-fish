using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Set2 : MonoBehaviour
{


    private Sprite Set2OnImg;
    public Sprite Set2OffImg;
    public Button button;
    private bool IsOn = true;   //±âº»°ª ÄÑÁü

    public void Start()
    {
        Set2OnImg = button.GetComponent<Image>().sprite;//image.sprite;
    }

    public void OnClick()
    {
        if (IsOn)
        {
            button.GetComponent<Image>().sprite = Set2OffImg;
            IsOn = false;
        }
        else
        {
            button.GetComponent<Image>().sprite = Set2OnImg;
            IsOn = true;
        }
    }


}
