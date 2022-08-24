using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("effect").gameObject.transform.localScale *= 1.2f;
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    public void SetEffect(int i)
    {
        if (i == 0) // trash, ���
        {
            transform.Find("effect").gameObject.SetActive(false);
        }
        else if (i == 1) // BigTrash
        {
            transform.Find("effect1").gameObject.SetActive(false);
            transform.Find("effect2").gameObject.transform.localScale *= 0.4f;
            transform.Find("effect3").gameObject.transform.localScale *= 0.4f;
        }
        else if (i == 2) // ũ�� ��ų
        {
            transform.Find("effect").gameObject.SetActive(false);
            transform.Find("effect1").gameObject.SetActive(false);
            transform.Find("effect2").gameObject.SetActive(false);
            transform.Find("effect4").gameObject.SetActive(true);
            transform.Find("effect5").gameObject.SetActive(true);
        }
    }
}
