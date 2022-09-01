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
    public GameObject QM;
    public void Start()
    {
        //Set3OnImg = button.GetComponent<Image>().sprite;
    }

    public void OnClick()
    {
        QM = GameObject.FindGameObjectWithTag("QM");
        if(QM.GetComponent<QuestManager>().Level_ >1) QM.GetComponent<QuestManager>().Level_ = 1;
       
    }
}
