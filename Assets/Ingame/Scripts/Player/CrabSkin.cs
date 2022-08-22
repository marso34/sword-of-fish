using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSkin : MonoBehaviour
{
    public SpriteRenderer[] Skin;
    public GameObject[] Child; // 0 ~ 12까지 자식 오브젝트, 아래 Sprite 순서 그대로
    public Sprite[] Head;
    public Sprite[] Eye;
    public Sprite[] L1;
    public Sprite[] L2;
    public Sprite[] L3;
    public Sprite[] L4;
    public Sprite[] R1;
    public Sprite[] R2;
    public Sprite[] R3;
    public Sprite[] R4;
    public Sprite[] T1;
    public Sprite[] T2;
    public Sprite[] T3;

    public int HP;

    void Start()
    {
        for (int i = 0; i < 13; i++)
        {
            Skin[i] = Child[i].GetComponent<SpriteRenderer>();
        }
        StartCoroutine("Start_");
    }

    void Update()
    {
        HP = transform.GetComponent<KingCrab>().HP;

        // if ( ) // 페이즈2에서 쓰레기 끄기
        // {
        //     Child[10].transform.gameObject.SetActive(false);
        //     Child[11].transform.gameObject.SetActive(false);
        // }
    }   

    public IEnumerator Start_()
    {
        while (true) yield return StartCoroutine("ChangeImg");
    }
    public IEnumerator ChangeImg()//움직임애니매이션재생
    {
        for (int i = 0; i < 10; ++i)
        {
            Skin[0].sprite = Head[i];
            Skin[1].sprite = Eye[i];
            Skin[2].sprite = L1[i];
            Skin[3].sprite = L2[i];
            Skin[4].sprite = L3[i];
            Skin[5].sprite = L4[i];
            Skin[6].sprite = R1[i];
            Skin[7].sprite = R2[i];
            Skin[8].sprite = R3[i];
            Skin[9].sprite = R4[i];
            Skin[10].sprite = T1[i];
            Skin[11].sprite = T2[i];
            Skin[12].sprite = T3[i];

            yield return new WaitForSeconds(0.1f);
        }
    }
}
