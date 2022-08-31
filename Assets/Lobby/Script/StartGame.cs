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

        GM.transform.GetChild(0).gameObject.SetActive(true);
        if (QM.GetComponent<QuestManager>().Level_ != 0 && QM.GetComponent<QuestManager>().Level_ % 2 == 0 && QM.GetComponent<QuestManager>().IngameLevel == 1)
        {
            InGame.transform.GetChild(0).gameObject.SetActive(false);
            InGame.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            InGame.transform.GetChild(0).gameObject.SetActive(true);
            InGame.transform.GetChild(1).gameObject.SetActive(false);
        }
        GMC.SetActive(false);
        //LBanner.GetComponent<AddmobBanner>().DestroyAd();

        if (QM.GetComponent<QuestManager>().Level_ % 2 == 1)
        {
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            Cam.transform.position = new Vector3(0, 0, Cam.transform.position.z);
        }
        GM.GetComponent<GameManager_>().Start___();
        QM.GetComponent<QuestManager>().Score = 0;
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
