using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSkill : MonoBehaviour
{
    public GameObject GM;
    public GameObject KingCrab;
    public ParticleSystem Nippers; // 집게발 파티클
    public ParticleSystem Effect;
    public GameObject Colider;

    GameObject Player;
    Rigidbody2D RB;

    public bool flag;
    public bool LEFT;
    public bool SkillFlag;


    float timer;
    float waitTime;

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        KingCrab = GameObject.FindGameObjectWithTag("KingCrab");
        Colider.transform.tag = "CrabNippers";
        Player = GameObject.FindGameObjectWithTag("Player");
        RB = transform.GetComponent<Rigidbody2D>();
        
        flag = false;
        LEFT = KingCrab.GetComponent<KingCrab>().NippersFlag;
        SkillFlag = false;
        timer = 0f;
        waitTime = 2f;

        Vector3 dir = Player.transform.position - transform.position;
        RB.velocity = dir.normalized * 1f;
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir.normalized); //이동방향에 맞게 정면을 보도록 회전값 받아오기.
        transform.localRotation = toRotation; //회전값 적용

        if (Nippers != null)
        {
            ParticleSystem.MainModule main = Nippers.main;

            if (main.startRotation.mode == ParticleSystemCurveMode.Constant)
            {
                if (LEFT)
                {
                    Nippers.transform.localScale = new Vector3(2f, -2f, 2f);
                    main.startRotation = (40f + transform.eulerAngles.z) * Mathf.Deg2Rad;
                }
                else
                {
                    Nippers.transform.localScale = new Vector3(2f, 2f, 2f);
                    main.startRotation = (220f - transform.eulerAngles.z) * Mathf.Deg2Rad;
                }
            }
        }
    }

    void Update()
    {
        ParticleSystem.TextureSheetAnimationModule texture = Nippers.textureSheetAnimation;

        timer += Time.deltaTime;

        if (flag) // 플레이어가 닿으면 ture
        {
            RB.velocity = Vector2.zero;
            texture.fps = 5f;
            waitTime = timer + 1f;

            flag = false;
        }

        if (timer >= 0.2f)
            OnOffCollider(true);
            
        if (timer >= waitTime)
            Destroy(gameObject);

        if (GM.GetComponent<GameManager_>().EndFlag == true) Destroy(gameObject);
    }

    public void CreateEffect()
    {
        var E = Instantiate(Effect, EffectPosition(), Quaternion.Euler(0, 0, 0));

        float x_ = transform.localScale.x;

        if (x_ > 0)
            x_ *= -1;

        E.gameObject.GetComponent<Effect>().SetEffect(2);

        flag = false;
    }

    public Vector3 EffectPosition()
    {
        return Colider.transform.position;
    }

    public void OnOffCollider(bool on)
    {
        Colider.GetComponent<CircleCollider2D>().enabled = on;
    }
}
