using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject KillEffect;
    public GameObject KillEffect2;
    public GameObject KS_;
    public GameObject DamageText;

    public PolygonCollider2D[] Polygon;
    public PolygonCollider2D temp;
    public Sprite[] Image;
    SpriteRenderer Skin;

    bool StartFlag;
    public bool Active = false;
    float imgTime; // 이미지 바꾸는 타이머
    float timer_ = 0f; // 스킬일 경우 생존 시간 타이머

    float Speed = 5f;
    float dir = 1f;
    public int HP;
    bool FRZFlag;
    Color c;
    SpriteRenderer S;
    public bool InLife;
    void Start()
    {
        InLife = true;
        Skin = GetComponent<SpriteRenderer>();
        S = transform.GetComponent<SpriteRenderer>();
        StartFlag = true;
        imgTime = 0.125f;
        HP = 5;
        timer_ = 0f;
        temp = Polygon[0];
        FRZFlag = false;
        StartCoroutine("Start_");
    }

    // Update is called once per frame
    void Update()
    {
        if (InLife)
        {
            statusColor();
            if (!FRZFlag && !transform.parent.GetComponent<Kraken>().FRZFlag)
            {

                timer_ += Time.deltaTime; // 생존 시간 타이머
                statusColor();

                if (Active) // 스킬일 경우 움직임
                {
                    imgTime = 0.1f;
                    if (timer_ >= 3.6f)
                        Destroy(gameObject);
                    MoveTentacle();
                    transform.GetChild(0).tag = "BossSkillA";
                }
            }
            InDieCheck();
        }
    }
    public void InDieCheck()
    {
        if (HP <= 0 && InLife)
        {
            InLife = false;
            transform.parent.GetComponent<Kraken>().LegCount--;
            Destroy(gameObject);
        }
    }

    public void HitFRZ()
    {
        FRZOn();
        Invoke("FRZOff", 2.5f);
    }
    void FRZOn()
    {
        FRZFlag = true;
    }
    void FRZOff()
    {
        FRZFlag = false;
    }
    void statusColor()
    {
        if (FRZFlag == true || transform.parent.GetComponent<Kraken>().FRZFlag)
        {
            c = new Color(60f / 255f, 150f / 255f, 255f / 255f);
            S.color = c;



        }
        else if (FRZFlag == false && !transform.parent.GetComponent<Kraken>().FRZFlag)
        {
            c = Color.white;
            S.color = c;


        }
    }

    IEnumerator Start_()
    {
        while (true) yield return StartCoroutine("ChangeImg");
    }
    IEnumerator ChangeImg()//움직임애니매이션재생
    {
        int i = 0;

        if (StartFlag) // 처음 이미지 랜덤으로 시작
        {
            i = Random.Range(0, 9);
            StartFlag = false;
        }

        for (; i < 10; ++i)
        {
            temp.enabled = false;
            Skin.sprite = Image[i];

            if (i < 5)
            {
                Polygon[i].enabled = true;
                temp = Polygon[i];
            }
            else
            {
                Polygon[9 - i].enabled = true;
                temp = Polygon[9 - i];
            }

            yield return new WaitForSeconds(imgTime);
        }
    }

    void MoveTentacle()
    {
        if (timer_ >= 1.65f) // 생존시간
            dir = -1f;

        transform.Translate(new Vector3(0f, dir, 0f) * Speed * Time.deltaTime, Space.World);
    }
    public void HitEXPL_(GameObject other2)
    {

        if (other2.gameObject.tag == "EXPL")
        {
            FloatingDamageTxt(5);
            HP -= 5;

            float R = Random.Range(0.5f, 1.0f);

        }
    }
    public void DestroyTentacle(GameObject other2)
    {
        if (HP > 0)
        {
            Debug.Log("HP ????");
            UpdateOutline(true);
            Invoke("OffOutline", 0.07f);

            float QR = Random.Range(1, 7);
            var KS = Instantiate(KS_, transform.position, Quaternion.Euler(0f, 0f, 20f));

            FloatingDamageTxt(1);
            HP--;

            float R = Random.Range(3.5f, 6f);
            var KE = Instantiate(KillEffect, transform.position, Quaternion.Euler(0f, 0f, 20f * QR));

            float x_ = transform.localScale.x;
            if (x_ < 0)
                x_ *= -1;

            KE.transform.localScale = new Vector3(x_, transform.localScale.y, transform.localScale.z);

        }
    }

    IEnumerator ShowHitFlash()
    {
        // change the current shader 
        // GetComponent<SkinnedMeshRenderer>().material = 
        GetComponent<MeshRenderer>().material.shader = Shader.Find("Effect/FlashWhite");
        // Skin.material.shader = Shader.Find("FlashWhite");
        // show a white flash for a little moment
        yield return new WaitForSeconds(0.15f);

        //put again the shader it had before 
        GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
    }

    void UpdateOutline(bool outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        Skin.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", Color.white);
        mpb.SetFloat("_OutlineSize", 50);
        Skin.SetPropertyBlock(mpb);
    }

    void OffOutline()
    {
        UpdateOutline(false);
    }

    void FloatingDamageTxt(int Damage)
    {
        var DT = Instantiate(DamageText, transform.position, Quaternion.Euler(0f, 0f, 0f));
        DT.GetComponent<DamageTxt>().dtxt.text = Damage.ToString();
        DT.transform.localScale *= 2f;
    }

}
