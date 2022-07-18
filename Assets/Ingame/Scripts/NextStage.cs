using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    public GameObject GM;
    // Start is called before the first frame update
    public GameObject QM;
   
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        QM = GameObject.FindGameObjectWithTag("QM");
    }

   public void OnClick()
    {
        GM.GetComponent<GameManager_>().GoNext();
        GM.GetComponent<GameManager_>().SuccesFlag = false;
        QM.GetComponent<QuestManager>().Flag = true;
        QM.GetComponent<QuestManager>().LoseFlag = false;
        Destroy(GameObject.FindGameObjectWithTag("Stayge"));
        QM.GetComponent<QuestManager>().Init_Stayge();
        
    }
    public void OnClick2()
    {
        GM.GetComponent<GameManager_>().ReStart_();
        GM.GetComponent<GameManager_>().SuccesFlag = false;
        QM.GetComponent<QuestManager>().Flag = true;
        QM.GetComponent<QuestManager>().LoseFlag = false;
        Destroy(GameObject.FindGameObjectWithTag("Stayge"));
        QM.GetComponent<QuestManager>().Init_Stayge();
       
    }
}
