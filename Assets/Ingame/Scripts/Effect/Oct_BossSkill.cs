using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oct_BossSkill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GM;
    GameObject Player;
    Vector3 dir;
    double Timer;
    float Speed;
    bool DelFalg;
    SpriteRenderer S;
     Color c;
    public bool FRZFlag;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        Player = GameObject.FindGameObjectWithTag("Player");
        S = transform.GetComponent<SpriteRenderer>(); ;

        init();
    FRZFlag = false;

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "FRZ")
        {
            FRZOn();
            Invoke("FRZOff", 2.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        statusColor();
        if(!FRZFlag){
        Timer += Time.deltaTime;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);// 오브젝트 이동함수 https://www.youtube.com/watch?v=2pf1FE-Xcc8 에나온 코드를 살짝 변형한것.
        transform.Rotate(Vector3.forward * 40 * Time.deltaTime); // 회전
        }

        // if (transform.localScale.y < 1.8f)
        //     transform.localScale = new Vector3(transform.localScale.x * 1.1f, transform.localScale.y * 1.1f, 1f);


        if (Timer > 5f)
            DelFalg = true;
        if (DelFalg)
            DelSkill();
        if (GM.GetComponent<GameManager_>().EndFlag == true) Destroy(gameObject);
    }

    void init()
    {
        dir = Player.transform.position - transform.position; // 플레이어 방향
        transform.Translate(dir.normalized * (transform.parent.localScale.y / 3), Space.World); // 부모 앞으로 이동

        transform.parent = null;
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir.normalized); //이동방향에 맞게 정면을 보도록 회전값 받아오기.
        transform.localRotation = toRotation;

        Speed = 6f;

        transform.tag = "BossSkillA";
    }

    void DelSkill()
    {
        Destroy(gameObject);
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
        if (FRZFlag == true)
        {
            c = new Color(60f / 255f, 150f / 255f, 255f / 255f);
            S.color = c;
           
            transform.GetComponent<Animator>().enabled = false;

        }
        else if (FRZFlag == false)
        {
            c = Color.white;
            S.color = c;
           
            transform.transform.GetComponent<Animator>().enabled = true;


        }
    }
}
