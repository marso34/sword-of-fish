using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    bool Flag_ = false;
    public Rigidbody2D RB;
    public int AnimFlame = 10; // ? ? ?¤?ëĻ? ??¸ ?? ?
    public int DieAnimFlame = 10; // ėŖŊė ? ? ?¤?ëĻŦė?¸ ?? ?
    public GameObject Barriar;
    public ParticleSystem Skill; // J
    public GameObject Skill2; // J
    public bool isMove = false; //???ė§ė??
    public enum State { Idle, Move, Die, };//???¤ ė§íŠ
    public State state;// ??Ŧ??
    public int PlayerCount = 8;
    public float Speed;//ëŗ??? ?¤?ŧ?ëĨ? ?´? ëŗ??
    public float RotationSpeed;//?? ??
    public float MovementSpeed;//ę¸°ëŗ¸ ?¤?ŧ?¸ ??
    public float BusterSpeed;
    public bool BusterFlag;
    public bool ErrorFlag; // ¸đšŲĀĪ ĮÃˇĄą× ŋĄˇ¯ ŧöÁ¤

    public float TempMovementSp; // J
    public float TempBusterSp; // J
    public float TempRotateSp; // J
    public bool StateMoveFlag_;
    public bool StateRotateFlag_;


    float MaxSize = 2f;
    public int fleshCount = 0;
    public SpriteRenderer MFish;// ?´ ëŦŧęŗ ę¸? ?¤?¨ ?? ę°ė˛´?? ė´ę¸°?
    public SpriteRenderer MKnife;//?´ ėš? ?¤?¨// ???? ė´ę¸°?.
    public GameObject MyKnife;
    public GameObject MyBody;
    //LOBBYPLAYER?? ė´ę¸°??¨
    public int FishNumber;//0~N GameManager ?? ?? ?  ? ė´ę¸°? ?´ė¤?
    public int KnifeNumber;//0~N GameManager ?? ?? ?  ? ė´ę¸°? ?´ė¤?


    public GameObject Skin;// ?¤?¨ ?´ę¸? ?¤ë¸ė ?¸
    public Skin skin_;//?¤?¨
    public GameObject Flesh;//?ė˛? ė°¸ėĄ°
    public float chsize = 0.05f;


    public GameObject Bubble;// ë˛ë¸ ę°ė˛´  

    public bool StartFlag;// ę˛ė ??? ?ëĻŦë ?? ęˇ?.

    public bool Life = true;//?´? ? ?´ë°? ? ??¸? ?ļ&ėŖŊė ? ?´?ę¸°ė?ëŗ?? ? ?? ?´ life? ?? ? ëĒģë°ęž¸ę¸°?ëŦ?. ? ? ?Ŧ??ęŗëë§? ??ę¸°ėŊ???ą? 

    public int killScore;//?Ŧ?¤ėŊė´

    public bool endFlag;//ę˛ė ??´?ëŗ??

    public bool SkillFlag; // 

    public GameObject GM;// ę˛ėë§¤ë? ¸
    public Color C;//ėēëĻ­?° ?ŦëĒëëŗ?ę˛Ŋí ??¸ëŗ?? (ėŖŊė?)
    public Sprite[] KnifeAnims;//ėšŧė ?
    public Sprite[] BodyAnims;//ëĒ¸ė ?
    public SpriteRenderer S;//ëĒ¸íŦëĒë ë°ę??? ?°?ëŗ??

    public GameObject BubbleSound;
    public Vector3 dir;//???ė§ėŧë°ŠíĨ
                       // Start is called before the first frame update
    public GameObject Flag_Image;
    public bool Flag_get;
    public int HP = 5;
    public bool hitFlag;
    public bool flagerror = true;
    public GameObject KillSound;
    public GameObject PlayerHitSound;
    public GameObject QM;

    //--------//ÆŠÅä¸ŽžķŋĄŧ­ ģįŋë
    public bool skillcheck = false;
    public bool TutorialLev4 = false;

    public int Timer33 = 0;
    public double Timer22 = 0;
    public float MoveTime = 3f;
    public bool TuLev1 = false;

    public void GameStartInit()// ę˛ė??? ?ë˛ė¤?
    {
        Init_();
        StartFlag = false;
        InitTemp();
        DefaultMoveSpeed();
        DefaultMoveSpeed();
    }

    public void GameWaitInit()//??´?Ŧ?¨??? ę¸°ë¤ëĻ´ë
    {
        MFish = Skin.GetComponent<SpriteRenderer>();//?¤?¨? SpriteRenderer ė°¸ėĄ°
        MKnife = MyKnife.GetComponent<SpriteRenderer>();//ėšŧė SpriteRenderer


    }//īŋŊīŋŊīŋŊīŋŊīŋŊīŋŊīŋ? īŋŊÃˇīŋŊīŋŊĖžīŋŊ īŋŊīŋŊ īŋŊīŋŊīŋŊĖąīŋŊīŋŊīŋŊīŋŊīŋŊīŋŊīŋŊ īŋŊīŋŊīŋŊīŋŊ īŋŊīŋŊīŋŊīŋŊīŋŊĖ°īŋŊ īŋŊĘąīŋŊČ­    

    public IEnumerator Start_()//?ŧë°ė ?¸ ?¤????¸ (ėŊëŖ¨?´) ë°ëŗĩëŦ¸ė.)
    {
        while (true) yield return StartCoroutine(state.ToString());//ėŊëŖ¨?´ ?¤? ë§¤í? ?ë§ë¤. ėŊëŖ¨?´ ?¸?°?ˇ ę˛???´? ??ëŗ´ę¸°
    }
    public void Init_()//ė´ę¸°?
    {
        MyKnife.tag = "Knife";
        MyBody.tag = "Body";
    }

    public void InitTemp()
    {
        RotationSpeed = 1200f;
        TempMovementSp = 2.3f; //J
        TempBusterSp = 4.6f;     // J
        TempRotateSp = RotationSpeed;   // J
    }

    public void DefaultMoveSpeed()
    {
        if (transform.tag == "Player")
        Debug.Log("ŋøˇĄ ŧĶĩĩ");
        Speed = TempMovementSp + transform.localScale.y / 2;
        MovementSpeed = TempMovementSp + transform.localScale.y / 2;
        BusterSpeed = TempBusterSp + transform.localScale.y / 2;
        StateMoveFlag_ = false;
        
        // 
    }

    public void DefaultRotateSpeed()
    {
        RotationSpeed = TempRotateSp;
        StateRotateFlag_ = false;
        Debug.Log("ŋøˇĄ Č¸Āü");
    }

    public void StopMoveSpeed()
    {
        Speed = 0.0001f;
        MovementSpeed = 0.0001f;
        BusterSpeed = 0.0001f;
        StateMoveFlag_ = true;
        Debug.Log("Á¤Áö");
    }

    public void StopRotateSpeed()
    {
        RotationSpeed = 0.0001f;
        StateRotateFlag_ = true;
    }

    public void FastSpeed(float index)// ëŦŧęŗ ę¸? ?´??? ëŠ??°?? ?ę¸°í.
    {
        if (StateMoveFlag_ == false)
        {
            Speed = BusterSpeed * index;
        }
    }

    public void SlowMoveSpeed(float index)
    {
        if (StateMoveFlag_ == false)
        {
            MovementSpeed = index;
            Speed = index;
            Debug.Log(Speed +"slowMove");
            BusterSpeed = index * 2;
            StateMoveFlag_ = true;
            ErrorFlag = false;
        }
    }

    public void SlowRotateSpeed(float index)
    {
        if (StateRotateFlag_ == false)
        {
            RotationSpeed = index * 300;
            Debug.Log(RotationSpeed +"slowRotate");
            StateRotateFlag_ = true;
        }
    }

    public void InitState() //J ė´ę¸°?
    {
        if (Life)
        {
            C = Color.white;
            DefaultMoveSpeed();
            DefaultRotateSpeed();
        }
    }
    public void NotInit()
    {
        MyKnife.tag = "NotKnife";
        MyBody.tag = "NotBody";

    }//not?ŧëĄ? ė´ę¸°?
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
    public virtual void DieLife()// ėŖŊė??,??ę¸°ëŗ¸??ëĄ?,?ęˇ? ėŖŊė?ŧëĄ?, ?ŧ?´? ėŖŊė?ŧëĄ?, ėģŦëŦëĻŦė,?ė˛´ė?ą,2ė´ë¤ëļ??
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
        Color a;
        a.a = 0;
        a.b = 1;
        a.g = 1;
        a.r = 1;
        Color b;
        b.a = 1;
        b.b = 1;
        b.g = 1;
        b.r = 1;
        if (!Flag_get) Flag_Image.GetComponent<Image>().color = a;
        else if (Flag_get) Flag_Image.GetComponent<Image>().color = b;
    }
    public void CreateFlesh()//?ė˛´ė?ą
    {

        for (int i = 0; i < 3 + transform.localScale.y; ++i)
        {
            var flesh_ = Instantiate(Flesh, transform.position + RandomFleshPosition(), Quaternion.Euler(0, 0, 0));

        }


    }//?ė˛? ë§ë¤ę¸?

    public Vector3 RandomFleshPosition() //??¤? ?ė˛´ėėšë°ą?° ë°í
    {
        return new Vector3(Random.Range(-1.2f, 1.2f), Random.Range(-1.2f, 1.2f), 0);
    }

    public Vector3 RandomPosition(bool AiFlag) //??¤? ?ėšë°ą?° ë°í
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
    // public void Respone()//ëļ??ęŗŧė 
    // {
    //     if (transform.tag == "AiPlayer")
    //     {
    //         ResetColor();
    //         Vector3 postion_ = RandomPosition(jugeAi());
    //         transform.Translate(postion_, Space.World);//??¤??ėšė ??ą    
    //         Life = true;
    //         SetRandomBody();
    //         SetRandomKnife();
    //         //sizeInit();
    //     }
    // }

    public void SetRandomBody()//?ëĄė´ ë°ë ?¤?¨?ģ?´?¤ę¸?
    {
        if (transform.tag == "AiPlayer")
        {
            int R = Random.Range(5, 6);// ëĒ¸ė¤?¨ę°??5
            FishNumber = R;
        }

    }

    public void SetRandomKnife()// ?ëĄė´ ėš? ?¤?¨?ģ?´?¤ę¸?
    {
        int R = Random.Range(1, 6);//ėšŧė¤?¨ę°??6
        KnifeNumber = R;

    }

    public void InitKnife()// ëŦŧęŗ ę¸? ?? ęˇ¸ë?ŧę¸°ë°ėŧëĄ? ?¤?¨? ė´ę¸°?
    {
        KnifeAnims = new Sprite[10];
        if (KnifeNumber == 0) KnifeAnims = skin_.BasicKnife;
        else if (KnifeNumber == 1) KnifeAnims = skin_.SpearKnife;
        else if (KnifeNumber == 2) KnifeAnims = skin_.PanKnife_R;
        else if (KnifeNumber == 3) KnifeAnims = skin_.Rager_R;
        else if (KnifeNumber == 4) KnifeAnims = skin_.XKnife;
        else if (KnifeNumber == 5) KnifeAnims = skin_.CandyKnife;
    }

    public void InitBody()//ėš? ?? ęˇ? ę¸°ë°?ŧëĄ? ?¤?¨? ė´ę¸°?
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
    }
    public void ResetColor()//?ŦëĒë 0?ŧëĄ? ėĻ? ?ŦëĒíė§??ę˛?
    {
        C.a = 1f;
        S.color = C;
        MKnife.color = C;
    }

    public void translucence() // J ë°íŦëĒíę˛?
    {
        C.a = 0.5f;
        S.color = C;
        MKnife.color = C;
    }
    public void sizeInit()//ę¸°ëŗ¸?Ŧ?´ėĻëĄ ë°ęž¸ę¸?
    {
        Sizech(transform.localScale / transform.localScale.y);
    }

    public void KnifeInit()//ę¸°ëŗ¸?Ŧ?´ėĻëĄ ë°ęž¸ę¸?
    {
        MyKnife.transform.parent = null;//ėĩë???Ŧę¸? ę˛??Ŧ ?¤??¨.,
        if (MyKnife.transform.localScale.x < 0) MyKnife.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        else MyKnife.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        MyKnife.transform.parent = transform;
    }

    public void AnimState(Vector3 dir)//ëĒ? ? ?ëŠė´? ? ?Š, ėšŧė ?ë§¤ė´? ? ?Š, ?Ŧ? ? ?Š?´?ŧ???° ?ė§? ëĒģęĩŦ?
    {
        if (Life)
        {
            if (isMove)
            {

                if (!hitFlag)
                    state = State.Move;
                float x_ = transform.localScale.x;// x_? ?? ?´?´?¤ë¸ė ?¸ scale.x ëĨ? ?Ŗ?. scale.xę°? ???ŧ? ?? ?´?´? ėĸė°ë°ė ?ŧëĄ? ?? ??¤. ?´ëĨŧė´?Š?´? ?ŧėĒŊėŧëĄ? ë§ė´ ??? ?¤ė§ė´ė§? ëĒ¨ė?´ ???¤ę˛? ?¨.
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
    }// ėĄ°ęą´? ?°?ŧ ? ?ëŠė´? ?? ? ?ę¸?.
    IEnumerator Idle()//ëŠėļ¤? ?0.2ė´ë§?¤ shoAnim?¨? ?¤?
    {
        ResetColor();
        ShowBodyAnim(0);
        ShowKnifeAnim(0);
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator Move()//???ė§ė? ?ë§¤ė´??Ŧ?
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
                // CreateBubbles();//ë˛ë¸??ą

                yield return new WaitForSeconds(0.2f / Speed);

            }
        }
    }
    IEnumerator Die() //ėŖŊė ? ?
    {
        for (int i = 0; i < 50; ++i)
        {
            //if (Life) break;
            ShowDieAnim(i);

            yield return new WaitForSeconds(0.01f);
        }
    }
    public void ShowDieAnim(int index)//ėŖŊė?? ? ?ë§¤ė´? ?Ŧ??¨?
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

    public void ShowBodyAnim(int index)//?´???? ? ?ë§¤ė´? ?Ŧ??¨?
    {
        InitBody();
        for (int i = 0; i < AnimFlame; i++)
        {
            if (!Life || state == State.Die) break;
            if (i == index)
                MFish.sprite = BodyAnims[i];
        }
    }
    public void ShowKnifeAnim(int index)//?´???? ? ?ë§¤ė´? ?Ŧ??¨?
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
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, RB.velocity.normalized);//?´?ë°ŠíĨ? ë§ę˛ ? ëŠ´ė ëŗ´ëëĄ? ?? ę°? ë°ė?¤ę¸?.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);//?? ?´?´?¤ë¸ė ?¸?ę˛? ë°ė?¨ ?? ę°? ? ?Š
        float x_ = transform.localScale.x;
    }
    public void PlayerMove()
    {
        isMove = true; //dir != Vector3.zero;

        if (isMove && Life)
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

            RB.velocity = dir * Speed * Time.deltaTime * 60f;
            // transform.Translate(dir * Speed * Time.deltaTime, Space.World);// ?¤ë¸ė ?¸ ?´??¨? https://www.youtube.com/watch?v=2pf1FE-Xcc8 ???¨ ėŊëëĨ? ?´ė§? ëŗ???ę˛?.   
            rota();

            // x_? ?? ?´?´?¤ë¸ė ?¸ scale.x ëĨ? ?Ŗ?. scale.xę°? ???ŧ? ?? ?´?´? ėĸė°ë°ė ?ŧëĄ? ?? ??¤. ?´ëĨŧė´?Š?´? ?ŧėĒŊėŧëĄ? ë§ė´ ??? ?¤ė§ė´ė§? ëĒ¨ė?´ ???¤ę˛? ?¨.                

        }
    }


    public void GetPlayer_tp()// ? ëŠ? ęĩŦí
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Translate(transform.up * 10f, Space.World);
        }
    }//?ë¯¸ė?ėŊë
    public void Sizech(Vector3 v_)
    {
        transform.localScale = v_;
        CheckMaxSize();
        CheckMaxKnife();
    }// ?Ŧ?´ėĻ? ?¤?°ę¸? ?? ?´?´???,ęˇ¸ė? ëĒ¨ë  ?¤ë¸ė ?¸?Ŧę¸? ?¤?°ę¸?
    public void SizeUpKnife()
    {
        SeparationKnife();
        if (MyKnife.transform.localScale.x < 0) MyKnife.transform.localScale = new Vector3(MyKnife.transform.localScale.x - 0.0005f, MyKnife.transform.localScale.y + 0.005f, 1);
        else MyKnife.transform.localScale = new Vector3(MyKnife.transform.localScale.x + 0.005f, MyKnife.transform.localScale.y + 0.005f, 1);
        CombinationKnife();
        CheckMaxKnife();
    }//ėšŧíŦę¸? ?¤?°ę¸?
    public void SeparationKnife()
    {
        MyKnife.tag = "NotKnife";
        MyKnife.transform.parent = null;//ėĩë???Ŧę¸? ę˛??Ŧ ?¤??¨.,
    }//ėš? ëļëĻŦ ëĒ¸ė???? ????? ?Ŧę¸°ę???? ? ???? ?¸ ėšŧė ?Ŧę¸°ë?ŧėę¸°ė?¨. ? ????Ŧę¸°ę?? 3?´? ėģ¤ė??ëŠ? ??ŧ?.
    public void CombinationKnife()
    {
        MyKnife.transform.parent = transform;
        MyKnife.tag = "Knife";
        MyKnife.transform.localPosition = new Vector3(0f, 0.35f, 0f);
        MyKnife.transform.localRotation = Quaternion.Euler(0, 0, 90f);
    }// ėšŧė ?? ?´?´ëĄ? ?¤? ?Šė˛?
    public void CheckMaxSize()
    {
        if (transform.localScale.y > MaxSize)
        {
            float a = MaxSize, b = MaxSize;

            if (transform.localScale.x < 0) a *= -1;

            Vector3 V__ = new Vector3(a, b, 1);

            Sizech(V__);
        }
    }//ėĩë???Ŧę¸°ë?? ė˛´íŦ
    public void CheckMaxKnife()//ėšŧíŦę¸? ?´? ė˛´íŦ
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
    public void CreateBubbles()//??¤?ę˛? ë§ë¤ę¸? ęĩŦí
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


    } //ë˛ë¸ë§ë¤ę¸?
    public virtual void KillScoreUp()
    {

        //SizeUpKnife();


    }//?Ŧ?ëŠ? ?¤????¨?
    public virtual void CheckWall()
    {
        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, (Vector3.zero - transform.position).normalized, 1f, LayerMask.GetMask("Wall"));
        if (ray2.collider != null)
        {
            transform.position = ray2.point;
        }
    }//ë§ĩë°?ŧëĄ? ëĒģëę°?ę˛í??¨?
    public void CreatBarriar()//??´? ? ë°Šė´ë§? ę°?ė§?ęŗ? ??´?ę¸?. ë°Šė´ë§ë§?? ?¨?.
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
            Destroy(gameObject);
        }
    }

    public void CreateSkill() // J ?¤?Ŧ ë§ë? ?¨?
    {
        var a = Instantiate(Skill, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void CreateSkill(string Name) // J ?¤?Ŧ ë§ë? ?¨?
    {

        var a = Instantiate(Skill, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
        a.name = Name;
    }
    public void CreateSkill2() // J ?¤?Ŧ ë§ë? ?¨?
    {
        var a = Instantiate(Skill2, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void CreateSkill2(string Name) // J ?¤?Ŧ ë§ë? ?¨?
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
        Flag_ = !Flag_;
        if (FishNumber == 0)
        {
            Debug.Log("ŊēÅŗ ģįŋë");
            if (Flag_ == true)
            {
                StopMoveSpeed();
            }

            else if (Flag_ == false)
            {
                DefaultMoveSpeed();
            }
        }
        else if (FishNumber == 1) // žÆąâģķžî
        {
            SkillFlag = true;
            CreateSkill();
            OnOutLine(1);

            FastSpeed(3);
            MyBody.tag = "Shiled";
            Invoke("InitState", 3f);
            Invoke("Init_", 3f);
            Invoke("OffSkillFlag", 3f);
            Invoke("OffOutLine", 3f);
        }
        else if (FishNumber == 2)  // ē¸°Å
        {
            CreateSkill();
            for (int i = 0; i < 13 + (int)transform.localScale.y * 10; i++)
                CreateSkill2();
        }
        else if (FishNumber == 3)  //Å¸ÄÚžß
            CreateSkill2();
        else if (FishNumber == 4)   // °íˇĄ ŊÅģį
        {
            CreateSkill();
            SkillFlag = true;
            Invoke("OffSkillFlag", 3f);
        }
    }
    public void PlaySkill(string Name) //J
    {
        Flag_ = !Flag_;
        if (FishNumber == 0)
        {
            if (Flag_ == true)
            {
                StopMoveSpeed();
            }
            else if (Flag_ == false)
            {
                DefaultMoveSpeed();
            }
        }
        else if (FishNumber == 1) // žÆąâģķžî
        {
            SkillFlag = true;

            OnOutLine(1);

            FastSpeed(3);
            MyBody.tag = "Shiled";
            Invoke("InitState", 3f);
            Invoke("Init_", 3f);
            Invoke("OffSkillFlag", 3f);
            Invoke("OffOutLine", 3f);
        }
        else if (FishNumber == 2)  // ē¸°Å
        {
            CreateSkill(Name);
            for (int i = 0; i < 13 + (int)transform.localScale.y * 10; i++)
                CreateSkill2(Name);
        }
        else if (FishNumber == 3)  // Å¸ÄÚžß
            CreateSkill2(Name);
        else if (FishNumber == 4)  // °íˇĄ ŊÅģį
        {
            CreateSkill2(Name);
            SkillFlag = true;
            Invoke("OffSkillFlag", 3f);
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
}