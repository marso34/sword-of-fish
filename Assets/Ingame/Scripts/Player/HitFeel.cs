using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeel : MonoBehaviour
{
    //https://www.youtube.com/watch?v=ChOtkGLIGyU 이영상 응용 버전 코드임. 시간을 멈추거나 느리게만드는 대신 유닛의 회전속도랑, 이동속도를 제로에 가깝게 찰나의 시간동안 줄임. 
    bool stopping; //TimeStop 키는 함수.
    public float stopTime;
    public GameObject Player_;
    float TempBusterSp;
    float TempMoveSp;
    float TempRotateSp;
    float TempSpeed;
    //Temp는 기존에 있던속도 담아둔 변수.
    public Transform cam;
    Vector3 camPosition_original;
    public float shake;
    public float FishWeight;//
    public bool SlowFlag_;

    private void Start()
    {
        shake = 2f;
        cam = GameObject.FindWithTag("MainCamera").transform;
        camPosition_original = cam.position;
        stopTime = 0.2f;
        FishWeight = 1f;
    }

    public void TimeStop(float weight)
    {
        if (transform.parent.tag == "Player")
        {
            Vibrate vibrate1 = new Vibrate();
            vibrate1.vibrate(30);
        }
        FishWeight = weight;
        if (!stopping)
        {
            TempBusterSp = Player_.transform.GetComponent<Player>().BusterSpeed;
            TempMoveSp = Player_.transform.GetComponent<Player>().MovementSpeed;
            TempRotateSp = Player_.transform.GetComponent<Player>().RotationSpeed;
            TempSpeed = Player_.transform.GetComponent<Player>().Speed;
            stopping = true;
            PlayerValue(0);
            if (transform.parent.tag == "Player")
                cam.GetComponent<Tracking_player>().StartCoroutine("CrushCam"); // 킬할때 카메라 흔들리게 해서 타격감살리기.
            // StartCoroutine("Stop_");

        }
    } // 유닛회전,이동 속도 줄이는 함수.
    IEnumerator Stop_()
    {

        // yield return new WaitForSecondsRealtime(0.00f);
        //PlayerValue(1);
        PlayerSlowValue();

        yield return new WaitForSecondsRealtime(0.1f * FishWeight); //0.07f + (Mathf.Pow(2, FishWeight) / 100) / 2
        PlayerValue(1);
        stopping = false;


        Player_.transform.GetComponent<Player>().StopCoroutine("Start_");

        Player_.transform.GetComponent<Player>().StartCoroutine("Start_");

    }// 줄였다가, 원상복구시키는 코루틴.

    void PlayerValue(float value) // 손 봥야하는 곳!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        SlowFlag_ = false;
    } // 유닛회전,이동 속도 줄어들기 이전으로 바꿔주는함수.
    void PlayerSlowValue()
    {
        SlowFlag_ = true;
    }  //실질적으로 유닛회전,이동 속도 줄이는 함수.
    public void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.transform.tag == "Trush" || other.transform.tag == "BigTrash" || other.transform.tag == "Kraken" || other.transform.tag == "Attacker" || other.transform.tag == "Tentacle" || other.transform.tag == "InkOct" || other.transform.tag == "BTK") && (transform.tag == "Knife" && transform.parent.tag == "Player"))
        {
            // if (other.transform.tag == "Kraken" || other.transform.tag == "Attacker" ||other.transform.tag == "Tentacle")

            TimeStop(1f);
        }
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (transform.parent != null)
        {
            if (transform.parent.tag == "Player")
                transform.localScale = transform.localScale / transform.localScale.y;
            else if (transform.parent.tag == "AiPlayer")
            {
                transform.localScale = (transform.localScale / transform.localScale.y) / 2f;
            }
            else if (transform.parent.tag == "InkOct")
            {
                transform.localScale = new Vector3(0.1f, 1f, 1f);
                GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            }
            if (SlowFlag_)
            {
                Player_.GetComponent<Player>().RB.velocity = Vector2.zero;
            }

        }
    }
}
