using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLobby_ : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GM;
    public GameObject QM;
    public GameObject SP;
    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        QM = GameObject.FindGameObjectWithTag("QM");
    }
    public void OnClick_()
    {
        Debug.Log("½Ã·©µÊ?");
        Time.timeScale = 1;
        GM.GetComponent<GameManager_>().GoLobby();
        GM.GetComponent<GameManager_>().SuccesFlag = false;
        
        QM.GetComponent<QuestManager>().LoseFlag = false;  
        if(SP !=null)SP.SetActive(false);
    }
}
