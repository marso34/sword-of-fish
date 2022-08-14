using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraken : Boss
{
   
    public GameObject SkillTentacle; // 다리 스킬
    public GameObject SkillInk;      // 먹물 발사
    public GameObject SkillInkSwarm; // 먹구름 생성
    bool test = true;
    Vector3 Far;
    Vector3 CMPD;
    public int LegCount;
    public float waitTime;
    public GameObject InkOct;
    public GameObject Bubble;
    void Start()
    {
        HitFlag = false;
        LegCount = 4;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GM = GameObject.FindGameObjectWithTag("GM");
        Circle = GetComponent<CircleCollider2D>();
        Skin = GetComponent<SpriteRenderer>();
        Skin.sprite = Image[0];
        HP = 12;
        Speed = 3.8f;
        RotationSpeed = 800f;
        waitTime = 4f;
        FRZFlag = false;
        S = transform.GetComponent<SpriteRenderer>();
        // c = transform.GetComponent<SpriteRenderer>().color;
        StartCoroutine("Start_");
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // 일단 임시로
        timer += Time.deltaTime; // 이미지 바꾸는 시간 위한 타이머
        timer_ += Time.deltaTime; // 일단 스킬용으로 대충 만든 거
        statusColor();
        if (HP > 0 && !FRZFlag)
        {
            if (LegCount > 0)
            {
                if (timer_ >= 4f && test)
                {
                    // CreateTentacle();
                    test = false;
                }

                if (timer_ >= Random.Range(3f, 7f))
                {
                    timer_ = 0f;
                    CMPD = AbsVector(Sub(AbsVector(Player.transform.position), AbsVector(transform.position)));
                    if (LegCount > 0 && (Mathf.Abs(CMPD.x) < 8f && Mathf.Abs(CMPD.y) < 6f))
                        CreateTentacle();
                    else
                    {
                        CreateInkBomb();
                        CreateInkSwarm();
                    }
                }
            }
            else
            {
                if (timer_ >= waitTime)
                {
                    dir = SetDir();
                    for (int i = 0; i < Random.Range(3, 6); ++i)
                        CreateInkOct();
                    timer_ = 0;
                }
                MoveKraken(dir);
                // CreateBubbles();
                BubbleP.gameObject.GetComponent<BubleParticle>().Speed = Speed;
            }
            //ChangeCollider();


        }
    }

    public Vector3 Sub(Vector3 V1, Vector3 V2)
    {
        return V1 - V2;
    }
    public Vector3 SetDir()
    {
        Vector3 P = new Vector3(Random.Range(-2.0f, 2.1f), Random.Range(-1.0f, 1.1f));
        return P - transform.position;
    }
    public void CreateInkOct() // 먹물 분신 생성
    {
        var IO = Instantiate(InkOct, transform.position, Quaternion.Euler(Random.Range(-180f,180f), 0, 0));
        IO.transform.parent = transform;
        IO.transform.localPosition = new Vector3(Random.Range(-0.9f,0.1f),0f,0f);
        IO.transform.parent = null;
        IO.transform.localScale = new Vector3(1,1,1);
        IO.GetComponent<Player>().FishNumber =7;
        IO.GetComponent<Player>().StartFlag = true;
    }
    public void MoveKraken(Vector3 dir_)
    {

        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);// 오브젝트 이동함수 https://www.youtube.com/watch?v=2pf1FE-Xcc8 에나온 코드를 살짝 변형한것.   
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);//이동방향에 맞게 정면을 보도록 회전값 받아오기.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);//플레이어오브젝트에게 받아온 회전값 적용
        float x_ = transform.localScale.x;// x_에 플레이어오브젝트 scale.x 를 넣음. scale.x가 음수일시 플레이어는 좌우반전으로 회전한다. 이를이용해서 왼쪽으로 많이 돌아도 뒤집어진 모양이 안나오게 함.                
        if (x_ < 0)
            x_ *= -1;
        if (transform.rotation.normalized.w * transform.rotation.normalized.z < 0)
        {
            transform.localScale = new Vector3(x_, transform.localScale.y, 1);
        }
        else if (transform.rotation.normalized.w * transform.rotation.normalized.z > 0)
        {
            transform.localScale = new Vector3(x_ * -1, transform.localScale.y, 1);
        }
    }
    public Vector3 AbsVector(Vector3 V)
    {
        return new Vector3(Mathf.Abs(V.x), Mathf.Abs(V.y), Mathf.Abs(V.z));
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (LegCount == 0)
        {
            if ((other.transform.tag == "Knife" && other.transform.parent.tag == "Player") || other.transform.tag == "EXPL")
            {
                Damaged(other.gameObject);
            }
        }
        if (other.gameObject.tag == "FRZ")
        {
            FRZOn();
            Invoke("FRZOff", 2.5f);
        }
    }
    void CreateTentacle() // 촉수 스킬 생성
    {

        Vector3 PlayerP = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (Random.Range(0, 10) == 1) CreateInkSwarm();
        var a = Instantiate(SkillTentacle, Point.transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);

        a.transform.Translate(new Vector3(PlayerP.x, -transform.localScale.y - 1f, 1f), Space.World); // 텐타클 보스 주변 랜덤으로 생성
        // a.transform.parent = null;

        a.GetComponent<Tentacle>().Active = true;
    }
    void CreateInkBomb() // 잉크 폭탄 생성
    {
        var a = Instantiate(SkillInk, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f); // 먹물발사 0.3, 촉수 0.6
    }
    void CreateInkSwarm() // 화면 갈리는 잉크스웜 생성
    {

        var a = Instantiate(SkillInkSwarm, Player.transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.localScale = new Vector3(2f, 2f, 1f);
        Destroy(a, 3f);
    }
    public void CreateInkSwarm(Vector3 V, float size)
    {
        var a = Instantiate(SkillInkSwarm, V, Quaternion.Euler(0, 0, 0));
        a.transform.localScale = new Vector3(size, size, size);
        Destroy(a, 3f);
    }

    float RandomPositionX()
    {
        int x = Random.Range(-8, 8);

        if (x < 0)
            x -= 7;
        else
            x += 7;

        return (float)x;
    }
}
