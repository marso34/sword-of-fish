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

    int HP; // KingCrab에서 
    bool FRZFlag;
    bool Life; // 가져오는 변수(동기화)

    float timer;
    int index;

    void Start()
    {
        timer = 0f;
        index = 6;

        for (int i = 0; i < 13; i++)
            Skin[i] = Child[i].GetComponent<SpriteRenderer>();

        StartCoroutine("Start_");
    }

    void Update()
    {
        HP = transform.GetComponent<KingCrab>().HP;
        FRZFlag = transform.GetComponent<KingCrab>().FRZFlag;
        Life = transform.GetComponent<KingCrab>().Life;

        if (HP < 15) // 페이즈2에서 쓰레기 끄기
        {
            Child[10].transform.gameObject.SetActive(false);
            Child[11].transform.gameObject.SetActive(false);
        }

        ChangeColor();
        DieImg();
    }

    public IEnumerator Start_()
    {
        while (true) yield return StartCoroutine("ChangeImg");
    }
    public IEnumerator ChangeImg()//움직임애니매이션재생
    {
        for (int i = 0; i < 10;)
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

            if (!FRZFlag && HP > 0 && Life) i++;

            if (HP <= 0)
                i = 3;

            yield return new WaitForSeconds(0.1f);
        }
    }

    void ChangeColor()
    {
        for (int i = 0; i < 13; i++)
        {
            if (FRZFlag)
                Skin[i].color = new Color(60f / 255f, 150f / 255f, 255f / 255f);
            else
                Skin[i].color = Color.white;
        }
    }

    void DieImg()
    {
        if (HP <= 0 && index > 3)
        {
            StopAllCoroutines();
            timer += Time.deltaTime;

            if (timer >= 0.1f)
            {
                Debug.Log(index + "  테스트 ");
                index--;
                Skin[1].sprite = Eye[index];
                timer = 0f;
            }
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