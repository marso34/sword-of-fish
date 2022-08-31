using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCrab : Boss
{
    public ParticleSystem SkillNippers;
    public ParticleSystem SkillArmor;
    public ParticleSystem SkillBubble;
    public ParticleSystem HealEffect;

    public GameObject ArmL;
    public GameObject ArmR;
    public GameObject L2;
    public GameObject L3;
    public GameObject L4;
    public GameObject R2;
    public GameObject R3;
    public GameObject R4;

    public GameObject Bullet;

    public GameObject Point1;
    public GameObject Point2;

    Rigidbody2D RB;
    Vector2 Dir; // 킹크랩 움직임 방향
    bool STOP; // 킹크랩 멈출 때 사용

    float timer2; // 테스트용
    float waitTime;

    public bool NippersFlag;

    Vector3 ArmDir;
    float ArmAngles;
    float ArmSpeed;
    float CurrentArmAngles;

    float DieAngles;
    float CurrentAngles;

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        Player = GameObject.FindGameObjectWithTag("Player");
        QM = GameObject.FindGameObjectWithTag("QM");
        RB = GetComponent<Rigidbody2D>();

        Life = true;
        HitFlag = false;

        HP = 30 + QM.GetComponent<QuestManager>().Stayge.GetComponent<Stage>().HardConst * 3;
        Speed = 1.5f;
        RotationSpeed = 800f;
        FRZFlag = false;

        NippersFlag = false;

        timer = 0f;
        timer_ = 0f;
        timer2 = 0f;
        waitTime = 0f;

        Dir = Vector2.zero;
        STOP = false;

        ArmAngles = 0f;
        ArmSpeed = 5f;
        CurrentArmAngles = 0f;
        DieAngles = 60f;
        transform.name = "KingCrab";
    }

    void Update()
    {
        
        if (HP > 0 && !FRZFlag && Life)
        {

            timer += Time.deltaTime;
            timer_ += Time.deltaTime;
            timer2 += Time.deltaTime; // 테스트 타이머

            if (timer_ >= Random.Range(3f, 7f) + waitTime)
            {
                ArmDir = Player.transform.position - transform.position;

                if (HP >= 15) // 페이즈 1
                {
                    if (ArmDir.magnitude <= 6f)
                        CreateNippers();
                    else
                    {
                        STOP = true;
                        CreateTrash();
                    }
                }
                else // 페이즈 2
                {
                    if (ArmDir.magnitude > 3f && ArmDir.magnitude <= 6f)
                        CreateNippers();
                    else if ((Player.transform.position - transform.position).magnitude <= 3f)
                        CreateArmor();
                    else
                    {
                        STOP = true;
                        waitTime += 2.5f;
                        CreateBubble();
                    }
                }

                timer_ = 0f;
            }

            MoveArm();
        }

        MoveCrab();
        DEADorALIVE();
    }

    void CreateNippers()
    {
        Vector3 Position;

        if (ArmDir.x < 0)
        {
            Position = Point1.transform.position + new Vector3(-2f, 0f, 0f);
            NippersFlag = true;  // left
        }
        else
        {
            Position = Point2.transform.position + new Vector3(2f, 0f, 0f); ;
            NippersFlag = false; // right
        }

        var Nippers = Instantiate(SkillNippers, Position, Quaternion.Euler(0, 0, 0));
    }

    void CreateArmor()
    {
        var Armor = Instantiate(SkillArmor, transform.position, Quaternion.Euler(0, 0, 0));
        Armor.transform.parent = transform;
    }

    void CreateBubble() // 입에 게거품은 5초간 지속
    {
        var Bubble = Instantiate(SkillBubble, transform.position, Quaternion.Euler(0, 0, 0));
    }

    void CreateTrash()
    {
        ArmAngles = 120f;
        ArmSpeed = 5f;
        Invoke("DefaultPositionArms", 1.1f);
    }

    void DefaultPositionArms()
    {
        ArmAngles = 0f;
        ArmSpeed = 3f;
    }

    void MoveArm()
    {
        Vector3 target = Vector3.zero;

        CurrentArmAngles = Mathf.Lerp(CurrentArmAngles, ArmAngles, Time.deltaTime * ArmSpeed);

        if (ArmDir.x < 0)
        {
            ArmL.transform.localEulerAngles = new Vector3(0f, 0f, CurrentArmAngles);
            target = Point1.transform.position;
        }
        else if (ArmDir.x > 0)
        {
            ArmR.transform.localEulerAngles = new Vector3(0f, 0f, -CurrentArmAngles);
            target = Point2.transform.position;
        }

        if (CurrentArmAngles >= 119.5f)
        {
            var bullet_ = Instantiate(Bullet, target, Quaternion.Euler(0f, 0f, 0f));
            bullet_.GetComponent<bullet>().SetDir(target - new Vector3(transform.position.x, transform.position.y + Random.Range(0f, 1.6f), transform.position.z));
        }
    }

    void MoveCrab()
    {
        if (timer2 >= 2f + waitTime)
        {
            Vector3 V = Player.transform.position - transform.position;

            if (V.x <= -2f)
                Dir = Vector2.left * Speed;
            else if (V.x >= 2f)
                Dir = Vector2.right * Speed;
            else
                Dir = Vector2.zero;
                
            timer2 = 0f;
            waitTime = 0f;
        }

        if (FRZFlag || HP == 0 || STOP)
        {
            STOP = false;
            Dir = Vector2.zero;
            timer2 = 0f;
        }

        if (HP <= 0 && Life)
        {
            Dir = Vector2.down;
            Speed = 0.5f;
        }

        RB.velocity = Dir * Speed;
    }

    public void RecoveryHP()
    {
        if (HP < 14)
            HP += 2;
        else if (HP < 15)
            HP++;

        var Heal = Instantiate(HealEffect, transform.position, Quaternion.Euler(0, 0, 0));
        Heal.transform.parent = transform;
        Heal.transform.localScale *= 2f;
        Destroy(Heal.gameObject, 4f);
    }

    public void DEADorALIVE()
    {
        if (HP <= 0 && Life)
        {
            gameObject.layer = 4;

            CurrentAngles = Mathf.Lerp(CurrentAngles, DieAngles, Time.deltaTime * 1.5f);

            ArmL.transform.localEulerAngles = new Vector3(0f, 0f, -CurrentAngles);
            ArmR.transform.localEulerAngles = new Vector3(0f, 0f, CurrentAngles);
            L2.transform.localEulerAngles = new Vector3(0f, 0f, -CurrentAngles);
            L3.transform.localEulerAngles = new Vector3(0f, 0f, -CurrentAngles / 2);
            L4.transform.localEulerAngles = new Vector3(0f, 0f, -CurrentAngles / 2);
            R2.transform.localEulerAngles = new Vector3(0f, 0f, CurrentAngles);
            R3.transform.localEulerAngles = new Vector3(0f, 0f, CurrentAngles / 2);
            R4.transform.localEulerAngles = new Vector3(0f, 0f, CurrentAngles / 2);

            if (CurrentAngles >= DieAngles - 5f)
            {
                Life = false;
                Invoke("win", 2f);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.transform.tag == "Knife" && other.transform.parent.tag == "Player"))
        {
            float R = Random.Range(1f, 2.5f);
            other.gameObject.GetComponent<HitFeel>().TimeStop(0f);
            if (HP > 0)
            {
                transform.GetComponent<CrabSkin>().OnOutline();

                var DT = Instantiate(DamageText, transform.position, Quaternion.Euler(0f, 0f, 0f));
                DT.GetComponent<DamageTxt>().dtxt.text = 1.ToString();
                DT.transform.localScale *= 2f;
                HP--;

                var KE = Instantiate(KillEffect, other.contacts[0].point, Quaternion.Euler(0f, 0f, 0f));
                float x_ = transform.localScale.x;
                if (x_ > 0)
                    x_ *= -1;

                KE.transform.localScale = new Vector3(1, 1, 1) * R;
            }

            var KS = Instantiate(KS_, transform.position, Quaternion.Euler(0f, 0f, 0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (HP > 0)
        {
            if (other.transform.tag == "EXPL")
            {
                HitEXPL_(other.gameObject);
            }

            if (other.gameObject.tag == "FRZ")
            {
                FRZOn();
                Invoke("FRZOff", 2.5f);
            }
        }
    }
}
