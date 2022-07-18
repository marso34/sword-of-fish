using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KS : MonoBehaviour
{
    public GameObject GM;
    //killsound
    void Start()
    {
        Invoke("Dst", 6f);
        GM = GameObject.FindGameObjectWithTag("GM");
    }
    private void Update()
    {
        if (GM.GetComponent<GameManager_>().resetFlag) Destroy(gameObject);
    }
    void Dst()
    {
        Destroy(gameObject);
    }
    
}
