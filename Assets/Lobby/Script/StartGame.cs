using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject InGame;
    public GameObject QM;

    public GameObject GM;
    public GameObject GMC;



    // Start is called before the first frame update
    void Start()
    {
        //MusicFlag = false;
    }
    public void Update()
    {
        //if (MusicFlag)
        //{
        //    var a = Instantiate(IntroMusic, Vector3.zero, Quaternion.Euler(0, 0, 0));
        //   Debug.Log("À½¾Ç»ý¼º");
        //   MusicFlag = false;

        // }
    }

    // Update is called once per frame
    public void RMMusic()
    {
        // Destroy(GameObject.FindGameObjectWithTag("IntroM"));
        Debug.Log("ssss");
    }
    public void OnClick_()
    {
        //LobbyMusic.SetActive(false);
        for (int i = 0; i < 2; ++i)
        {
            if (i == QM.GetComponent<QuestManager>().Level_ - 1)
                InGame.transform.GetChild(i).gameObject.SetActive(true);
            else InGame.transform.GetChild(i).gameObject.SetActive(false);
        }
        GMC.SetActive(false);
        //LBanner.GetComponent<AddmobBanner>().DestroyAd();


        GM.GetComponent<GameManager_>().Start___();

        gameObject.SetActive(false);

        // RMMusic();

        /*GameObject[] Fleshs = new GameObject[GameObject.FindGameObjectsWithTag("Flesh").Length];
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
        }*/
    }
}
