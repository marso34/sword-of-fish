using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictemScript : Player
{
    // Start is called before the first frame update
    bool Prizen = true;
   
    GameObject QM;
    int maxAttacker = 2;
    private void Start()
    {
        MovementSpeed = 2.3f + transform.localScale.y / 2;//3.8
        BusterSpeed = 4.6f + transform.localScale.y / 2;// 부스터 속도 //10      
        Speed = MovementSpeed;// 스피드 변수를 기본스피드로 다시 초기화  
        QM = GameObject.FindGameObjectWithTag("QM");
        Life = true;// 라이프 온
         skin_ = Skin.GetComponent<Skin>();// 스킨오브젝트 참조
        S = Skin.transform.GetComponent<SpriteRenderer>();
        HP =5;
        FishNumber = 8;
        KnifeNumber = 1;
        GameWaitInit();
        StartCoroutine("Start_");
        
    }
    // Update is called once per frame
    void Update()
    {
        
       transform.position = MyBody.transform.position;
        
        
        EmptyKnife();

    }
    public void EmptyKnife()
    {
        MyKnife.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        MyKnife.tag = "NotKnife";
        MyKnife.transform.localScale = new Vector3(0.01f,0.01f,0.01f);

    }
    public override void DieLife(){
         OnOutLine(14);
            Invoke("OffOutLine", 0.07f);
            state = State.Die;
            LifeOff();

            QM = GameObject.FindGameObjectWithTag("QM");
            QM.GetComponent<QuestManager>().LoseFlag = true;
            if (SkillFlag)
                OffSkillFlag(); // J
            InitState(); // J
            NotInit();
            //DefaultMoveSpeed();
           
            Destroy(gameObject, 2f);
    }
}
