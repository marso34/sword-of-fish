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
    bool FRZFlag;

    void Start()
    {
        for (int i = 0; i < 13; i++)
            Skin[i] = Child[i].GetComponent<SpriteRenderer>();

        StartCoroutine("Start_");
    }

    void Update()
    {
        HP = transform.GetComponent<KingCrab>().HP;
        FRZFlag = transform.GetComponent<KingCrab>().FRZFlag;

        if (HP < 15) // 페이즈2에서 쓰레기 끄기
        {
            Child[10].transform.gameObject.SetActive(false);
            Child[11].transform.gameObject.SetActive(false);
        }

        ChangeColor();
    }

    public IEnumerator Start_()
    {
        while (true) yield return StartCoroutine("ChangeImg");
    }
    public IEnumerator ChangeImg()//움직임애니매이션재생
    {
        for (int i = 0; i < 10; )
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

            if (!FRZFlag) i++;

            yield return new WaitForSeconds(0.1f);
        }
    }

    void ChangeColor()
    {
        for (int i = 0; i < 13; i++)
        {
            if (FRZFlag)
                Skin[i].color = Color.blue;
            else 
                Skin[i].color = Color.white;
        }
    }
    
    public void OnOutline()
    {
        UpdateOutline(true);
        Invoke("OffOutline", 0.07f);
    }

    void UpdateOutline(bool outline)
    {
        for (int i = 0; i < 13; ++i)
        {
            MaterialPropertyBlock mpb1 = new MaterialPropertyBlock();
            Skin[i].GetPropertyBlock(mpb1);
            mpb1.SetFloat("_Outline", outline ? 1f : 0);
            mpb1.SetColor("_OutlineColor", Color.white);
            mpb1.SetFloat("_OutlineSize", 14);
            Skin[i].SetPropertyBlock(mpb1);
        }
    }
    void OffOutline()
    {
        UpdateOutline(false);
    }
}
