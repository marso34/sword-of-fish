using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    
    public bool UseItem_;
    public float FRZTimer;
    public float FRZWatime;
    public GameObject DamageText;
    bool Flag_ = false;
    public Rigidbody2D RB;
    public int AnimFlame = 10; // ? ? ?¤?ë¦? ??¸ ?? ?
    public int DieAnimFlame = 10; // ì£½ì ? ? ?¤?ë¦¬ì?¸ ?? ?
    public GameObject Barriar;
    public ParticleSystem Skill; // J
    public GameObject Skill2; // J
    public ParticleSystem BubbleP; // J
    public bool isMove = false; //???ì§ì??
    public enum State { Idle, Move, Die, };//???¤ ì§í©
    public State state;// ??¬??
    public int PlayerCount = 8;
    public bool BSErrorFlag;
    public float Speed;//ë³??? ?¤?¼?ë¥? ?´? ë³??
    public float RotationSpeed;//?? ??
    public float MovementSpeed;//ê¸°ë³¸ ?¤?¼?¸ ??
    public float BusterSpeed;
    public bool BusterFlag;
    public bool ErrorFlag; // ¸ð¹ÙÀÏ ÇÃ·¡±× ¿¡·¯ ¼öÁ¤

    public float TempMovementSp; // J
    public float TempBusterSp; // J
    public float TempRotateSp; // J
    public bool StateMoveFlag_;
    public bool StateRotateFlag_;

    public bool XFlag;
    public bool YFlag;
    float MaxSize = 2f;
    public int fleshCount = 0;
    public SpriteRenderer MFish;// ?´ ë¬¼ê³ ê¸? ?¤?¨ ?? ê°ì²´?? ì´ê¸°?
    public SpriteRenderer MKnife;//?´ ì¹? ?¤?¨// ???? ì´ê¸°?.
    public GameObject MyKnife;
    public GameObject MyBody;
    //LOBBYPLAYER?? ì´ê¸°??¨
    public int FishNumber;//0~N GameManager ?? ?? ?  ? ì´ê¸°? ?´ì¤?
    public int KnifeNumber;//0~N GameManager ?? ?? ?  ? ì´ê¸°? ?´ì¤?


    public GameObject Skin;// ?¤?¨ ?´ê¸? ?¤ë¸ì ?¸
    public Skin skin_;//?¤?¨
    public GameObject Flesh;//?ì²? ì°¸ì¡°
    public float chsize = 0.05f;


    public GameObject Bubble;// ë²ë¸ ê°ì²´  

    public bool StartFlag;// ê²ì ??? ?ë¦¬ë ?? ê·?.

    public bool Life = true;//?´? ? ?´ë°? ? ??¸? ?¶&ì£½ì ? ?´?ê¸°ì?ë³?? ? ?? ?´ life? ?? ? ëª»ë°ê¾¸ê¸°?ë¬?. ? ? ?¬??ê³ëë§? ??ê¸°ì½???±? 

    public int killScore;//?¬?¤ì½ì´

    public bool endFlag;//ê²ì ??´?ë³??

    public bool SkillFlag; // 

    public GameObject GM;// ê²ìë§¤ë? ¸
    public Color C;//ìºë¦­?° ?¬ëªëë³?ê²½í ??¸ë³?? (ì£½ì?)
    public Sprite[] KnifeAnims;//ì¹¼ì ?
    public Sprite[] BodyAnims;//ëª¸ì ?
    public SpriteRenderer S;//ëª¸í¬ëªë ë°ê??? ?°?ë³??

    public GameObject BubbleSound;
    public Vector3 dir;//???ì§ì
                       // Start is called before the first frame update
    public GameObject Flag_Image;
    public bool Flag_get;
    public int HP = 5;
    public bool hitFlag;
    public bool flagerror = true;
    public GameObject KillSound;
    public GameObject PlayerHitSound;
    public GameObject QM;

    //--------//Æ©Åä¸®¾ó¿¡¼­ »ç¿ë
    public bool skillcheck = false;
    //public bool TutorialLev4 = false;

    public int Timer33 = 0;
    public double Timer22 = 0;
    public float MoveTime = 3f;
    public bool TuLev1 = false;
    public bool SlowFlag;
    public Vector2 VWall;
    public bool SharkFlag;

    public bool FRZFlag;

    public void GameStartInit()// ê²ì??? ?ë²ì¤?
    {
        Init_();
        StartFlag = false;
        InitTemp();
        //DefaultMoveSpeed();
        DefaultRotateSpeed();
        XFlag = false;
        YFlag = false;
        VWall = Vector2.zero;
    }
    public void StopTime_()
    {
        Time.timeScale = 0.01f;
    }
    public void StartTime_()
    {
        Time.timeScale = 1;
        //transform.parent.GetComponent<Player>().HP--;
    }
    public void GameWaitInit()//??´?¬?¨??? ê¸°ë¤ë¦´ë
    {
        MFish = Skin.GetComponent<SpriteRenderer>();//?¤?¨? SpriteRenderer ì°¸ì¡°
        MKnife = MyKnife.GetComponent<SpriteRenderer>();//ì¹¼ì SpriteRenderer
        BSErrorFlag = true;

    }//ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿? ï¿½Ã·ï¿½ï¿½Ì¾ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½Ì±ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ì°ï¿½ ï¿½Ê±ï¿½È­    

    public IEnumerator Start_()//?¼ë°ì ?¸ ?¤????¸ (ì½ë£¨?´) ë°ë³µë¬¸ì.)
    {
        while (true) yield return StartCoroutine(state.ToString());//ì½ë£¨?´ ?¤? ë§¤í? ?ë§ë¤. ì½ë£¨?´ ?¸?°?· ê²???´? ??ë³´ê¸°
    }
    public void Init_()//ì´ê¸°?
    {
        MyKnife.tag = "Knife";
        MyBody.tag = "Body";
    }

    public void InitTemp()
    {
        RotationSpeed = 1200f;
        TempMovementSp = 2.3f; //J
        TempBusterSp = 4.6f;     // J
        TempRotateSp = 1200f;   // J
    }

    public void FRZOn()
    {
        FRZTimer = 0;
        FRZFlag = true;
    }

    public void FRZOff()
    {
        FRZFlag = false;
        C = Color.white;
        S.color = C;
    }

    // public void DefaultMoveSpeed()
    // {
    //     if (StateMoveFlag_ == false)
    //     {
    //         if (GameObject.FindGameObjectWithTag("BS") != null) ;
    //         Destroy(GameObject.FindGameObjectWithTag("BS"));
    //         // if (transform.tag == "Player")
    //         //     Debug.Log("¿ø·¡ ¼Óµµ");
    //         
    //         StateMoveFlag_ = false;
    //         DefaultRotateSpeed();
    //         BSErrorFlag = true;
    //     }
    //     // 
    // }

    public void DefaultRotateSpeed()
    {
        if (StateRotateFlag_ == false)
        {
            RotationSpeed = 1200f;
            // Debug.Log("¿ø·¡ È¸Àü");
        }
    }

    public void StopMoveSpeed()
    {
        if (StateMoveFlag_ == false)
        {
            Speed = 0f;
            MovementSpeed = 0f;
            BusterSpeed = 0f;
            StateMoveFlag_ = true;
            Debug.Log("Á¤Áö");
            Invoke("InitState", 2.5f);
            Invoke("DefaultRotateSpeed", 2.5f);
        }
    }


    public void StopRotateSpeed()
    {
        if (StateRotateFlag_ == false)
        {
            RotationSpeed = 0.0001f;
            StateRotateFlag_ = true;
        }
    }


    public void FastSpeed(float index)// ë¬¼ê³ ê¸? ?´??? ë©??°?? ?ê¸°í.
    {
        if (!SharkFlag && transform.tag == "Player")
        {
            var b = Instantiate(BubbleSound, transform.position, Quaternion.Euler(0, 0, 0));
            b.tag = "BS";
        }
        BusterFlag = true;
    }

    public void OffFastSpeed()
    {
        if (GameObject.FindGameObjectWithTag("BS"))
            Destroy(GameObject.FindGameObjectWithTag("BS"));
        BusterFlag = false;
    }
    public void Sharkmove()
    {
        var b = Instantiate(BubbleSound, transform.position, Quaternion.Euler(0, 0, 0));
        b.tag = "BS";
        SharkFlag = true;
        Invoke("SharkOff", 3f);
    }
    public void SharkOff()
    {

        if (GameObject.FindGameObjectWithTag("BS"))
            Destroy(GameObject.FindGameObjectWithTag("BS"));
        SharkFlag = false;
    }
    public void SlowMoveSpeed(float index)
    {
        // if (StateMoveFlag_ == false)
        // {
        //     MovementSpeed = index;
        //     Speed = index;
        //     Debug.Log(Speed + "slowMove");
        //     BusterSpeed = index * 2;
        //     StateMoveFlag_ = true;
        //     ErrorFlag = false;
        //     SetColor(Color.green);
        //     Invoke("InitState", 2.5f);

        // }
        SetColor(Color.green);
        SlowFlag = true;
        Invoke("OffSlow", 2f);
    }
    public void OffSlow()
    {
        SlowFlag = false;
        InitState();
    }
    // public void SlowRotateSpeed(float index)
    // {
    //     // if (StateRotateFlag_ == false)
    //     // {
    //     //     RotationSpeed = index * 300;
    //     //     Debug.Log(RotationSpeed + "slowRotate");
    //     //     StateRotateFlag_ = true;
    //     // }

    // }

    public void InitState() //J ì´ê¸°?
    {
        if (Life)
        {
            C = Color.white;
            // StateMoveFlag_ = false;
            // StateRotateFlag_ = false;
            //    DefaultMoveSpeed();
            //  DefaultRotateSpeed();

        }
    }
    public void NotInit()
    {
        MyKnife.tag = "NotKnife";
        MyBody.tag = "NotBody";

    }//not?¼ë¡? ì´ê¸°?
    public void InitBody__()
    {
        if (Life)
        {
            MyBody.tag = "Body";
            MyKnife.tag = "Knife";
            state = State.Move;
            hitFlag = false;
        }
    }
    public void LifeOff()
    {
        Life = false;
    }
    public virtual void DieLife()// ì£½ì??,??ê¸°ë³¸??ë¡?,?ê·? ì£½ì?¼ë¡?, ?¼?´? ì£½ì?¼ë¡?, ì»¬ë¬ë¦¬ì,?ì²´ì?±,2ì´ë¤ë¶??
    {

    }
    public void Glitter()
    {
        translucence();
        Invoke("ResetColor", 0.2f);
        Invoke("translucence", 0.3f);
        Invoke("ResetColor", 0.4f);
        Invoke("translucence", 0.5f);

    }
    public void WhiteFlesh()
    {
        OnOutLine(14);
        Invoke("OffOutLine", 0.07f);
    }
    public void Check_Flag()
    {
        if (!Flag_get) Flag_Image.GetComponent<Image>().color = Color.clear;
        else if (Flag_get) Flag_Image.GetComponent<Image>().color = Color.white;
    }
    public void CreateFlesh()//?ì²´ì?±
    {
        for (int i = 0; i < 3 + transform.localScale.y; ++i)
        {
            var flesh_ = Instantiate(Flesh, transform.position + RandomFleshPosition(), Quaternion.Euler(0, 0, 0));
        }
    }//?ì²? ë§ë¤ê¸?

    public Vector3 RandomFleshPosition() //??¤? ?ì²´ìì¹ë°±?° ë°í
    {
        return new Vector3(Random.Range(-1.2f, 1.2f), Random.Range(-1.2f, 1.2f), 0);
    }

    public Vector3 RandomPosition(bool AiFlag) //??¤? ?ì¹ë°±?° ë°í
    {
        Vector3 relate = Vector3.zero;
        if (AiFlag)
        {
            relate = GameObject.FindWithTag("Player").transform.position;
        }
        return new Vector3(Random.Range(-20, 20), Random.Range(-10, 10), 0);
    }
    public bool jugeAi()
    {
        if (transform.tag == "AiPlayer")
            return true;
        else return false;
    }
    // public void Respone()//ë¶??ê³¼ì 
    // {
    //     if (transform.tag == "AiPlayer")
    //     {
    //         ResetColor();
    //         Vector3 postion_ = RandomPosition(jugeAi());
    //         transform.Translate(postion_, Space.World);//??¤??ì¹ì ??±    
    //         Life = true;
    //         SetRandomBody();
    //         SetRandomKnife();
    //         //sizeInit();
    //     }
    // }

    public void SetRandomBody()//?ë¡ì´ ë°ë ?¤?¨?»?´?¤ê¸?
    {
        if (transform.tag == "AiPlayer")
        {
            int R = Random.Range(5, 6);// ëª¸ì¤?¨ê°??5

            if (QM.GetComponent<QuestManager>().Level_ != 0 && (QM.GetComponent<QuestManager>().Level_ % 2 == 0) && QM.GetComponent<QuestManager>().IngameLevel == 3)
                {
                    if(QM.GetComponent<QuestManager>().Stayge.GetComponent<Stage23>().WaveLevel == 1) FishNumber = 5;
                    else FishNumber = 9;
                }
            else
                FishNumber = 5;
        }

    }

    public void SetRandomKnife()// ?ë¡ì´ ì¹? ?¤?¨?»?´?¤ê¸?
    {
        int R = Random.Range(1, 6);//ì¹¼ì¤?¨ê°??6
        KnifeNumber = R;
    }

    public void InitKnife()// ë¬¼ê³ ê¸? ?? ê·¸ë?¼ê¸°ë°ì¼ë¡? ?¤?¨? ì´ê¸°?
    {
        KnifeAnims = new Sprite[10];
        if (KnifeNumber == 0) KnifeAnims = skin_.BasicKnife;
        else if (KnifeNumber == 1) KnifeAnims = skin_.SpearKnife;
        else if (KnifeNumber == 2) KnifeAnims = skin_.PanKnife_R;
        else if (KnifeNumber == 3) KnifeAnims = skin_.Rager_R;
        else if (KnifeNumber == 4) KnifeAnims = skin_.XKnife;
        else if (KnifeNumber == 5) KnifeAnims = skin_.CandyKnife;
    }

    public void InitBody()//ì¹? ?? ê·? ê¸°ë°?¼ë¡? ?¤?¨? ì´ê¸°?
    {
        BodyAnims = new Sprite[10];
        if (FishNumber == 0) BodyAnims = skin_.FirstTailAnims;
        else if (FishNumber == 1) BodyAnims = skin_.SharkTailAnims;
        else if (FishNumber == 2) BodyAnims = skin_.BlowfishTailAnims;
        else if (FishNumber == 3) BodyAnims = skin_.OctopusTailAnims;
        else if (FishNumber == 4) BodyAnims = skin_.WaileTailAnims_R;
        else if (FishNumber == 5) BodyAnims = skin_.BornAnims_E;
        else if (FishNumber == 6) BodyAnims = skin_.Gabock_E;
        else if (FishNumber == 7) BodyAnims = skin_.InkOctAnims_E;
        else if (FishNumber == 8) BodyAnims = skin_.Granpa_V;
        else if (FishNumber == 9) BodyAnims = skin_.PupleAnims_E;
    }
    public void InitDieBody()
    {
        if (FishNumber == 0) MFish.sprite = skin_.DieAnims[0];
        else if (FishNumber == 1) MFish.sprite = skin_.DieAnims[1];
        else if (FishNumber == 2) MFish.sprite = skin_.DieAnims[2];
        else if (FishNumber == 3) MFish.sprite = skin_.DieAnims[3];
        else if (FishNumber == 4) MFish.sprite = skin_.DieAnims[4];
        else if (FishNumber == 5) MFish.sprite = skin_.DieAnims[5];
        else if (FishNumber == 6) MFish.sprite = skin_.DieAnims[6];
        else if (FishNumber == 9) MFish.sprite = skin_.DieAnims[6];
    }
    public void ResetColor()//?¬ëªë 0?¼ë¡? ì¦? ?¬ëªíì§??ê²?
    {
        C.a = 1f;
        S.color = C;
        MKnife.color = C;
    }
    public void SetColor(Color c)
    {
        S.color = c;
        MKnife.color = C;
        C = c;
    }
    public void translucence() // J ë°í¬ëªíê²?
    {
        C.a = 0.5f;
        S.color = C;
        MKnife.color = C;
    }
    public void sizeInit()//ê¸°ë³¸?¬?´ì¦ë¡ ë°ê¾¸ê¸?
    {
        Sizech(transform.localScale / transform.localScale.y);
    }

    public void KnifeInit()//ê¸°ë³¸?¬?´ì¦ë¡ ë°ê¾¸ê¸?
    {
        MyKnife.transform.parent = null;//ìµë???¬ê¸? ê²??¬ ?¤??¨.,
        if (MyKnife.transform.localScale.x < 0) MyKnife.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        else MyKnife.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        MyKnife.transform.parent = transform;
    }

    public void AnimState(Vector3 dir)//ëª? ? ?ë©ì´? ? ?©, ì¹¼ì ?ë§¤ì´? ? ?©, ?¬? ? ?©?´?¼???° ?ì§? ëª»êµ¬?
    {
        if (Life)
        {
            if (isMove)
            {

                if (!hitFlag)
                    state = State.Move;
                float x_ = transform.localScale.x;// x_? ?? ?´?´?¤ë¸ì ?¸ scale.x ë¥? ?£?. scale.xê°? ???¼? ?? ?´?´? ì¢ì°ë°ì ?¼ë¡? ?? ??¤. ?´ë¥¼ì´?©?´? ?¼ìª½ì¼ë¡? ë§ì´ ??? ?¤ì§ì´ì§? ëª¨ì?´ ???¤ê²? ?¨.
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
            else if (!isMove)
            {
                if (!hitFlag)
                    state = State.Idle;
            }
        }
        else if (!Life)
        {
            state = State.Die;

        }
    }// ì¡°ê±´? ?°?¼ ? ?ë©ì´? ?? ? ?ê¸?.
    IEnumerator Idle()//ë©ì¶¤? ?0.2ì´ë§?¤ shoAnim?¨? ?¤?
    {
        ResetColor();
        ShowBodyAnim(0);
        ShowKnifeAnim(0);
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator Move()//???ì§ì? ?ë§¤ì´??¬?
    {
        ResetColor();
        for (int i = 0; i < AnimFlame; ++i)
        {
            if (!Life || state != State.Move || Speed == 0) break;
            ShowBodyAnim(i);
            ShowKnifeAnim(i);
            for (int j = 0; j < 2; ++j)
            {
                if (Speed == 0) break;
                // CreateBubbles();//ë²ë¸??±

                yield return new WaitForSeconds(0.2f / Speed);

            }
        }
    }
    IEnumerator Die() //ì£½ì ? ?
    {
        for (int i = 0; i < 50; ++i)
        {

            if (i == 49 && !Life && transform.tag != "Player")
            {
                if (gameObject.name == "Boss") transform.GetComponent<AttackerScript>().Win();
                Destroy(gameObject);
            }
            //if (Life) break;
            ShowDieAnim(i);

            yield return new WaitForSeconds(0.01f);
        }
    }
    public void ShowDieAnim(int index)//ì£½ì?? ? ?ë§¤ì´? ?¬??¨?
    {
        InitDieBody();

        if (S.color.a > 0 && !Life)
        {
            for (int i = 0; i < 50; i++)
            {
                if (i == index)
                {
                    C.a -= 0.02f;
                    S.color = C;
                    MKnife.color = C;
                }
            }
        }
    }

    public void ShowBodyAnim(int index)//?´???? ? ?ë§¤ì´? ?¬??¨?
    {
        InitBody();
        for (int i = 0; i < AnimFlame; i++)
        {
            if (!Life || state == State.Die) break;
            if (i == index)
                MFish.sprite = BodyAnims[i];
        }
    }
    public void ShowKnifeAnim(int index)//?´???? ? ?ë§¤ì´? ?¬??¨?
    {
        InitKnife();
        for (int i = 0; i < AnimFlame; i++)
        {
            if (i == index)
                MKnife.sprite = KnifeAnims[i];
        }

    }
    public void rota()
    {
        if (FRZFlag) RotationSpeed = 0f;
        else if (SlowFlag) RotationSpeed = 300f;
        else RotationSpeed = 1200f;
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, RB.velocity.normalized);//?´?ë°©í¥? ë§ê² ? ë©´ì ë³´ëë¡? ?? ê°? ë°ì?¤ê¸?.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);//?? ?´?´?¤ë¸ì ?¸?ê²? ë°ì?¨ ?? ê°? ? ?©
        float x_ = transform.localScale.x;
    }
    public void PlayerMove()
    {
        Speed = TempMovementSp + transform.localScale.y / 2;
        MovementSpeed = TempMovementSp + transform.localScale.y / 2;
        BusterSpeed = TempBusterSp + transform.localScale.y / 2;
        isMove = true; //dir != Vector3.zero;

        if ((transform.tag == "InkOct"||transform.tag == "AiPlayer" ||(transform.tag =="Player" && MyBody.GetComponent<HitFillBody>().SlowFlag_ == false)) && isMove && Life)
        {
            if (isMove)
            {
                Timer22 += Time.deltaTime;
                if (Timer22 > MoveTime)
                {
                    Timer22 = 0;
                    Timer33++;
                }
            }

            if (SharkFlag)
            {
                Speed = BusterSpeed * 3f;
                if (BusterFlag) Speed = BusterSpeed * 4f;
            }
            else if (SlowFlag) Speed = 1f;
            else if (BusterFlag) Speed = BusterSpeed;
            else Speed = MovementSpeed;


            {
                
                RB.velocity = dir * Speed * Time.deltaTime * 60f;
                // RB.AddForce(transform.forward *10f);
                //if (transform.tag == "InkOct") Debug.Log("Å¸ÄÚÀÌµ¿");
                rota();
            }
        }

    }

    public void GetPlayer_tp()// ? ë©? êµ¬í
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Translate(transform.up * 10f, Space.World);
        }
    }//?ë¯¸ì?ì½ë
    public void Sizech(Vector3 v_)
    {
        transform.localScale = v_;
        CheckMaxSize();
        CheckMaxKnife();
    }// ?¬?´ì¦? ?¤?°ê¸? ?? ?´?´???,ê·¸ì? ëª¨ë  ?¤ë¸ì ?¸?¬ê¸? ?¤?°ê¸?
    public void SizeUpKnife()
    {
        SeparationKnife();
        if (MyKnife.transform.localScale.x < 0) MyKnife.transform.localScale = new Vector3(MyKnife.transform.localScale.x - 0.0005f, MyKnife.transform.localScale.y + 0.005f, 1);
        else MyKnife.transform.localScale = new Vector3(MyKnife.transform.localScale.x + 0.005f, MyKnife.transform.localScale.y + 0.005f, 1);
        CombinationKnife();
        CheckMaxKnife();
    }//ì¹¼í¬ê¸? ?¤?°ê¸?
    public void SeparationKnife()
    {
        MyKnife.tag = "NotKnife";
        MyKnife.transform.parent = null;//ìµë???¬ê¸? ê²??¬ ?¤??¨.,
    }//ì¹? ë¶ë¦¬ ëª¸ì???? ????? ?¬ê¸°ê???? ? ???? ?¸ ì¹¼ì ?¬ê¸°ë?¼ìê¸°ì?¨. ? ????¬ê¸°ê?? 3?´? ì»¤ì??ë©? ??¼?.
    public void CombinationKnife()
    {
        MyKnife.transform.parent = transform;
        MyKnife.tag = "Knife";
        MyKnife.transform.localPosition = new Vector3(0f, 0.35f, 0f);
        MyKnife.transform.localRotation = Quaternion.Euler(0, 0, 90f);
    }// ì¹¼ì ?? ?´?´ë¡? ?¤? ?©ì²?
    public void CheckMaxSize()
    {
        if (transform.localScale.y > MaxSize)
        {
            float a = MaxSize, b = MaxSize;

            if (transform.localScale.x < 0) a *= -1;

            Vector3 V__ = new Vector3(a, b, 1);

            Sizech(V__);
        }
    }//ìµë???¬ê¸°ë?? ì²´í¬
    public void CheckMaxKnife()//ì¹¼í¬ê¸? ?´? ì²´í¬
    {
        SeparationKnife();
        if (MyKnife.transform.localScale.y > MaxSize)
        {
            if (MyKnife.transform.localScale.x < 0) MyKnife.transform.localScale = new Vector3(-1f * MaxSize, MaxSize, 1f);
            else MyKnife.transform.localScale = new Vector3(MaxSize, MaxSize, 1f);
        }
        else if (MyKnife.transform.localScale.y < 1)
        {
            if (MyKnife.transform.localScale.x < 0) MyKnife.transform.localScale = new Vector3(-1f * 1, 1, 1f);
            else MyKnife.transform.localScale = new Vector3(1, 1, 1f);
        }
        CombinationKnife();
    }
    public void CreateBubbles()//??¤?ê²? ë§ë¤ê¸? êµ¬í
    {

        int count = 0;
        if (Speed == MovementSpeed) count = 1;
        else if (Speed == BusterSpeed) count = 4;
        for (int i = 0; i < count; ++i)
        {
            float randemX = 0;
            float randemY = 0;
            if (Speed == MovementSpeed)
                randemX = Random.Range(-0.3f, 0.3f); //0.3~-0.3
            else if (Speed == BusterSpeed)
                randemX = Random.Range(-0.4f, 0.4f);

            if (Speed == MovementSpeed)
                randemY = Random.Range(-0.2f, -0.4f); //-0.2 ~-0.4
            else if (Speed == BusterSpeed)
                randemY = Random.Range(-0.2f, -0.6f);

            var V_ = new Vector3(transform.position.x, transform.position.y, 1);
            var bubble_ = Instantiate(Bubble, V_, transform.rotation);
            V_ = new Vector3(transform.position.x + randemX, transform.position.y + randemY, 1);
            bubble_.transform.parent = transform;
            bubble_.transform.localPosition = new Vector3(randemX, randemY, 1);
            bubble_.transform.parent = transform.parent;
            float randemsize = Random.Range(0.2f, 1f);

            bubble_.transform.localScale = transform.localScale * randemsize;
            float bubbleSpeed;
            if (Speed == MovementSpeed) bubbleSpeed = 0.003f;
            else
            {
                bubble_.transform.localScale = new Vector3(bubble_.transform.localScale.x, bubble_.transform.localScale.y, bubble_.transform.localScale.z);
                bubbleSpeed = 0.03f;
            }
            bubble_.GetComponent<bubble>().Speed = bubbleSpeed;
            bubble_.GetComponent<bubble>().dir = dir * -1;
        }


    } //ë²ë¸ë§ë¤ê¸?
    public virtual void KillScoreUp()
    {

        //SizeUpKnife();


    }//?¬?ë©? ?¤????¨?
    public void CheckWall(GameObject other, bool T)//HitPÃæµ¹ ÇÑ ÁöÁ¡
    {
    }//¸Ê¹Û????? ¸ø³ª??°ÔÇÏ?????????
    public void CreatBarriar()//??´? ? ë°©ì´ë§? ê°?ì§?ê³? ??´?ê¸?. ë°©ì´ë§ë§?? ?¨?.
    {
        var a = Instantiate(Barriar, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
        MyBody.tag = "NotBody";
    }

    public void reset_()
    {
        if (GM.GetComponent<GameManager_>().resetFlag)
        {
            if (GameObject.FindGameObjectWithTag("Bubble") != null)
                Destroy(GameObject.FindGameObjectWithTag("Bubble"));
            Destroy(gameObject);
        }
    }

    public void CreateSkill() // J ?¤?¬ ë§ë? ?¨?
    {
        var a = Instantiate(Skill, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void CreateSkill(string Name) // J ?¤?¬ ë§ë? ?¨?
    {
        var a = Instantiate(Skill, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
        a.name = Name;
    }
    public void CreateSkill2() // J ?¤?¬ ë§ë? ?¨?
    {
        var a = Instantiate(Skill2, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void CreateSkill2(string Name) // J ?¤?¬ ë§ë? ?¨?
    {
        var a = Instantiate(Skill2, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
        a.name = Name;
    }
    public void PlaySkill() //J
    {
        skillcheck = true;

        if (FishNumber == 1 && !StateMoveFlag_) // ?????
        {
            SkillFlag = true;
            CreateSkill();
            OnOutLine(1);
            Sharkmove();
            //StateMoveFlag_ = true;
            MyBody.tag = "Shiled";
            Invoke("InitState", 3f);
            Invoke("Init_", 3f);
            Invoke("OffSkillFlag", 3f);
            Invoke("OffOutLine", 3f);
        }
        else if (FishNumber == 2)  // ????
        {
            CreateSkill();
            for (int i = 0; i < 13 + (int)transform.localScale.y * 10; i++)
                CreateSkill2();
        }
        else if (FishNumber == 3)  //????
            CreateSkill2();
        else if (FishNumber == 4)   // ???? ???
        {
            CreateSkill();
            SkillFlag = true;
            MyBody.tag = "Knife";
            Invoke("Init_", 3f);
            Invoke("OffSkillFlag", 3f);
        }
        else if (FishNumber == 9) // ???????
        {
            CreateSkill2();
        }
    }
    public void PlaySkill(string Name) //J
    {
        // Flag_ = !Flag_;
        // if (FishNumber == 0)
        // {
        //     if (Flag_ == true)
        //     {
        //         StopMoveSpeed();
        //     }
        //     else if (Flag_ == false)
        //     {
        //        // DefaultMoveSpeed();
        //     }
        // }
        if (FishNumber == 1 && !StateMoveFlag_) // ?????
        {
            SkillFlag = true;

            OnOutLine(1);

            FastSpeed(3);
            StateMoveFlag_ = true;
            MyBody.tag = "Shiled";
            Invoke("InitState", 3f);
            Invoke("Init_", 3f);
            Invoke("OffSkillFlag", 3f);
            Invoke("OffOutLine", 3f);
        }
        else if (FishNumber == 2)  // ????
        {
            CreateSkill(Name);
            for (int i = 0; i < 13 + (int)transform.localScale.y * 10; i++)
                CreateSkill2(Name);
        }
        else if (FishNumber == 3)  // ????
            CreateSkill2(Name);
        else if (FishNumber == 4)  // ???? ???
        {
            CreateSkill2(Name);
            MyBody.tag = "Shiled";
            Invoke("Init_", 3f);
            SkillFlag = true;
            Invoke("OffSkillFlag", 3f);
        }
        else if (FishNumber == 9) // ???????
        {
            CreateSkill2();
        }
    }

    public void OffSkillFlag() // J
    {
        SkillFlag = false;
    }

    public void OnOutLine(int outlineSize) // J
    {
        Skin.GetComponent<Skin>().outlineSize = outlineSize;
        Skin.GetComponent<Skin>().outline = true;
    }

    public void OffOutLine() // J
    {
        Skin.GetComponent<Skin>().outline = false;
    }
    public void Stage22_ex()
    {
        if (QM.GetComponent<QuestManager>().Level_ != 0 && QM.GetComponent<QuestManager>().Level_ % 2 == 0 && (QM.GetComponent<QuestManager>().IngameLevel == 2 || QM.GetComponent<QuestManager>().IngameLevel == 3))
        {
            GameObject ST = GameObject.FindGameObjectWithTag("Stage");
            if (QM.GetComponent<QuestManager>().IngameLevel == 2)
                ST.GetComponent<Stage22>().EnemyCount--;
            else if (QM.GetComponent<QuestManager>().IngameLevel == 3)
            {
                ST.GetComponent<Stage23>().EnemyCount--;
            }
        }
    }
}