using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCrab : Boss
{
    public ParticleSystem SkillNippers;
    public ParticleSystem SkillArmor;
    public ParticleSystem SkillBubble;


    public GameObject ArmL;
    public GameObject ArmR;
    public GameObject Bullet;

    public GameObject Point1;
    public GameObject Point2;

    public bool NippersFlag;

    float timer2;


    Vector3 ArmDir;
    float ArmAngles;
    float ArmSpeed;
    float CurrentArmAngles;

    void Start()
    {
        Life = true;
        HitFlag = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GM = GameObject.FindGameObjectWithTag("GM");
        Player = GameObject.FindGameObjectWithTag("Player");
        Skin = GetComponent<SpriteRenderer>();
        HP = 12;
        Speed = 3.8f;
        RotationSpeed = 800f;
        FRZFlag = false;
        S = transform.GetComponent<SpriteRenderer>();

        NippersFlag = false;

        timer2 = 0f;
        ArmAngles = 0f;
        ArmSpeed = 5f;
        CurrentArmAngles = 0f;
    }

    void Update()
    {
        timer2 += Time.deltaTime;

        if (timer2 >= 4f)
        {
            CreateNippers();
            // CreateTrash();
            // CreateArmor();
            // CreateBubble();
            timer2 = 0f;
        }

        MoveArm();
    }

    void CreateNippers()
    {
        Vector3 Position;

        if (Player.transform.position.x < 0)
        {
            Position = Point1.transform.position + new Vector3(-0.7f, 0f, 0f);
            NippersFlag = true;  // left
        }
        else
        {
            Position = Point2.transform.position + new Vector3(0.62f, 0f, 0f); ;
            NippersFlag = false; // right
        }

        var Nippers = Instantiate(SkillNippers, Position, Quaternion.Euler(0, 0, 0));
    }

    void CreateArmor()
    {
        var Armor = Instantiate(SkillArmor, transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(Armor, 2f);
    }

    void CreateBubble()
    {

    }

    void CreateTrash()
    {
        ArmDir = Player.transform.position - transform.position;
        ArmAngles = 120f;
        ArmSpeed = 5f;
        Invoke("DefaultPositionArms", 1.1f);
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

    void DefaultPositionArms()
    {
        ArmAngles = 0f;
        ArmSpeed = 3f;
    }
}
