using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    public GameObject Loading;      //로딩 패널
    void Start()        
    {
        Invoke("StopShowLoading", 1f);  //로딩 1초
    }

    void StopShowLoading()
    {
        Loading.SetActive(false);   //로딩 없앰
        SceneManager.LoadScene("LobbyScene");   //로비 씬으로 이동
    }
}
