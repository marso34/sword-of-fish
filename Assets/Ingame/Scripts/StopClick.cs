using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopClick : MonoBehaviour
{
    public GameObject StopPanel;
    public GameObject QM;
    private void Start()
    {
        QM = GameObject.FindGameObjectWithTag("QM");
        StopPanel = GameObject.FindGameObjectWithTag("C").transform.GetChild(3).gameObject;
    }
    public void OnClick()
    {
        if (QM.GetComponent<QuestManager>().IngameLevel != 0)
        {
            StopPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
