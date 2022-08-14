using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public GameObject GM;
    public GameObject DamageText; // 데미지 표시
    public Sprite[] Image;
    public GameObject DieImg;
    public GameObject Point;
    public ParticleSystem BubbleP;
    public GameObject Player;
    public CircleCollider2D Circle;
    public SpriteRenderer Skin;
    public int HP;
    public float Speed;
    public float RotationSpeed;
    public GameObject KillEffect;
    public GameObject KillEffect2;
    public Sprite HitSkin;
    public GameObject KS_;
    public bool FRZFlag;
    public Color c;
    public SpriteRenderer S;
    public bool HitFlag;

    public Vector3 dir;
    public float timer = 0f;
    public float timer_ = 0f;

    public IEnumerator Start_()
    {
        while (true) yield return StartCoroutine("ChangeImg");
    }
    public IEnumerator ChangeImg()//움직임애니매이션재생
    {
        for (int i = 0; i < 10; ++i)
        {
            Skin.sprite = Image[i];
            yield return new WaitForSeconds(0.125f);
        }
    }
    public void ChangeCollider() // 움직임에 따라 콜라이더 수정, 지금 사용x 나중에 사용하게 되면 코루틴으로 변경
    {
        float position = 0.1f;

        if (Skin.sprite == Image[0])
            Circle.offset = new Vector2(-0.34f, 0.15f + position);
        else if (Skin.sprite == Image[1])
            Circle.offset = new Vector2(-0.34f, 0.1f + position);
        else if (Skin.sprite == Image[2])
            Circle.offset = new Vector2(-0.34f, 0.05f + position);
        else if (Skin.sprite == Image[3])
            Circle.offset = new Vector2(-0.34f, 0f + position);
        else if (Skin.sprite == Image[4])
            Circle.offset = new Vector2(-0.34f, 0.2f + position);
        else if (Skin.sprite == Image[5])
            Circle.offset = new Vector2(-0.34f, 0.15f + position);
        else if (Skin.sprite == Image[6])
            Circle.offset = new Vector2(-0.34f, 0.1f + position);
        else if (Skin.sprite == Image[7])
            Circle.offset = new Vector2(-0.34f, 0f + position);
        else if (Skin.sprite == Image[8])
            Circle.offset = new Vector2(-0.34f, 0.04f + position);
        else if (Skin.sprite == Image[9])
            Circle.offset = new Vector2(-0.34f, 0.1f + position);
    }
    public void Damaged(GameObject other2)
    {
        float QR = Random.Range(1, 7);
        float R = Random.Range(2f, 5f);
        if (HP > 0)
        {
            UpdateOutline(true);
            Invoke("OffOutline", 0.07f);



            if (other2.gameObject.tag == "EXPL")
            {
                var DT = Instantiate(DamageText, transform.position, Quaternion.Euler(0f, 0f, 0f));
                DT.GetComponent<DamageTxt>().dtxt.text = 5.ToString();
                DT.transform.localScale *= 2f;
                HP -= 5;
            }
            else
            {
                var DT = Instantiate(DamageText, transform.position, Quaternion.Euler(0f, 0f, 0f));
                DT.GetComponent<DamageTxt>().dtxt.text = 1.ToString();
                DT.transform.localScale *= 2f;
                HP--;
                var KE = Instantiate(KillEffect, Point.transform.position, Quaternion.Euler(0f, 0f, 20f * QR));
                float x_ = transform.localScale.x;
                if (x_ > 0)
                    x_ *= -1;

                KE.transform.localScale = new Vector3(x_, transform.localScale.y, transform.localScale.z);
            }

            Debug.Log("ssss0");

            var KS = Instantiate(KS_, Point.transform.position, Quaternion.Euler(0f, 0f, 20f * QR));
        }

        if (HP <= 0)
        {

            HitOn();//DieImg에 보스터질때 구현
            transform.Find("Bubble Particle").gameObject.SetActive(false);
            gameObject.SetActive(false);
            Invoke("win", 1.5f);
        }
    }
    void HitOn()
    {
        DieImg.SetActive(true);//DieImg에 보스터질때 구현
    }
    void HitOff()
    {
        DieImg.SetActive(false);//DieImg에 보스터질때 구현

    }

    void win()
    {
        Player.GetComponent<PlayerScript>().BosskillScore++;
        Destroy(gameObject); // 무언가 보스 터지는 이미지 넣어다라고 1.2초 준거
    }
    void UpdateOutline(bool outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        DieImg.GetComponent<SpriteRenderer>().GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", Color.white);
        mpb.SetFloat("_OutlineSize", 14);
        DieImg.GetComponent<SpriteRenderer>().SetPropertyBlock(mpb);

        MaterialPropertyBlock mpb1 = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(mpb1);
        mpb1.SetFloat("_Outline", outline ? 1f : 0);
        mpb1.SetColor("_OutlineColor", Color.white);
        mpb1.SetFloat("_OutlineSize", 14);
        spriteRenderer.SetPropertyBlock(mpb1);
    }
    void OffOutline()
    {
        UpdateOutline(false);
    }
    public void FRZOn()
    {
        FRZFlag = true;
    }
    public void FRZOff()
    {
        FRZFlag = false;
    }
    public void statusColor()
    {
        if (FRZFlag == true)
        {
            c = new Color(60f / 255f, 150f / 255f, 255f / 255f);
            S.color = c;

        }
        else if (FRZFlag == false)
        {
            c = Color.white;
            S.color = c;

        }
    }
}
