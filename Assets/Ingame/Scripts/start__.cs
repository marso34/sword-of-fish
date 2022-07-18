using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start__ : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GM;

    // Update is called once per frame
    void Update()
    {
        if (GM.GetComponent<GameManager_>().StartButtonFlag) gameObject.SetActive(false);
    }
}
