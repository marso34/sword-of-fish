using UnityEngine;

public class AttackerScript : Player
{
    bool SkillFlag_;
    public GameObject KillEffect;
    public GameObject KillEffect2;
    public GameObject KillEffectO;
    public GameObject bullet;
    public GameObject KS_;
    public GameObject DamageText;

    public float timer;
    public float waitingTime;

    public int SkillCount;
    public bool flag;
    public Vector3 bulletRange;
    public GameObject PlayerP;
    GameObject P;


    float Watingtime3 = 0.02f;
    float time;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SkillFlag_ = true;
        Debug.Log("³ª´Â ÀÚ¿¬ÀÎÀÌ´Ù.");
        GM = GameObject.FindGameObjectWithTag("GM");
        QM = GameObject.FindGameObjectWithTag("QM");

        S = Skin.transform.GetComponent<SpriteRenderer>();
        skin_ = Skin.transform.GetComponent<Skin>();

        MFish = Skin.transform.GetComponent<SpriteRenderer>();
        MKnife = MyKnife.transform.GetComponent<SpriteRenderer>();
        RB = transform.GetComponent<Rigidbody2D>();
        time = 0;

        if (transform.name == "Boss") FishNumber = 2;
        else FishNumber = 6;
        KnifeNumber = 0;

        P = GameObject.FindGameObjectWithTag("Player");
        timer = 0;
        waitingTime = 2f;
        bulletRange = new Vector3(9f, 3f, 0);

        RotationSpeed = 720f;
        TempMovementSp = 2.3f; //J
        TempBusterSp = 4.6f;     // J
        TempRotateSp = RotationSpeed;   // J
        InitState();
        flag = true;
        SkillCount = 0;


        HP = 4;
        Life = true;
        FRZFlag = false;
        state = State.Move;
        StartCoroutine("Start_");
        Speed = MovementSpeed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Life)
        {
            if ((other.transform.tag == "Knife" && other.transform.parent.tag == "Player") || other.transform.tag == "SkillO")
            {
                HitAttacker(other.gameObject, other.contacts[0].point);
            }

        }
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EXPL")
            HitEXPL(other.gameObject);
        if (other.gameObject.tag == "FRZ")
        {
            FRZOn();
            Invoke("FRZOff", 2.5f);
        }

        // Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "SkillB")
        {
            Debug.Log("º¸°Å ½ºÅ³¿¡ ´êÀ½");
            SlowMoveSpeed(1f);
            //SlowRotateSpeed(1f);
        }
    }


    void SlowON()
    {
        if (Life)
        {
            Speed = 1.6f;
            RotationSpeed = 50f;
            C = Color.green;
            S.color = C;
            waitingTime = 4f;
        }
    }
    void SlowOff()
    {
        if (Life)
        {
            InitState();
            waitingTime = 2f;
            Speed = MovementSpeed;
        }
    }


    void statusColor()
    {
        if (Life)
        {
            if (FRZFlag == true)
            {
                C = new Color(60f / 255f, 150f / 255f, 255f / 255f);
                S.color = C;
                timer = 0;
            }
            else if (FRZFlag == false)
            {
                if ((transform.name == "BockBoss" && SkillCount < 2) || transform.name == "Attacker")
                {
                    InitState();
                    // C = Color.white;
                    S.color = C;
                }
            }
        }
    }
    public void EmptyKnife()
    {
        MyKnife.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        MyKnife.tag = "NotKnife";
        MyKnife.transform.parent = null;
        MyKnife.transform.localScale = Vector3.zero;

    }
    public void Init()
    {
        if (transform.name == "Boss" && flag)
        {
            if (QM.GetComponent<QuestManager>().Level_ == 2 && QM.GetComponent<QuestManager>().IngameLevel == 1)
                HP = 50;
            else HP = 12;
            transform.localScale = new Vector3(6f, 6f, 6f);
            flag = false;
        }
        else if (flag)
        {
            HP = (int)(transform.localScale.y * 3);
            flag = false;
        }
    }
    public void lookrota()
    {
        float x_ = transform.localScale.x;//  ï¿½ï¿½.
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
    public void MoveAtt()
    {
        dir = PlayerP.transform.position - transform.position;
        if (Mathf.Abs((PlayerP.transform.position - transform.position).magnitude) >= Mathf.Abs(bulletRange.magnitude))
            RB.velocity = dir / 3;
        else RB.velocity = Vector3.zero;
        Debug.Log(Mathf.Abs((PlayerP.transform.position - transform.position).magnitude) + " " + Mathf.Abs(bulletRange.magnitude));

    }
    void Update()
    {
        EmptyKnife();
        Init();
        lookrota();
        PlayerP = GameObject.FindGameObjectWithTag("Player");
        statusColor();

        if (PlayerP != null && !FRZFlag && Life)
        {
            MoveAtt();
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                SkillCount++;
                GameObject bullet_;
                bullet_ = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 0f));

                bullet_.GetComponent<bullet>().SetDir(dir);
                Debug.Log("°è¼Ó");
                if (SkillCount > 2 && SkillFlag_)
                {
                    SkillFlag_ = false;
                    if (transform.name == "Boss")
                    {
                        C = Color.red;
                        S.color = C;
                        Invoke("UseSkill", 2f);
                    }
                }
                timer = 0f;
                waitingTime = Random.Range(3, 6);
            }

            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir.normalized);//ÀÌµ¿¹æÇâ¿¡ ¸Â°Ô Á¤¸éÀ» º¸µµ·Ï È¸Àü°ª ¹Þ¾Æ¿À±â.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);///ÇÃ·¹ÀÌ¾î¿ÀºêÁ§Æ®¿¡°Ô ¹Þ¾Æ¿Â È¸Àü°ª Àû¿ë
        }
        if (Life) DieCheck();
        //nï¿½Ê¸ï¿½ï¿½ï¿½ ï¿½Ã·ï¿½ï¿½Ì¾ï¿½ ï¿½Ù¶óº¸±ï¿½.
        //Nï¿½Ê¸ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ñ¾ï¿½ ï¿½ß»ï¿½
        if (!Life)
        {
            time += Time.deltaTime;
            if (time > Watingtime3)
            {
                C.a -= 0.02f;
                Skin.GetComponent<SpriteRenderer>().color = C;
                time = 0;
            }
        }
        isMove = true;
        AnimState(dir);
        //if (HP <= 0 && Life) dieAttacker();
    }
    void DieCheck()
    {
        if (HP <= 0)
        {

            MyKnife.transform.parent = null;
            MyKnife.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            MyKnife.transform.parent = transform;
            gameObject.layer = 4;
            Life = false;
            state = State.Die;
            ShowDieAnim(0);
            FRZOff();
            if (gameObject.name == "Attacker")
            {
                P.transform.GetComponent<PlayerScript>().KillScoreUp();
                QM.GetComponent<QuestManager>().BulletEC--;
            }
            transform.tag = "NotBody";
            CreateFlesh();
            Stage22_ex();
            MyKnife.tag = "NotKnife";
        }
    }
    void UseSkill()
    {
        string N = "Bullet";
        C = Color.white;
        PlaySkill(N);
        SkillCount = 0;
        SkillFlag_ = true;
    }
    public void HitEXPL(GameObject other)
    {

        if (other.transform.tag == "EXPL")
        {
            var DT = Instantiate(DamageText, transform.position, Quaternion.Euler(0f, 0f, 0f));
            DT.GetComponent<DamageTxt>().dtxt.text = 5.ToString();
            HP -= 5;
            if (transform.name == "Boss")
                DT.transform.localScale *= 2f;
        }
    }
    public void HitAttacker(GameObject other, Vector3 V)
    {
        Debug.Log("³ªakw");
        OnOutLine(14);
        Invoke("OffOutLine", 0.07f);

        //ShowDieAnim(0);


        if (HP > 0 && Life)
        {
            float QR = Random.Range(1, 7);
            float R = Random.Range(0.8f, 1.7f);
            if (other.transform.tag == "Knife")
            {
                var DT = Instantiate(DamageText, transform.position, Quaternion.Euler(0f, 0f, 0f));
                DT.GetComponent<DamageTxt>().dtxt.text = 1.ToString();
                if (transform.name == "Boss")
                    DT.transform.localScale *= 2f;

                if (other.name != "body")
                    other.transform.GetComponent<HitFeel>().TimeStop(1f);

                var KE = Instantiate(KillEffect, V, Quaternion.Euler(0f, 0f, 20f * QR));
                float x_ = transform.localScale.x;
                if (x_ > 0)
                    x_ *= -1;

                KE.transform.localScale = new Vector3(x_, transform.localScale.y, transform.localScale.z);
                // KE.transform.localScale = transform.parent.localScale; * R / 1.5f;
                --HP;
            }
            else if (other.transform.tag == "SkillO")
            {
                var KE1 = Instantiate(KillEffectO, V, Quaternion.Euler(0f, 0f, 20f * QR));
                KE1.transform.localScale = transform.localScale / 3f;
                --HP;
            }

            var KS = Instantiate(KS_, transform.position, Quaternion.Euler(0f, 0f, 20f * QR));
        }
    }
    public void dieAttacker()
    {
        Debug.Log("die att " + HP + Life);
    }
    public void Win()
    {

        P.transform.GetComponent<PlayerScript>().BosskillScore++;
        //QM.transform.GetComponent<QuestManager>().BossMaxCount--;
    }
}
