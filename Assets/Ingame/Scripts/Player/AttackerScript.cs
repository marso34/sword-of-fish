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
    Vector3 bulletRange;
    public GameObject PlayerP;
    GameObject P;
    bool FRZFlag;

    float Watingtime3 = 0.02f;
    float time;

    private void Start()
    {
        SkillFlag_ = true;
        Debug.Log("³ª´Â ÀÚ¿¬ÀÎÀÌ´Ù.");
        GM = GameObject.FindGameObjectWithTag("GM");
        QM = GameObject.FindGameObjectWithTag("QM");

        S = Skin.transform.GetComponent<SpriteRenderer>();
        skin_ = Skin.transform.GetComponent<Skin>();

        MFish = Skin.transform.GetComponent<SpriteRenderer>();
        MKnife = MyKnife.transform.GetComponent<SpriteRenderer>();

        time = 0;

        if (transform.name == "Boss") FishNumber = 2;
        else FishNumber = 6;
        KnifeNumber = 0;

        P = GameObject.FindGameObjectWithTag("Player");
        timer = 0;
        waitingTime = 2f;
        bulletRange = new Vector3(10f, 4f, 0);

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

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Life)
        {
            if (other.gameObject.tag == "EXPL" || (other.transform.tag == "Knife" && other.transform.parent.tag == "Player") || other.transform.tag == "SkillO")
            {
                HitAttacker(other.gameObject);
            }
            if (other.gameObject.tag == "FRZ")
            {
                FRZOn();
                Invoke("FRZOff", 2.5f);
            }

            // Debug.Log(other.gameObject.tag);

            if (other.gameObject.tag == "SkillB")
            {
                Debug.Log("º¸°Å ½ºÅ³¿¡ ´êÀ½");
                SlowON();
                Invoke("SlowON", 2f);
            }

        }
    }
    void FRZOn()
    {
        if (Life)
        {
            FRZFlag = true;
            dir = Vector3.zero;
            Speed = 0f;
        }
    }
    void FRZOff()
    {
        if (Life)
            FRZFlag = false;
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
                if (SkillCount < 2)
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
        MyKnife.transform.localScale = Vector3.zero;

    }
    public void Init()
    {
        if (transform.name == "Boss" && flag)
        {
            HP = 25;
            transform.localScale = new Vector3(4f, 4f, 1f);
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
        if (Mathf.Abs(dir.magnitude) > Mathf.Abs(bulletRange.magnitude)) transform.Translate(dir * Speed / 2 * Time.deltaTime, Space.World);
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
                var bullet_ = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 0f));
                bullet_.GetComponent<bullet>().SetDir(dir);
                timer = 0f;
                if (SkillCount > 2 && SkillFlag_)
                {
                    SkillFlag_ = false;
                    if (transform.name == "Boss")
                    {
                        C =  Color.red;
                        S.color = C;
                        Invoke("UseSkill", 4f);
                    }
                }
               
            }
            transform.Translate(dir.normalized * 0.01f * Time.deltaTime, Space.World);
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir.normalized);//ÀÌµ¿¹æÇâ¿¡ ¸Â°Ô Á¤¸éÀ» º¸µµ·Ï È¸Àü°ª ¹Þ¾Æ¿À±â.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);///ÇÃ·¹ÀÌ¾î¿ÀºêÁ§Æ®¿¡°Ô ¹Þ¾Æ¿Â È¸Àü°ª Àû¿ë
        }
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
    void UseSkill()
    {
        string N = "Bullet";
        Skin.GetComponent<SpriteRenderer>().color = Color.white;

        PlaySkill(N);
        SkillCount = 0;
        SkillFlag_ = true;
    }

    public void HitAttacker(GameObject other)
    {
        Debug.Log("³ªakw");
        OnOutLine(14);
        Invoke("OffOutLine", 0.07f);

        ShowDieAnim(0);
        state = State.Die;

        if (HP > 0 && Life)
        {
            float QR = Random.Range(1, 7);
            float R = Random.Range(0.8f, 1.7f);

            if (other.transform.tag == "EXPL")
            {
                var DT = Instantiate(DamageText, transform.position, Quaternion.Euler(0f, 0f, 0f));
                DT.GetComponent<DamageTxt>().dtxt.text = 5.ToString();
                HP -= 5;
                if (transform.name == "Boss")
                    DT.transform.localScale *= 2f;
            }
            else if (other.transform.tag == "Knife")
            {
                var DT = Instantiate(DamageText, transform.position, Quaternion.Euler(0f, 0f, 0f));
                DT.GetComponent<DamageTxt>().dtxt.text = 1.ToString();
                if (transform.name == "Boss")
                    DT.transform.localScale *= 2f;

                if (other.name != "body")
                    other.transform.GetComponent<HitFeel>().TimeStop(other.transform.parent.localScale.y);


                var KE = Instantiate(KillEffect, transform.position, Quaternion.Euler(0f, 0f, 20f * QR));
                KE.transform.localScale = transform.localScale * R / 1.5f;

                var KE1 = Instantiate(KillEffect2, transform.position, Quaternion.Euler(0f, 0f, 20f * QR));
                KE1.transform.localScale = transform.localScale / 3f;
                --HP;
            }
            else if (other.transform.tag == "SkillO")
            {
                var KE1 = Instantiate(KillEffectO, transform.position, Quaternion.Euler(0f, 0f, 20f * QR));
                KE1.transform.localScale = transform.localScale / 3f;
                --HP;
            }

            var KS = Instantiate(KS_, transform.position, Quaternion.Euler(0f, 0f, 20f * QR));

        }
        if (HP <= 0 && Life)
        {
            Life = false;
            state = State.Die;
            if (gameObject.name == "Boss")
                Invoke("Win", 1.5f);
            else if (gameObject.name == "Attacker")
            {
                P.transform.GetComponent<PlayerScript>().KillScoreUp();
                QM.GetComponent<QuestManager>().BulletEC--;
            }
            transform.tag = "NotBody";
            CreateFlesh();
            Destroy(transform.gameObject, 1.5f);
        }


    }
    public void dieAttacker()
    {
        Debug.Log("die att " + HP + Life);
    }
    void Win()
    {

        P.transform.GetComponent<PlayerScript>().BosskillScore++;
        //QM.transform.GetComponent<QuestManager>().BossMaxCount--;
    }
}
