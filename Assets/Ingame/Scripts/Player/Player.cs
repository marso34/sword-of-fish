using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    public int AnimFlame = 10; // ? ? ?€?λ¦? ??Έ ?? ?
    public int DieAnimFlame = 10; // μ£½μ ? ? ?€?λ¦¬μ?Έ ?? ?
    public GameObject Barriar;
    public ParticleSystem Skill; // J
    public GameObject Skill2; // J
    public bool isMove = false; //???μ§μ??
    public enum State { Idle, Move, Die, };//???€ μ§ν©
    public State state;// ??¬??
    public int PlayerCount = 8;
    public float Speed;//λ³??? ?€?Ό?λ₯? ?΄? λ³??
    public float RotationSpeed;//?? ??
    public float MovementSpeed;//κΈ°λ³Έ ?€?Ό?Έ ??

    public float TempMovementSp; // J
    public float TempBusterSp; // J
    public float TempRotateSp; // J

    float MaxSize = 2f;
    public int fleshCount = 0;
    public SpriteRenderer MFish;// ?΄ λ¬Όκ³ κΈ? ?€?¨ ?? κ°μ²΄?? μ΄κΈ°?
    public SpriteRenderer MKnife;//?΄ μΉ? ?€?¨// ???? μ΄κΈ°?.
    public GameObject MyKnife;
    public GameObject MyBody;
    //LOBBYPLAYER?? μ΄κΈ°??¨
    public int FishNumber;//0~N GameManager ?? ?? ?  ? μ΄κΈ°? ?΄μ€?
    public int KnifeNumber;//0~N GameManager ?? ?? ?  ? μ΄κΈ°? ?΄μ€?


    public GameObject Skin;// ?€?¨ ?΄κΈ? ?€λΈμ ?Έ
    public Skin skin_;//?€?¨
    public GameObject Flesh;//?μ²? μ°Έμ‘°
    public float chsize = 0.05f;

    public float BusterSpeed;
    public bool BusterFlag;
    public GameObject Bubble;// λ²λΈ κ°μ²΄  

    public bool StartFlag;// κ²μ ??? ?λ¦¬λ ?? κ·?.

    public bool Life = true;//?΄? ? ?΄λ°? ? ??Έ? ?Ά&μ£½μ ? ?΄?κΈ°μ?λ³?? ? ?? ?΄ life? ?? ? λͺ»λ°κΎΈκΈ°?λ¬?. ? ? ?¬??κ³λλ§? ??κΈ°μ½???±? 

    public int killScore;//?¬?€μ½μ΄

    public bool endFlag;//κ²μ ??΄?λ³??

    public bool SkillFlag; // 

    public GameObject GM;// κ²μλ§€λ? Έ
    public Color C;//μΊλ¦­?° ?¬λͺλλ³?κ²½ν ??Έλ³?? (μ£½μ?)
    public Sprite[] KnifeAnims;//μΉΌμ ?
    public Sprite[] BodyAnims;//λͺΈμ ?
    public SpriteRenderer S;//λͺΈν¬λͺλ λ°κ??? ?°?λ³??

    public GameObject BubbleSound;
    public Vector3 dir;//???μ§μΌλ°©ν₯
                       // Start is called before the first frame update
    public GameObject Flag_Image;
    public bool Flag_get;
    public int HP = 5;
    public bool hitFlag;
    public bool flagerror = true;
    public GameObject KillSound;
    public GameObject PlayerHitSound;
    public GameObject QM;

    //--------?? λ¦¬μΌ
    public bool skillcheck = false;
    public bool TutorialLev4 = false;

    public int Timer33 = 0;
    public double Timer22 = 0;
    public float MoveTime = 3f;
    public bool TuLev1 = false;
    public void GameStartInit()// κ²μ??? ?λ²μ€?
    {
        Init_();
        StartFlag = false;
        TempMovementSp = 2.3f; //J
        TempBusterSp = 4.6f;     // J
        TempRotateSp = RotationSpeed;   // J
    }
    
    public void GameWaitInit()//??΄?¬?¨??? κΈ°λ€λ¦΄λ
    {
        MFish = Skin.GetComponent<SpriteRenderer>();//?€?¨? SpriteRenderer μ°Έμ‘°
        MKnife = MyKnife.GetComponent<SpriteRenderer>();//μΉΌμ SpriteRenderer

       
    }//οΏ½οΏ½οΏ½οΏ½οΏ½οΏ½οΏ? οΏ½Γ·οΏ½οΏ½ΜΎοΏ½ οΏ½οΏ½ οΏ½οΏ½οΏ½Μ±οΏ½οΏ½οΏ½οΏ½οΏ½οΏ½οΏ½ οΏ½οΏ½οΏ½οΏ½ οΏ½οΏ½οΏ½οΏ½οΏ½Μ°οΏ½ οΏ½Κ±οΏ½Θ­    

    public IEnumerator Start_()//?Όλ°μ ?Έ ?€????Έ (μ½λ£¨?΄) λ°λ³΅λ¬Έμ.)
    {
        while (true) yield return StartCoroutine(state.ToString());//μ½λ£¨?΄ ?€? λ§€ν? ?λ§λ€. μ½λ£¨?΄ ?Έ?°?· κ²???΄? ??λ³΄κΈ°
    }
    public void Init_()//μ΄κΈ°?
    {
        MyKnife.tag = "Knife";
        MyBody.tag = "Body";
    }
    public void InitState() //J μ΄κΈ°?
    {
        C = Color.white;

        Speed = TempMovementSp+transform.localScale.y/2;
        MovementSpeed = TempMovementSp+transform.localScale.y/2;
        BusterSpeed = TempBusterSp+transform.localScale.y/2;
        RotationSpeed = TempRotateSp;
    }
    public void OffTrashEffect()
    {
        MovementSpeed = TempMovementSp+transform.localScale.y/2;
        BusterSpeed = TempBusterSp+transform.localScale.y/2;
        RotationSpeed = TempRotateSp+transform.localScale.y/2;
        C = Color.white;
    }
    public void Eraser_()
    {
        Destroy(gameObject, 0.1f);
    }
    public void Shiled()
    {
        MyBody.tag = "Shiled";
    }
    public void NotInit()
    {
        MyKnife.tag = "NotKnife";
        MyBody.tag = "NotBody";

    }//not?Όλ‘? μ΄κΈ°?
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
    public virtual void DieLife()// μ£½μ??,??κΈ°λ³Έ??λ‘?,?κ·? μ£½μ?Όλ‘?, ?Ό?΄? μ£½μ?Όλ‘?, μ»¬λ¬λ¦¬μ,?μ²΄μ?±,2μ΄λ€λΆ??
    {
        if (transform.tag == "Player")
        {
            //κΉλΉ‘?.μ½λ
            ShowDieAnim(0);
            state = State.Die;

            if (HP > 0)
            {
                var Sound1 = Instantiate(PlayerHitSound, transform.localPosition, Quaternion.Euler(0f, 0f, 0f));
                HP--;
                MyBody.tag = "NotBody";
                hitFlag = true;
                translucence();
                OnOutLine(14);
                Invoke("OffOutLine", 0.07f);
                Invoke("ResetColor", 0.2f);
                Invoke("translucence", 0.3f);
                Invoke("ResetColor", 0.4f);
                Invoke("translucence", 0.5f);
                Invoke("InitBody__", 1.5f);

            }
            else if (HP <= 0 && flagerror)
            {
                CreateFlesh();
                NotInit();
                Invoke("LifeOff", 0.015f);
                flagerror = false;
            }

        }

        if (transform.tag == "AiPlayer")
        {

            OnOutLine(14);
            Invoke("OffOutLine", 0.07f);
            state = State.Die;
            LifeOff();

            QM = GameObject.FindGameObjectWithTag("QM");
            QM.GetComponent<QuestManager>().KnifeEC--;
            if (SkillFlag)
                OffSkillFlag(); // J
            InitState(); // J
            NotInit();

            //reSpeed();

            CreateFlesh();
            Destroy(gameObject, 2f);
            /*if (transform.tag == "AiPlayer")
                Invoke("Respone", 2f);//?Ό?¨???λ¦¬μ€?°?Όλ‘? ???° λ°κ??????
            else if(transform.tag =="Player") MyKnife.tag = "NotKnife";
            */
        }
        if (transform.tag == "InkOct")
        {
            if (GameObject.FindWithTag("Kraken") != null)
                GameObject.FindWithTag("Kraken").GetComponent<Kraken>().CreateInkSwarm(transform.position, 0.4f);
            Destroy(gameObject);
        }

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
    public void CreateFlesh()//?μ²΄μ?±
    {

        for (int i = 0; i < 3 + transform.localScale.y; ++i)
        {
            var flesh_ = Instantiate(Flesh, transform.position + RandomFleshPosition(), Quaternion.Euler(0, 0, 0));

        }


    }//?μ²? λ§λ€κΈ?

    public Vector3 RandomFleshPosition() //??€? ?μ²΄μμΉλ°±?° λ°ν
    {
        return new Vector3(Random.Range(-1.2f, 1.2f), Random.Range(-1.2f, 1.2f), 0);
    }

    public Vector3 RandomPosition(bool AiFlag) //??€? ?μΉλ°±?° λ°ν
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
    public void Respone()//λΆ??κ³Όμ 
    {
        if (transform.tag == "AiPlayer")
        {
            ResetColor();
            Vector3 postion_ = RandomPosition(jugeAi());

            transform.Translate(postion_, Space.World);//??€??μΉμ ??±    
            Life = true;

            SetRandomBody();
            SetRandomKnife();
            //sizeInit();
            
      
        }


    }

    public void SetRandomBody()//?λ‘μ΄ λ°λ ?€?¨?»?΄?€κΈ?
    {
        if (transform.tag == "AiPlayer")
        {
            int R = Random.Range(5, 6);// λͺΈμ€?¨κ°??5
            FishNumber = R;
        }

    }

    public void SetRandomKnife()// ?λ‘μ΄ μΉ? ?€?¨?»?΄?€κΈ?
    {
        int R = Random.Range(1, 6);//μΉΌμ€?¨κ°??6
        KnifeNumber = R;

    }

    public void InitKnife()// λ¬Όκ³ κΈ? ?? κ·Έλ?ΌκΈ°λ°μΌλ‘? ?€?¨? μ΄κΈ°?
    {
        KnifeAnims = new Sprite[10];
        if (KnifeNumber == 0) KnifeAnims = skin_.BasicKnife;
        else if (KnifeNumber == 1) KnifeAnims = skin_.SpearKnife;
        else if (KnifeNumber == 2) KnifeAnims = skin_.PanKnife_R;
        else if (KnifeNumber == 3) KnifeAnims = skin_.Rager_R;
        else if (KnifeNumber == 4) KnifeAnims = skin_.XKnife;
        else if(KnifeNumber == 5) KnifeAnims = skin_.CandyKnife;
    }

    public void InitBody()//μΉ? ?? κ·? κΈ°λ°?Όλ‘? ?€?¨? μ΄κΈ°?
    {

        BodyAnims = new Sprite[10];
        if (FishNumber == 0) BodyAnims = skin_.FirstTailAnims;
        else if (FishNumber == 1) BodyAnims = skin_.SharkTailAnims;
        else if (FishNumber == 2) BodyAnims = skin_.BlowfishTailAnims;
        else if (FishNumber == 3) BodyAnims = skin_.OctopusTailAnims;
        else if (FishNumber == 4) BodyAnims = skin_.WaileTailAnims_R;
        else if (FishNumber == 5) BodyAnims = skin_.BornAnims_E;
        else if(FishNumber == 6) BodyAnims = skin_.Gabock_E;
        else if(FishNumber == 7) BodyAnims = skin_.InkOctAnims_E;
        
        
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
    public void ResetColor()//?¬λͺλ 0?Όλ‘? μ¦? ?¬λͺνμ§??κ²?
    {
        C.a = 1f;
        S.color = C;
        MKnife.color = C;
    }

    public void translucence() // J λ°ν¬λͺνκ²?
    {
        C.a = 0.5f;
        S.color = C;
        MKnife.color = C;
    }
    void SpeedInit()
    {
        MovementSpeed = TempMovementSp+transform.localScale.y/2;
        BusterSpeed = TempBusterSp+transform.localScale.y/2;
        RotationSpeed = TempRotateSp+transform.localScale.y/2;
        Speed = MovementSpeed;
    }
    public void sizeInit()//κΈ°λ³Έ?¬?΄μ¦λ‘ λ°κΎΈκΈ?
    {
        Sizech(transform.localScale / transform.localScale.y);
    }

    public void KnifeInit()//κΈ°λ³Έ?¬?΄μ¦λ‘ λ°κΎΈκΈ?
    {
        MyKnife.transform.parent = null;//μ΅λ???¬κΈ? κ²??¬ ?€??¨.,
        if (MyKnife.transform.localScale.x < 0) MyKnife.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        else MyKnife.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        MyKnife.transform.parent = transform;
    }

    public void AnimState(Vector3 dir)//λͺ? ? ?λ©μ΄? ? ?©, μΉΌμ ?λ§€μ΄? ? ?©, ?¬? ? ?©?΄?Ό???° ?μ§? λͺ»κ΅¬?
    {
        if (Life)
        {
            if (isMove)
            {
                
                if (!hitFlag)
                    state = State.Move;
                float x_ = transform.localScale.x;// x_? ?? ?΄?΄?€λΈμ ?Έ scale.x λ₯? ?£?. scale.xκ°? ???Ό? ?? ?΄?΄? μ’μ°λ°μ ?Όλ‘? ?? ??€. ?΄λ₯Όμ΄?©?΄? ?Όμͺ½μΌλ‘? λ§μ΄ ??? ?€μ§μ΄μ§? λͺ¨μ?΄ ???€κ²? ?¨.
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
    }// μ‘°κ±΄? ?°?Ό ? ?λ©μ΄? ?? ? ?κΈ?.
    IEnumerator Idle()//λ©μΆ€? ?0.2μ΄λ§?€ shoAnim?¨? ?€?
    {
        ResetColor();
        ShowBodyAnim(0);
        ShowKnifeAnim(0);
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator Move()//???μ§μ? ?λ§€μ΄??¬?
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
                CreateBubbles();//λ²λΈ??±

                yield return new WaitForSeconds(0.2f / Speed);

            }
        }
    }
    IEnumerator Die() //μ£½μ ? ?
    {
        for (int i = 0; i < 50; ++i)
        {
            //if (Life) break;
            ShowDieAnim(i);

            yield return new WaitForSeconds(0.01f);
        }
    }
    public void ShowDieAnim(int index)//μ£½μ?? ? ?λ§€μ΄? ?¬??¨?
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

    public void ShowBodyAnim(int index)//?΄???? ? ?λ§€μ΄? ?¬??¨?
    {
        InitBody();
        for (int i = 0; i < AnimFlame; i++)
        {
            if (!Life || state == State.Die) break;
            if (i == index)
                MFish.sprite = BodyAnims[i];
        }
    }
    public void ShowKnifeAnim(int index)//?΄???? ? ?λ§€μ΄? ?¬??¨?
    {
        InitKnife();
        for (int i = 0; i < AnimFlame; i++)
        {
            if (i == index)
                MKnife.sprite = KnifeAnims[i];
        }

    }

    public void PlayerMove()
    {
        isMove = true; //dir != Vector3.zero;
        if (isMove && Life)
        {
                if(isMove) 
                {
                    Timer22 += Time.deltaTime;
                    if (Timer22 > MoveTime)
                    {
                        Timer22 = 0;
                        Timer33 ++;
                        
                    }


                }
            transform.Translate(dir * Speed * Time.deltaTime, Space.World);// ?€λΈμ ?Έ ?΄??¨? https://www.youtube.com/watch?v=2pf1FE-Xcc8 ???¨ μ½λλ₯? ?΄μ§? λ³???κ²?.   

            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);//?΄?λ°©ν₯? λ§κ² ? λ©΄μ λ³΄λλ‘? ?? κ°? λ°μ?€κΈ?.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);//?? ?΄?΄?€λΈμ ?Έ?κ²? λ°μ?¨ ?? κ°? ? ?©
            float x_ = transform.localScale.x;// x_? ?? ?΄?΄?€λΈμ ?Έ scale.x λ₯? ?£?. scale.xκ°? ???Ό? ?? ?΄?΄? μ’μ°λ°μ ?Όλ‘? ?? ??€. ?΄λ₯Όμ΄?©?΄? ?Όμͺ½μΌλ‘? λ§μ΄ ??? ?€μ§μ΄μ§? λͺ¨μ?΄ ???€κ²? ?¨.                

        }
    }//?? ?΄?΄ ???μ§μ΄κ²νκΈ?
    public void chSpeed()// λ¬Όκ³ κΈ? ?΄??? λ©??°?? ?κΈ°ν.
    {
        Speed = BusterSpeed;
    }
    public void reSpeed()// λ¬Όκ³ κΈ? ?΄??? λ©??°?? ?κΈ°ν
    {
        Speed = MovementSpeed;
    }
    public void GetPlayer_tp()// ? λ©? κ΅¬ν
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Translate(transform.up * 10f, Space.World);
        }
    }//?λ―Έμ?μ½λ
    public void Sizech(Vector3 v_)
    {
        transform.localScale = v_;
        CheckMaxSize();
        CheckMaxKnife();
    }// ?¬?΄μ¦? ?€?°κΈ? ?? ?΄?΄???,κ·Έμ? λͺ¨λ  ?€λΈμ ?Έ?¬κΈ? ?€?°κΈ?
    public void SizeUpKnife()
    {
        SeparationKnife();
        if (MyKnife.transform.localScale.x < 0) MyKnife.transform.localScale = new Vector3(MyKnife.transform.localScale.x - 0.0005f, MyKnife.transform.localScale.y + 0.005f, 1);
        else MyKnife.transform.localScale = new Vector3(MyKnife.transform.localScale.x + 0.005f, MyKnife.transform.localScale.y + 0.005f, 1);
        CombinationKnife();
        CheckMaxKnife();
    }//μΉΌν¬κΈ? ?€?°κΈ?
    public void SeparationKnife()
    {
        MyKnife.tag = "NotKnife";
        MyKnife.transform.parent = null;//μ΅λ???¬κΈ? κ²??¬ ?€??¨.,
    }//μΉ? λΆλ¦¬ λͺΈμ???? ????? ?¬κΈ°κ???? ? ???? ?Έ μΉΌμ ?¬κΈ°λ?ΌμκΈ°μ?¨. ? ????¬κΈ°κ?? 3?΄? μ»€μ??λ©? ??Ό?.
    public void CombinationKnife()
    {
        MyKnife.transform.parent = transform;
        MyKnife.tag = "Knife";
        MyKnife.transform.localPosition = new Vector3(0f, 0.35f, 0f);
        MyKnife.transform.localRotation = Quaternion.Euler(0, 0, 90f);
    }// μΉΌμ ?? ?΄?΄λ‘? ?€? ?©μ²?
    public void CheckMaxSize()
    {
        if (transform.localScale.y > MaxSize)
        {
            float a = MaxSize, b = MaxSize;

            if (transform.localScale.x < 0) a *= -1;

            Vector3 V__ = new Vector3(a, b, 1);

            Sizech(V__);
        }
    }//μ΅λ???¬κΈ°λ?? μ²΄ν¬
    public void CheckMaxKnife()//μΉΌν¬κΈ? ?΄? μ²΄ν¬
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
    public void CreateBubbles()//??€?κ²? λ§λ€κΈ? κ΅¬ν
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


    } //λ²λΈλ§λ€κΈ?
    public virtual void KillScoreUp()
    {
     
        //SizeUpKnife();


    }//?¬?λ©? ?€????¨?
    public virtual void CheckWall()
    {
        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, (Vector3.zero - transform.position).normalized, 1000f, LayerMask.GetMask("Wall"));
        if (ray2.collider != null)
        {
            transform.position = ray2.point;
        }
    }//λ§΅λ°?Όλ‘? λͺ»λκ°?κ²ν??¨?
    public void CreatBarriar()//??΄? ? λ°©μ΄λ§? κ°?μ§?κ³? ??΄?κΈ?. λ°©μ΄λ§λ§?? ?¨?.
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

    public void CreateSkill() // J ?€?¬ λ§λ? ?¨?
    {
        var a = Instantiate(Skill, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void CreateSkill(string Name) // J ?€?¬ λ§λ? ?¨?
    {

        var a = Instantiate(Skill, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
        a.name = Name;
    }
    public void CreateSkill2() // J ?€?¬ λ§λ? ?¨?
    {
        var a = Instantiate(Skill2, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void CreateSkill2(string Name) // J ?€?¬ λ§λ? ?¨?
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
        if (FishNumber == 0)
        {
        }
        else if (FishNumber == 1) // ΎΖ±β»σΎξ
        {
            SkillFlag = true;
            CreateSkill();
            OnOutLine(1);

            MovementSpeed = 15f;
            BusterSpeed = 15f;
            MyBody.tag = "Shiled";
            Invoke("InitState", 3f);
            Invoke("Init_", 3f);
            Invoke("OffSkillFlag", 3f);
            Invoke("OffOutLine", 3f);
        }
        else if (FishNumber == 2)  // ΊΈ°Ε
        {
            CreateSkill();
            for (int i = 0; i < 13 + (int)transform.localScale.y * 10; i++)
                CreateSkill2();
        }
        else if (FishNumber == 3)  //ΕΈΔΪΎί
            CreateSkill2();
        else if (FishNumber == 4)   // °ν·‘ ½Ε»η
        {
            CreateSkill();
            SkillFlag = true;
            Invoke("OffSkillFlag", 3f);
        }
    }
    public void PlaySkill(string Name) //J
    {

        if (FishNumber == 0)
        {
        }
        else if (FishNumber == 1) // ΎΖ±β»σΎξ
        {
            SkillFlag = true;

            OnOutLine(1);

            MovementSpeed = 15f;
            BusterSpeed = 15f;
            MyBody.tag = "Shiled";
            Invoke("InitState", 3f);
            Invoke("Init_", 3f);
            Invoke("OffSkillFlag", 3f);
            Invoke("OffOutLine", 3f);
        }
        else if (FishNumber == 2)  // ΊΈ°Ε
        {
            CreateSkill(Name);
            for (int i = 0; i < 13 + (int)transform.localScale.y * 10; i++)
                CreateSkill2(Name);
        }
        else if (FishNumber == 3)  // ΕΈΔΪΎί
            CreateSkill2(Name);
        else if (FishNumber == 4)  // °ν·‘ ½Ε»η
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
    public void EatStar()
    {
        reSpeed();
        // InitState(); -> ?? μ΄κΈ°?? ?¬?¨, ??΄ ?€?¬ ?Έ ?? ?? ??λ‘? ??κ°?..
        C = Color.white;
        OnStar();
        Invoke("OffStar", 3f);
    }
    public void OnStar()
    {
        MyBody.tag = "Shiled";
        Skin.GetComponent<Skin>().Flag = true;
        OnOutLine(1);
    }
    public void OffStar()
    {
        MyBody.tag = "Body";
        Skin.GetComponent<Skin>().Flag = false;
        OffOutLine();
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
    public void ChangeSpeed(float move_, float bust_, float rotate_)
    {
        MovementSpeed = move_;
        BusterSpeed = bust_;
        RotationSpeed = rotate_;
    }
    public void DefultSpeed()
    {
        MovementSpeed = 2.8f;
        BusterSpeed = 5.5f;
        RotationSpeed = 650f;
    }
}