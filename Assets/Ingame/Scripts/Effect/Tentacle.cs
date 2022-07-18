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

    public bool Active = false;
    float imgTimer;
    float timer_ = 0f;

    float imgWaitTime = 1.25f; // 
    float imgWaitTime2 = 8f;


    float Speed = 5f;
    float dir = 1f;
    public int HP;
    bool FRZFlag;
    Color c;
    SpriteRenderer S;

    void Start()
    {

        HP = 15;
        Skin = GetComponent<SpriteRenderer>();
        imgTimer = Random.Range(0f, imgWaitTime);
        timer_ = 0f;
        Skin.sprite = Image[(int)(imgTimer * imgWaitTime2)];
        temp = Polygon[0];
        S = transform.GetComponent<SpriteRenderer>();
        FRZFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        statusColor();
        if (!FRZFlag && !transform.parent.GetComponent<Kraken>().FRZFlag)
        {
            imgTimer += Time.deltaTime; // 이미지 바꾸는 시간 위한 타이머
            timer_ += Time.deltaTime; // 생존 시간 타이머
            statusColor();

            if (Active) // 스킬일 경우 움직임
            {
                imgWaitTime = 1f;
                imgWaitTime2 = 10f;
                if (timer_ >= 3.6f)
                    Destroy(gameObject);
                MoveTentacle();
                transform.GetChild(0).tag = "BossSkillA";
            }
            else
            {

            }
            if (imgTimer >= imgWaitTime)  // 여기부터
                imgTimer = 0;
            Skin.sprite = Image[(int)(imgTimer * 8)];
            ChangeCollider();    // 여기까지 이미지 그리기 및 이미지에 맞는 콜라이더
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="FRZ") {
            FRZOn();
            Invoke("FRZOff",2.5f);
        }
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
    void ChangeCollider()
    {
        temp.enabled = false;
        if (Skin.sprite == Image[0] || Skin.sprite == Image[9])
        {
            Polygon[0].enabled = true;
            temp = Polygon[0];
        }
        else if (Skin.sprite == Image[1] || Skin.sprite == Image[8])
        {
            Polygon[1].enabled = true;
            temp = Polygon[1];
        }
        else if (Skin.sprite == Image[2] || Skin.sprite == Image[7])
        {
            Polygon[2].enabled = true;
            temp = Polygon[2];
        }
        else if (Skin.sprite == Image[3] || Skin.sprite == Image[6])
        {
            Polygon[3].enabled = true;
            temp = Polygon[3];
        }
        else
        {
            Polygon[4].enabled = true;
            temp = Polygon[4];
        }
    }

    void MoveTentacle()
    {
        if (timer_ >= 1.65f) // 생존시간
            dir = -1f;

        transform.Translate(new Vector3(0f, dir, 0f) * Speed * Time.deltaTime, Space.World);
    }

    public void DestroyTentacle(GameObject other2)
    {
        if (HP > 0)
        {
            Debug.Log("HP ????");
            UpdateOutline(true);
            Invoke("OffOutline", 0.07f);

            if (other2.gameObject.tag == "EXPL")
            {
                var DT = Instantiate(DamageText, transform.position, Quaternion.Euler(0f, 0f, 0f));
                DT.GetComponent<DamageTxt>().dtxt.text = 5.ToString();
                DT.transform.localScale *= 2f;
                HP -= 5;
                float QR = Random.Range(1, 7);

                var KE1 = Instantiate(KillEffect2, transform.parent.position, Quaternion.Euler(0f, 0f, 20f * QR));
                float R = Random.Range(0.5f, 1.0f);

                KE1.transform.localScale = transform.localScale * R;

                var KS = Instantiate(KS_, transform.position, Quaternion.Euler(0f, 0f, 20f));
            }
            else
            {
                var DT = Instantiate(DamageText, transform.position, Quaternion.Euler(0f, 0f, 0f));
                DT.GetComponent<DamageTxt>().dtxt.text = 1.ToString();
                DT.transform.localScale *= 2f;
                HP--;
                float QR = Random.Range(1, 7);
                var KE = Instantiate(KillEffect, transform.position, Quaternion.Euler(0f, 0f, 20f * QR));
                var KE1 = Instantiate(KillEffect2, transform.position, Quaternion.Euler(0f, 0f, 20f * QR));
                float R = Random.Range(3.5f, 6f);
                KE.transform.localScale = transform.localScale * R;
                KE1.transform.localScale = transform.localScale * 2;
                var KS = Instantiate(KS_, transform.position, Quaternion.Euler(0f, 0f, 20f));
            }
        }

        if (HP <= 0)
        {
            transform.parent.GetComponent<Kraken>().LegCount--;
            Destroy(gameObject);
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
}
