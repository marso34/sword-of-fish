using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    public int AnimFlame = 10; // ? ? ?ค?๋ฆ? ??ธ ?? ?
    public int DieAnimFlame = 10; // ์ฃฝ์ ? ? ?ค?๋ฆฌ์?ธ ?? ?
    public GameObject Barriar;
    public ParticleSystem Skill; // J
    public GameObject Skill2; // J
    public bool isMove = false; //???์ง์??
    public enum State { Idle, Move, Die, };//???ค ์งํฉ
    public State state;// ??ฌ??
    public int PlayerCount = 8;
    public float Speed;//๋ณ??? ?ค?ผ?๋ฅ? ?ด? ๋ณ??
    public float RotationSpeed;//?? ??
    public float MovementSpeed;//๊ธฐ๋ณธ ?ค?ผ?ธ ??

    public float TempMovementSp; // J
    public float TempBusterSp; // J
    public float TempRotateSp; // J

    float MaxSize = 2f;
    public int fleshCount = 0;
    public SpriteRenderer MFish;// ?ด ๋ฌผ๊ณ ๊ธ? ?ค?จ ?? ๊ฐ์ฒด?? ์ด๊ธฐ?
    public SpriteRenderer MKnife;//?ด ์น? ?ค?จ// ???? ์ด๊ธฐ?.
    public GameObject MyKnife;
    public GameObject MyBody;
    //LOBBYPLAYER?? ์ด๊ธฐ??จ
    public int FishNumber;//0~N GameManager ?? ?? ?  ? ์ด๊ธฐ? ?ด์ค?
    public int KnifeNumber;//0~N GameManager ?? ?? ?  ? ์ด๊ธฐ? ?ด์ค?


    public GameObject Skin;// ?ค?จ ?ด๊ธ? ?ค๋ธ์ ?ธ
    public Skin skin_;//?ค?จ
    public GameObject Flesh;//?์ฒ? ์ฐธ์กฐ
    public float chsize = 0.05f;

    public float BusterSpeed;
    public bool BusterFlag;
    public GameObject Bubble;// ๋ฒ๋ธ ๊ฐ์ฒด  

    public bool StartFlag;// ๊ฒ์ ??? ?๋ฆฌ๋ ?? ๊ท?.

    public bool Life = true;//?ด? ? ?ด๋ฐ? ? ??ธ? ?ถ&์ฃฝ์ ? ?ด?๊ธฐ์?๋ณ?? ? ?? ?ด life? ?? ? ๋ชป๋ฐ๊พธ๊ธฐ?๋ฌ?. ? ? ?ฌ??๊ณ๋๋ง? ??๊ธฐ์ฝ???ฑ? 

    public int killScore;//?ฌ?ค์ฝ์ด

    public bool endFlag;//๊ฒ์ ??ด?๋ณ??

    public bool SkillFlag; // 

    public GameObject GM;// ๊ฒ์๋งค๋? ธ
    public Color C;//์บ๋ฆญ?ฐ ?ฌ๋ช๋๋ณ?๊ฒฝํ ??ธ๋ณ?? (์ฃฝ์?)
    public Sprite[] KnifeAnims;//์นผ์ ?
    public Sprite[] BodyAnims;//๋ชธ์ ?
    public SpriteRenderer S;//๋ชธํฌ๋ช๋ ๋ฐ๊??? ?ฐ?๋ณ??

    public GameObject BubbleSound;
    public Vector3 dir;//???์ง์ผ๋ฐฉํฅ
                       // Start is called before the first frame update
    public GameObject Flag_Image;
    public bool Flag_get;
    public int HP = 5;
    public bool hitFlag;
    public bool flagerror = true;
    public GameObject KillSound;
    public GameObject PlayerHitSound;
    public GameObject QM;

    //--------//ฦฉลไธฎพ๓ฟกผญ ป็ฟ๋
    public bool skillcheck = false;
    public bool TutorialLev4 = false;

    public int Timer33 = 0;
    public double Timer22 = 0;
    public float MoveTime = 3f; 
    public bool TuLev1 = false;
    public void GameStartInit()// ๊ฒ์??? ?๋ฒ์ค?
    {
        Init_();
        StartFlag = false;
        TempMovementSp = 2.3f; //J
        TempBusterSp = 4.6f;     // J
        TempRotateSp = RotationSpeed;   // J
    }
    
    public void GameWaitInit()//??ด?ฌ?จ??? ๊ธฐ๋ค๋ฆด๋
    {
        MFish = Skin.GetComponent<SpriteRenderer>();//?ค?จ? SpriteRenderer ์ฐธ์กฐ
        MKnife = MyKnife.GetComponent<SpriteRenderer>();//์นผ์ SpriteRenderer

       
    }//๏ฟฝ๏ฟฝ๏ฟฝ๏ฟฝ๏ฟฝ๏ฟฝ๏ฟ? ๏ฟฝรท๏ฟฝ๏ฟฝฬพ๏ฟฝ ๏ฟฝ๏ฟฝ ๏ฟฝ๏ฟฝ๏ฟฝฬฑ๏ฟฝ๏ฟฝ๏ฟฝ๏ฟฝ๏ฟฝ๏ฟฝ๏ฟฝ ๏ฟฝ๏ฟฝ๏ฟฝ๏ฟฝ ๏ฟฝ๏ฟฝ๏ฟฝ๏ฟฝ๏ฟฝฬฐ๏ฟฝ ๏ฟฝสฑ๏ฟฝศญ    

    public IEnumerator Start_()//?ผ๋ฐ์ ?ธ ?ค????ธ (์ฝ๋ฃจ?ด) ๋ฐ๋ณต๋ฌธ์.)
    {
        while (true) yield return StartCoroutine(state.ToString());//์ฝ๋ฃจ?ด ?ค? ๋งคํ? ?๋ง๋ค. ์ฝ๋ฃจ?ด ?ธ?ฐ?ท ๊ฒ???ด? ??๋ณด๊ธฐ
    }
    public void Init_()//์ด๊ธฐ?
    {
        MyKnife.tag = "Knife";
        MyBody.tag = "Body";
    }
    public void InitState() //J ์ด๊ธฐ?
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

    }//not?ผ๋ก? ์ด๊ธฐ?
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
    public virtual void DieLife()// ์ฃฝ์??,??๊ธฐ๋ณธ??๋ก?,?๊ท? ์ฃฝ์?ผ๋ก?, ?ผ?ด? ์ฃฝ์?ผ๋ก?, ์ปฌ๋ฌ๋ฆฌ์,?์ฒด์?ฑ,2์ด๋ค๋ถ??
    {
        if (transform.tag == "Player")
        {
            //๊น๋นก?.์ฝ๋
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
                Invoke("Respone", 2f);//?ผ?จ???๋ฆฌ์ค?ฐ?ผ๋ก? ???ฐ ๋ฐ๊??????
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
    public void CreateFlesh()//?์ฒด์?ฑ
    {

        for (int i = 0; i < 3 + transform.localScale.y; ++i)
        {
            var flesh_ = Instantiate(Flesh, transform.position + RandomFleshPosition(), Quaternion.Euler(0, 0, 0));

        }


    }//?์ฒ? ๋ง๋ค๊ธ?

    public Vector3 RandomFleshPosition() //??ค? ?์ฒด์์น๋ฐฑ?ฐ ๋ฐํ
    {
        return new Vector3(Random.Range(-1.2f, 1.2f), Random.Range(-1.2f, 1.2f), 0);
    }

    public Vector3 RandomPosition(bool AiFlag) //??ค? ?์น๋ฐฑ?ฐ ๋ฐํ
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
    public void Respone()//๋ถ??๊ณผ์ 
    {
        if (transform.tag == "AiPlayer")
        {
            ResetColor();
            Vector3 postion_ = RandomPosition(jugeAi());

            transform.Translate(postion_, Space.World);//??ค??์น์ ??ฑ    
            Life = true;

            SetRandomBody();
            SetRandomKnife();
            //sizeInit();
            
      
        }


    }

    public void SetRandomBody()//?๋ก์ด ๋ฐ๋ ?ค?จ?ป?ด?ค๊ธ?
    {
        if (transform.tag == "AiPlayer")
        {
            int R = Random.Range(5, 6);// ๋ชธ์ค?จ๊ฐ??5
            FishNumber = R;
        }

    }

    public void SetRandomKnife()// ?๋ก์ด ์น? ?ค?จ?ป?ด?ค๊ธ?
    {
        int R = Random.Range(1, 6);//์นผ์ค?จ๊ฐ??6
        KnifeNumber = R;

    }

    public void InitKnife()// ๋ฌผ๊ณ ๊ธ? ?? ๊ทธ๋?ผ๊ธฐ๋ฐ์ผ๋ก? ?ค?จ? ์ด๊ธฐ?
    {
        KnifeAnims = new Sprite[10];
        if (KnifeNumber == 0) KnifeAnims = skin_.BasicKnife;
        else if (KnifeNumber == 1) KnifeAnims = skin_.SpearKnife;
        else if (KnifeNumber == 2) KnifeAnims = skin_.PanKnife_R;
        else if (KnifeNumber == 3) KnifeAnims = skin_.Rager_R;
        else if (KnifeNumber == 4) KnifeAnims = skin_.XKnife;
        else if(KnifeNumber == 5) KnifeAnims = skin_.CandyKnife;
    }

    public void InitBody()//์น? ?? ๊ท? ๊ธฐ๋ฐ?ผ๋ก? ?ค?จ? ์ด๊ธฐ?
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
    public void ResetColor()//?ฌ๋ช๋ 0?ผ๋ก? ์ฆ? ?ฌ๋ชํ์ง??๊ฒ?
    {
        C.a = 1f;
        S.color = C;
        MKnife.color = C;
    }

    public void translucence() // J ๋ฐํฌ๋ชํ๊ฒ?
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
    public void sizeInit()//๊ธฐ๋ณธ?ฌ?ด์ฆ๋ก ๋ฐ๊พธ๊ธ?
    {
        Sizech(transform.localScale / transform.localScale.y);
    }

    public void KnifeInit()//๊ธฐ๋ณธ?ฌ?ด์ฆ๋ก ๋ฐ๊พธ๊ธ?
    {
        MyKnife.transform.parent = null;//์ต๋???ฌ๊ธ? ๊ฒ??ฌ ?ค??จ.,
        if (MyKnife.transform.localScale.x < 0) MyKnife.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        else MyKnife.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        MyKnife.transform.parent = transform;
    }

    public void AnimState(Vector3 dir)//๋ช? ? ?๋ฉ์ด? ? ?ฉ, ์นผ์ ?๋งค์ด? ? ?ฉ, ?ฌ? ? ?ฉ?ด?ผ???ฐ ?์ง? ๋ชป๊ตฌ?
    {
        if (Life)
        {
            if (isMove)
            {
                
                if (!hitFlag)
                    state = State.Move;
                float x_ = transform.localScale.x;// x_? ?? ?ด?ด?ค๋ธ์ ?ธ scale.x ๋ฅ? ?ฃ?. scale.x๊ฐ? ???ผ? ?? ?ด?ด? ์ข์ฐ๋ฐ์ ?ผ๋ก? ?? ??ค. ?ด๋ฅผ์ด?ฉ?ด? ?ผ์ชฝ์ผ๋ก? ๋ง์ด ??? ?ค์ง์ด์ง? ๋ชจ์?ด ???ค๊ฒ? ?จ.
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
    }// ์กฐ๊ฑด? ?ฐ?ผ ? ?๋ฉ์ด? ?? ? ?๊ธ?.
    IEnumerator Idle()//๋ฉ์ถค? ?0.2์ด๋ง?ค shoAnim?จ? ?ค?
    {
        ResetColor();
        ShowBodyAnim(0);
        ShowKnifeAnim(0);
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator Move()//???์ง์? ?๋งค์ด??ฌ?
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
                CreateBubbles();//๋ฒ๋ธ??ฑ

                yield return new WaitForSeconds(0.2f / Speed);

            }
        }
    }
    IEnumerator Die() //์ฃฝ์ ? ?
    {
        for (int i = 0; i < 50; ++i)
        {
            //if (Life) break;
            ShowDieAnim(i);

            yield return new WaitForSeconds(0.01f);
        }
    }
    public void ShowDieAnim(int index)//์ฃฝ์?? ? ?๋งค์ด? ?ฌ??จ?
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

    public void ShowBodyAnim(int index)//?ด???? ? ?๋งค์ด? ?ฌ??จ?
    {
        InitBody();
        for (int i = 0; i < AnimFlame; i++)
        {
            if (!Life || state == State.Die) break;
            if (i == index)
                MFish.sprite = BodyAnims[i];
        }
    }
    public void ShowKnifeAnim(int index)//?ด???? ? ?๋งค์ด? ?ฌ??จ?
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
            transform.Translate(dir * Speed * Time.deltaTime, Space.World);// ?ค๋ธ์ ?ธ ?ด??จ? https://www.youtube.com/watch?v=2pf1FE-Xcc8 ???จ ์ฝ๋๋ฅ? ?ด์ง? ๋ณ???๊ฒ?.   

            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);//?ด?๋ฐฉํฅ? ๋ง๊ฒ ? ๋ฉด์ ๋ณด๋๋ก? ?? ๊ฐ? ๋ฐ์?ค๊ธ?.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed);//?? ?ด?ด?ค๋ธ์ ?ธ?๊ฒ? ๋ฐ์?จ ?? ๊ฐ? ? ?ฉ
            float x_ = transform.localScale.x;// x_? ?? ?ด?ด?ค๋ธ์ ?ธ scale.x ๋ฅ? ?ฃ?. scale.x๊ฐ? ???ผ? ?? ?ด?ด? ์ข์ฐ๋ฐ์ ?ผ๋ก? ?? ??ค. ?ด๋ฅผ์ด?ฉ?ด? ?ผ์ชฝ์ผ๋ก? ๋ง์ด ??? ?ค์ง์ด์ง? ๋ชจ์?ด ???ค๊ฒ? ?จ.                

        }
    }//?? ?ด?ด ???์ง์ด๊ฒํ๊ธ?
    public void chSpeed()// ๋ฌผ๊ณ ๊ธ? ?ด??? ๋ฉ??ฐ?? ?๊ธฐํ.
    {
        Speed = BusterSpeed;
    }
    public void reSpeed()// ๋ฌผ๊ณ ๊ธ? ?ด??? ๋ฉ??ฐ?? ?๊ธฐํ
    {
        Speed = MovementSpeed;
    }
    public void GetPlayer_tp()// ? ๋ฉ? ๊ตฌํ
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Translate(transform.up * 10f, Space.World);
        }
    }//?๋ฏธ์?์ฝ๋
    public void Sizech(Vector3 v_)
    {
        transform.localScale = v_;
        CheckMaxSize();
        CheckMaxKnife();
    }// ?ฌ?ด์ฆ? ?ค?ฐ๊ธ? ?? ?ด?ด???,๊ทธ์? ๋ชจ๋  ?ค๋ธ์ ?ธ?ฌ๊ธ? ?ค?ฐ๊ธ?
    public void SizeUpKnife()
    {
        SeparationKnife();
        if (MyKnife.transform.localScale.x < 0) MyKnife.transform.localScale = new Vector3(MyKnife.transform.localScale.x - 0.0005f, MyKnife.transform.localScale.y + 0.005f, 1);
        else MyKnife.transform.localScale = new Vector3(MyKnife.transform.localScale.x + 0.005f, MyKnife.transform.localScale.y + 0.005f, 1);
        CombinationKnife();
        CheckMaxKnife();
    }//์นผํฌ๊ธ? ?ค?ฐ๊ธ?
    public void SeparationKnife()
    {
        MyKnife.tag = "NotKnife";
        MyKnife.transform.parent = null;//์ต๋???ฌ๊ธ? ๊ฒ??ฌ ?ค??จ.,
    }//์น? ๋ถ๋ฆฌ ๋ชธ์???? ????? ?ฌ๊ธฐ๊???? ? ???? ?ธ ์นผ์ ?ฌ๊ธฐ๋?ผ์๊ธฐ์?จ. ? ????ฌ๊ธฐ๊?? 3?ด? ์ปค์??๋ฉ? ??ผ?.
    public void CombinationKnife()
    {
        MyKnife.transform.parent = transform;
        MyKnife.tag = "Knife";
        MyKnife.transform.localPosition = new Vector3(0f, 0.35f, 0f);
        MyKnife.transform.localRotation = Quaternion.Euler(0, 0, 90f);
    }// ์นผ์ ?? ?ด?ด๋ก? ?ค? ?ฉ์ฒ?
    public void CheckMaxSize()
    {
        if (transform.localScale.y > MaxSize)
        {
            float a = MaxSize, b = MaxSize;

            if (transform.localScale.x < 0) a *= -1;

            Vector3 V__ = new Vector3(a, b, 1);

            Sizech(V__);
        }
    }//์ต๋???ฌ๊ธฐ๋?? ์ฒดํฌ
    public void CheckMaxKnife()//์นผํฌ๊ธ? ?ด? ์ฒดํฌ
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
    public void CreateBubbles()//??ค?๊ฒ? ๋ง๋ค๊ธ? ๊ตฌํ
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


    } //๋ฒ๋ธ๋ง๋ค๊ธ?
    public virtual void KillScoreUp()
    {
     
        //SizeUpKnife();


    }//?ฌ?๋ฉ? ?ค????จ?
    public virtual void CheckWall()
    {
        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, (Vector3.zero - transform.position).normalized, 1000f, LayerMask.GetMask("Wall"));
        if (ray2.collider != null)
        {
            transform.position = ray2.point;
        }
    }//๋งต๋ฐ?ผ๋ก? ๋ชป๋๊ฐ?๊ฒํ??จ?
    public void CreatBarriar()//??ด? ? ๋ฐฉ์ด๋ง? ๊ฐ?์ง?๊ณ? ??ด?๊ธ?. ๋ฐฉ์ด๋ง๋ง?? ?จ?.
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

    public void CreateSkill() // J ?ค?ฌ ๋ง๋? ?จ?
    {
        var a = Instantiate(Skill, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void CreateSkill(string Name) // J ?ค?ฌ ๋ง๋? ?จ?
    {

        var a = Instantiate(Skill, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
        a.name = Name;
    }
    public void CreateSkill2() // J ?ค?ฌ ๋ง๋? ?จ?
    {
        var a = Instantiate(Skill2, transform.position, Quaternion.Euler(0, 0, 0));
        a.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void CreateSkill2(string Name) // J ?ค?ฌ ๋ง๋? ?จ?
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
        else if (FishNumber == 1)
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
        else if (FishNumber == 2)  // ๋ณด๊ฑฐ
        {
            CreateSkill();
            for (int i = 0; i < 13 + (int)transform.localScale.y * 10; i++)
                CreateSkill2();
        }
        else if (FishNumber == 3)  // ???์ฝ์ผ
            CreateSkill2();
        else  // ๊ณ ๋? ?ฌ
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
        else if (FishNumber == 1)
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
        else if (FishNumber == 2)  // ๋ณด๊ฑฐ
        {
            CreateSkill(Name);
            for (int i = 0; i < 13 + (int)transform.localScale.y * 10; i++)
                CreateSkill2(Name);
        }
        else if (FishNumber == 3)  // ???์ฝ์ผ
            CreateSkill2(Name);
        else  // ๊ณ ๋? ?ฌ
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
    {// ?ค??? ๋จน์
        reSpeed();
        // InitState(); -> ?? ์ด๊ธฐ?? ?ฌ?จ, ??ด ?ค?ฌ ?ธ ?? ?? ??๋ก? ??๊ฐ?..
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