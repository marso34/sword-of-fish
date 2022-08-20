using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    public GameObject Bubble;
    public GameObject Tornado;
    public GameObject SkillSkin; // 스킨 담긴 오브젝트
    public SkillSkin SkillSkin_; //스킨
    public Vector3 dir; //움직일방향

    Rigidbody2D RB;

    public bool DelFalg;
    double Timer; // 스킬 생존 시간
    double RotateTimer; // 타코야 스킬 버블 생성 시간
    float Speed;
    int FishNumber;
    public GameObject GM;

    public GameObject BboomEffect;
    public GameObject StabSound;
    public ParticleSystem DelEffect;

    bool FRZFlag;
    Color c;
    SpriteRenderer S;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        SkillSkin_ = SkillSkin.GetComponent<SkillSkin>();
        S = transform.GetComponent<SpriteRenderer>();
        RB = transform.GetComponent<Rigidbody2D>();
        FishNumber = transform.parent.gameObject.GetComponent<Player>().FishNumber;
        DelFalg = false;
        FRZFlag = false;
        Timer = 0;
        RotateTimer = 0;
        Init();
    }

    void Update()
    {
        statusColor();
        if (!FRZFlag)
        {
            Timer += Time.deltaTime;
            // transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);// 오브젝트 이동함수 https://www.youtube.com/watch?v=2pf1FE-Xcc8 에나온 코드를 살짝 변형한것.
            RB.velocity = dir.normalized * Speed * Time.deltaTime * 60;

            if (FishNumber == 3) // 타코야 스킬
            {
                transform.Rotate(Vector3.forward * 40 * Time.deltaTime); // 타코야 스킬 회전 시키기
            }
            else if (FishNumber == 9)
            {
                if (transform.localScale.x < 0)
                    transform.Rotate(Vector3.forward * 120 * Time.deltaTime); // 퍼플피쉬 스킬 회전 시키기
                else
                    transform.Rotate(Vector3.back * 120 * Time.deltaTime); // 퍼플피쉬 스킬 회전 시키기
            }
        }
        else
        {
            RB.velocity = dir.normalized * 0.001f * Time.deltaTime * 60f;
        }
        if (Timer > 5f)
            DelFalg = true;

        if (DelFalg)
            DelSkill();
        if (GM.GetComponent<GameManager_>().EndFlag == true) Destroy(gameObject);
    }


    public void Init()
    {
        DirInit();
        ImgInit();
    }
    public void ImgInit()
    {
        if (FishNumber == 2) // 보거
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = SkillSkin_.BlowfishSkill;
            transform.tag = "SkillB";
        }
        else if (FishNumber == 3) // 아기상어
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = SkillSkin_.OctopusSkill;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = SkillSkin_.OctopusSkillAnims;
            transform.tag = "SkillO";
        }
        else if (FishNumber == 9) // 퍼플피쉬
        {
            transform.Find("Tornado").gameObject.SetActive(true);
            transform.tag = "SkillP";
            transform.localScale *= 0.3f;
            Speed = 5f;
        }
        // else if (FishNumber == ???) 나중에 추가될 물고기 스킬
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "FRZ")
        {
            transform.GetComponent<Skill2>().FRZOn();
            Invoke("FRZOff", 2.5f);
        }
        if (transform.name == "Bullet" && other.transform.gameObject.tag == "EXPL")
        {
            DestroyBossSkill(other.gameObject);
        }
    }
    public void DirInit()
    {
        if (FishNumber == 2) // 보거
        {
            float DirX = Random.Range(-0.9f, 0.9f);
            float DirY = Random.Range(-0.9f, 0.9f);

            dir = new Vector3(DirX, DirY, 0); // 랜덤 방향
            transform.Translate(dir.normalized * (transform.parent.localScale.y) * 0.8f, Space.World); // 이동

            // Vector3 temp = dir + transform.parent.gameObject.GetComponent<Player>().dir;
            transform.localScale *= 0.23f;
            Speed = 3.5f;
        }
        else if (FishNumber == 3 || FishNumber == 9) // 아기상어
        {
            dir = transform.parent.gameObject.GetComponent<Player>().dir; // 부모 벡터 가져오기 -> 부모가 가만히 있을 때 스킬 사용하면 스킬도 안 움직임 수정 필요 -> 이제 플레이어의 정지상태가 없기에 그대로 사용

            // float Radian = transform.parent.eulerAngles.z * Mathf.Deg2Rad - 11; // 부모의 각도 받아오기
            // float DirX = Mathf.Cos(Radian);
            // float DirY = Mathf.Sin(Radian);
            // dir = new Vector3(DirX, DirY, 0); // 부모의 각도를 토대로 벡터 생성

            transform.Translate(dir * (transform.parent.localScale.y), Space.World);
            Speed = 6f;
        }

        transform.parent = null;
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir.normalized); //이동방향에 맞게 정면을 보도록 회전값 받아오기.
        transform.localRotation = toRotation; //회전값 적용
    }
    public void DestroyBossSkill(GameObject other)//복어만 해당
    {
        var KE = Instantiate(DelEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
        KE.transform.parent = transform;
        Instantiate(StabSound, transform.position, Quaternion.Euler(0f, 0f, 0f));
        if (other.transform.tag == "Player")
            other.transform.parent.GetComponent<PlayerScript>().Handlebar(8f);
        Destroy(gameObject, 0.01f);
    }

    public void FRZOn()
    {
        FRZFlag = true;
    }
    public void FRZOff()
    {
        FRZFlag = false;
    }
    void statusColor()
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
    public void DelSkill()
    {
        Destroy(gameObject);
    }
    public void CreateBubbles()
    {
        for (int i = 0; i < 2; i++)
        {
            float randemX = 0;
            float randemY = 0;

            randemX = Random.Range(-1f, 1f);
            randemY = Random.Range(-1f, -1f);

            var V_ = new Vector3(transform.position.x, transform.position.y, 1);
            var bubble_ = Instantiate(Bubble, V_, transform.rotation);

            bubble_.transform.parent = transform;
            bubble_.transform.localPosition = new Vector3(randemX, randemY, 1);
            bubble_.transform.parent = null;

            float randemsize = Random.Range(1f, 2f);
            bubble_.transform.localScale = transform.localScale * randemsize;

            float bubbleSpeed = 0.003f;

            bubble_.GetComponent<bubble>().Speed = bubbleSpeed;
            bubble_.GetComponent<bubble>().dir = dir * -1;
        }
    }
}