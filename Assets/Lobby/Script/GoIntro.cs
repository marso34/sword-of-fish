using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoIntro : MonoBehaviour
{

    public GameObject Lobby;
    public GameObject LBanner;
    public GameObject GM;
    public GameObject GMC;
    public GameObject IntroPanel;
    public GameObject QM;
    public GameObject OffAd;
    public GameObject Ingame;
    // Start is called before the first frame update
    void Start()
    {

        //데이터 베이스 에서 가저오기
    }

    // Update is called once per frame
    
    public void OnClick()
    {
        //LobbyMusic.SetActive(false);
       // OffAd.GetComponent<AddmobBanner>().HideAd();
      
        Lobby.SetActive(false);
        GMC.SetActive(false);
        Ingame.SetActive(true);
        IntroPanel.SetActive(true);
        QM.GetComponent<QuestManager>().Init_Stayge();
        
        //LBanner.GetComponent<AddmobBanner>().DestroyAd();

        GameObject[] Fleshs = new GameObject[GameObject.FindGameObjectsWithTag("Flesh").Length];
        Debug.Log(Fleshs.Length);
        for (int i = 0; i < Fleshs.Length; ++i)
        {
            if (Fleshs[i] != null)
            {
                Debug.Log(Fleshs[i]);
                Fleshs[i].GetComponent<flesh>().eraser_();
            }
        }
        GameObject[] Bubbles = new GameObject[GameObject.FindGameObjectsWithTag("Bubble").Length];
        Debug.Log(Bubbles.Length);
        for (int i = 0; i < Bubbles.Length; ++i)
        {
            if (Bubbles[i] != null)
            {
                Debug.Log(Bubbles[i]);
                Bubbles[i].GetComponent<bubble>().eraser();
            }
        }
    }
}
