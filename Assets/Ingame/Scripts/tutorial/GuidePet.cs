using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidePet : MonoBehaviour
{


    public GameObject Player;
    public GameObject GM;
    public GameObject Guide;
    public GameObject QM;

    public GameObject tutorial;
    public GameObject TutoBack;

    public bool lev4up = false; 
    public bool A = false;
    
    public void OnCanvas()
    {
        tutorial.SetActive(false);
        TutoBack.SetActive(false);
        GameObject.Find("Player(Clone)").transform.Find("Canvas").gameObject.SetActive(true);


    }

    public void OffCanvas() {
        tutorial.SetActive(true);

        GameObject.Find("Player(Clone)").transform.Find("Canvas").gameObject.SetActive(false);

        
    }
    public void BornGuide() 
    {
        Guide = GameObject.Find("Player(Clone)").transform.Find("GuidePet(Clone)").gameObject;
        //QM.GetComponent<QuestManager>().A = true;
        //QM.GetComponent<QuestManager>().bornguide(); 
        //Guide.transform.SetParent(Player.transform);
        Guide.transform.localPosition = new Vector3(-6, -4.05f, 0); //내려오기 전에 화면 위에 있는 위치
        

    }

    

    public void ShowMove() //가이드 물고기 자막 옆으로 이동
    {
        Vector3 destination = new Vector3(-3, -4.05f, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, destination, 0.05f);

        //QM.GetComponent<QuestManager>().HideAiSkin();

    }
    public void GoOut() //가이드 물고기 위로 다시 이동
    {


        Vector3 EndDes = new Vector3(-6, -4.05f, 0);
        Vector3 speed = Vector3.zero; 
        transform.localPosition = Vector3.Lerp(transform.localPosition, EndDes, 0.05f);
        Invoke("OnCanvas", 1f);

            
    }

    private void Update() //튜토리얼 단꼐별로 뜰 때마다 물고기 방향 고정
    {
        //transform.SetParent(Player.transform);
        TutoBack = GameObject.Find("TutoBack(Clone)");

        tutorial = GameObject.Find("Canvas").transform.Find("Tutorial(Clone)").gameObject;
        
        Player = GameObject.Find("Player(Clone)").transform.gameObject;

        Player.GetComponent<PlayerScript>().StopMove();


        //Vector3 direction = Guide.transform.localRotation * new Vector3(0,0,90);


    }

}
