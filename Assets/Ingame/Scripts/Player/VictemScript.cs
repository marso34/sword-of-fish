using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictemScript : Player
{
    // Start is called before the first frame update
    bool Prizen = true;
    public GameObject KS_;
    
    public GameObject KillEffect;
    int maxAttacker = 2;
    private void Start()
    {
        // RB = transform.GetComponent<Rigidbody2D>();
        QM = GameObject.FindGameObjectWithTag("QM");
        Life = true;// 라이프 온
        skin_ = Skin.GetComponent<Skin>();// 스킨오브젝트 참조
        S = Skin.transform.GetComponent<SpriteRenderer>();
        HP = 10;
        FishNumber = 8;
        KnifeNumber = 1;
        GameWaitInit();
        MovementSpeed =4f;//3.8
        BusterSpeed = 10f;// 부스터 속도 //10      
        Speed = MovementSpeed;// 스피드 변수를 기본스피드로 다시 초기화  
        StartCoroutine("Start_");
    }
    // Update is called once per frame
    void Update()
    {
        isMove = true;
        Speed = MovementSpeed;
        AnimState(Vector3.forward);
        transform.position = MyBody.transform.position;

        EmptyKnife();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Life)
        {
            if ((other.transform.tag == "Knife" && other.transform.parent.tag != "Player") || other.transform.name == "Bullet")
            {
                HitVictem();
            }

        }
    }
    public void EmptyKnife()
    {
        MyKnife.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        MyKnife.tag = "NotKnife";
        MyKnife.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

    }
    public void HitVictem()
    {
        Debug.Log("나akw");
        OnOutLine(14);
        Invoke("OffOutLine", 0.07f);


        if (HP > 0 && Life)
        {
            float QR = Random.Range(1, 7);
            float R = Random.Range(0.8f, 1.7f);

            var KE = Instantiate(KillEffect, transform.position, Quaternion.Euler(0f, 0f, 20f * QR));

            float x_ = transform.localScale.x;
            if (x_ > 0)
                x_ *= -1;

            KE.transform.localScale = new Vector3(x_, transform.localScale.y, transform.localScale.z);
            // KE.transform.localScale = transform.parent.localScale; * R / 1.5f;
            --HP;
            var KS = Instantiate(KS_, transform.position, Quaternion.Euler(0f, 0f, 20f * QR));
            
        }
        if (HP <= 0 && Life)
        {
            Life = false;
            state = State.Die;


            transform.tag = "NotBody";
//            CreateFlesh();
            QM.GetComponent<QuestManager>().LoseFlag = true;
            Destroy(transform.gameObject, 1.5f);
        }


    }
}
