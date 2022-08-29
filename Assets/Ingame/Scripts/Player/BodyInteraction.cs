using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyInteraction : MonoBehaviour
{
    public GameObject MyKnife;
    public GameObject KillEffect;
    public GameObject KillEffect2;
    public GameObject KillEffectO;
    public Transform cam;
    public float chsize = 0.001f;
    public float chc;
   // public bool TutorialFlesh = false;
    
    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").transform;
        Time.timeScale = 1;
    
    }
    private void Update()
    {
        transform.localPosition = Vector3.zero;
    }
    public void OnCollisionEnter2D(Collision2D other2)
    {
        StabbedKnife(other2.gameObject,other2.contacts[0].point);
        
        TrashHit(other2.gameObject);
        if (other2.gameObject.tag == "BossSkillA" && transform.tag == "Body")
            if (transform.parent.tag == "Player") transform.parent.GetComponent<Player>().DieLife();
    }
    void HitEXPL(GameObject other)
    {
        
    }
    /// <summary>
    /// Sent when a collider on another object stops touching this
    /// object's collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        HitEXPL(other.gameObject);
        
       
        EatFlesh(other.gameObject);    
    }
    


    void StabbedKnife(GameObject other,Vector3 V)
    {
        //Debug.Log(other.transform.tag +"iiiii");
        if (other.gameObject.tag == "Knife" && transform.tag == "Body")
            if (((other.transform.parent.tag == "InkOct" || other.transform.parent.gameObject.tag == "AiPlayer") && transform.parent.tag == "Player") || ((transform.parent.tag == "AiPlayer" || transform.parent.tag == "InkOct") && other.transform.parent.tag == "Player"))
            {
                if (other.transform.parent.gameObject != transform.parent.gameObject)
                {
                    transform.parent.gameObject.GetComponent<Player>().DieLife();
                    other.transform.parent.gameObject.GetComponent<Player>().KillScoreUp();
                    if (other.name != "body" && other.transform.parent.tag == "Player")
                        other.transform.GetComponent<HitFeel>().TimeStop(1f);
                    //if(transform.parent.tag == "Player")transform.GetComponent<HitFillBody>().TimeStop_(1f);
                    float QR = Random.Range(1, 7);
                    var KE = Instantiate(KillEffect, transform.position, Quaternion.Euler(0f, 0f, 20f * QR));
                    float R = Random.Range(0.8f, 1.7f);
                    float x_ = transform.localScale.x;
                    if (x_ > 0)
                        x_ *= -1;

                    KE.transform.localScale = new Vector3(x_, transform.localScale.y, transform.localScale.z);
                    // KE.transform.localScale = transform.parent.localScale; * R / 1.5f;
                    Flag_Still(other.transform.parent.gameObject);
                }

              
            }
    }// 칼에 다앟을때
    void EatFlesh(GameObject other)
    {
        if (other.gameObject.tag == "Flesh" && ((transform.name == "body" && transform.parent.tag == "Player") || transform.tag == "Body" || transform.tag == "Shiled"))
        {
            Debug.Log("먹이");
           // TutorialFlesh = true; //y
            GiveSize();
            GiveBusterGage();
            other.gameObject.GetComponent<flesh>().destroyme(transform.parent.gameObject);
        }
    }   // 시체 먹었을때

    void GiveSize()
    {

        if (transform.parent.tag == "Player") chc = 0.2f;
        else if ((transform.parent.tag == "AiPlayer")) chc = 3f;
        Vector3 Porce = new Vector3(chsize, chsize, 0f);
        if (transform.parent.localScale.x < 0) Porce = new Vector3(-1 * chsize * chc, chsize * chc, 0f);
        transform.parent.gameObject.GetComponent<Player>().Sizech(transform.parent.localScale + Porce);
        transform.parent.gameObject.GetComponent<Player>().fleshCount++;
    } //플레이어의 크기를 키워준다.
    void GiveBusterGage()
    {
        if (transform.parent.tag == "Player")
        {
            float cutGauge = 7f;
            transform.parent.gameObject.GetComponent<PlayerScript>().Handlebar(cutGauge);
        }
    }//플레이어의 부스터 게이지를 키워준다.
    void Flag_Still(GameObject other)
    {
        if (transform.parent.GetComponent<Player>().Flag_get)
        {
            other.GetComponent<Player>().Flag_get = true;
            transform.parent.GetComponent<Player>().Flag_get = false;
        }
    }//플레이어가 깃발을 가지고있다면 게이지 채우기. 점령 ShapeC
    void TrashHit(GameObject other)
    {
        if (transform.tag == "Body" && other.tag == "Trush" && transform.parent.tag == "Player")
        {
            transform.parent.gameObject.GetComponent<Player>().SlowMoveSpeed(1f);
            //transform.parent.gameObject.GetComponent<Player>().SlowRotateSpeed(1f);
         
        }
    }
    void StopTime_()
    {
        Time.timeScale = 0.01f;
    }
    void StartTime_()
    {
        Time.timeScale = 1;
        //transform.parent.GetComponent<Player>().HP--;
    }
    public void BoomOn()
    {
        var KE1 = Instantiate(KillEffect, transform.parent.position, Quaternion.Euler(0f, 0f, 20f));
        KE1.gameObject.GetComponent<Effect>().SetEffect(0);
    }

}
