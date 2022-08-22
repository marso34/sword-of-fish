using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trush : MonoBehaviour
{
    public GameObject KillEffect;
    public GameObject KillEffect2;
    public GameObject KillSound_;
    public GameObject Star;
    public GameObject Hart;
    public GameObject Litening;
    public GameObject Bomb;
    public GameObject Ice;
    public GameObject Shield;
    public GameObject StabSound;
    public GameObject BarrerSound;
    public Sprite[] Image;
    public ParticleSystem DelEffect;

    SpriteRenderer Skin;

    public int HP;
    float timer22 = 0;
    float watime2 = 1f;
    float timer33 = 0;
    float watime3 = 5f;
    float timer44 = 0;
    float watime4 = 4f;
    bool roateDirflag = true;
    bool flag = true;
    float rota;
    float Speed = 0.1f;
    Vector3 roateDir;
    Color c;
    Vector3 Dir;
    SpriteRenderer S;
    public bool FRZFlag;


    private void Start()
    {
        FRZFlag = false;

        Skin = transform.GetChild(0).GetComponent<SpriteRenderer>();
        InitImage();
        HP = Random.Range(1, 3);
        if (transform.name == "bullet(Clone)") HP = 1;
        rota = 15f;
        Dir = Vector3.zero;
        // float roateDirX = Random.Range(-0.9f, 0.9f);
        // float roateDirY = Random.Range(-0.9f, 0.9f);
        // roateDir = new Vector3(roateDirX, roateDirY, 0);
        // Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, roateDir.normalized); //랜덤방향에 맞게 정면을 보도록 회전값 받아오기.
        // transform.localRotation = toRotation;
        S = Skin.transform.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        transform.Translate(Dir * 0.5f * Time.deltaTime);
        if (!FRZFlag)
            shakeObj();
        statusColor();
    }
    void FRZOn()
    {
        FRZFlag = true;
        Dir = Vector3.zero;
        Rigidbody2D r = transform.GetComponent<Rigidbody2D>();
        r.velocity = Vector2.zero;
        r.gravityScale = 0;
    }
    void FRZOff()
    {
        FRZFlag = false;
        Rigidbody2D r = transform.GetComponent<Rigidbody2D>();
        r.gravityScale = 0.1f;
    }
    void statusColor()
    {
        if (FRZFlag == true)
        {
            c = new Color(60f / 255f, 150f / 255f, 255f / 255f);
            S.color = c;
        }
        else if (FRZFlag == false)
        {
            c = Color.white;
            S.color = c;
        }
    }
    void InitImage()
    {
        Skin.sprite = Image[Random.Range(0, 12)];
    }

    void shakeObj()
    {
        Speed = Random.Range(0.05f, 0.12f);
        timer22 += Time.deltaTime;
        if (timer22 > watime2)
        {
            flag = !flag;
            timer22 = 0;
            watime2 = Random.Range(0.8f, 1.2f);
        }
        timer33 += Time.deltaTime;
        if (timer33 > watime3)
        {
            roateDirflag = !roateDirflag;
            timer33 = 0;
            watime3 = Random.Range(0.8f, 1.2f);
            rota = Random.Range(10f, 15f);
        }
        timer44 += Time.deltaTime;
        if (timer44 > watime4)
        {
            flag = !flag;
            timer44 = 0;
            watime4 = Random.Range(0.8f, 1.2f);
        }

        if (roateDirflag)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            //transform.Rotate(Vector3.forward * rota * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            //transform.Rotate(Vector3.back * rota * Time.deltaTime);
        }
        if (flag)
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EXPL") BrokenTrash();
        if (other.gameObject.tag == "FRZ")
        {
            FRZOn();
            Invoke("FRZOff", 2.5f);
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        GameObject QM = GameObject.FindGameObjectWithTag("QM");
        if (other.gameObject.tag == "Twall")
        {
            if (transform.name == "Can")
                QM.GetComponent<QuestManager>().TrashOC--;
            else if (transform.name == "Paper") QM.GetComponent<QuestManager>().Trash2OC--;
            Destroy(gameObject);

        }
        if ((other.gameObject.tag == "Knife" && other.transform.parent.tag == "Player"))
        {
            OnOutline();
            Invoke("OffOutline", 0.03f);


            if (transform.name != "BigTrash")
            {
                HP--;
                if (HP <= 0)
                {
                    Speed = 0;
                    other.transform.parent.gameObject.GetComponent<PlayerScript>().TrushCount++;
                    var KE = Instantiate(DelEffect, transform.position, Quaternion.Euler(0f, 0f, 0f));
                    KE.transform.parent = transform.GetChild(0);

                    var Sound1 = Instantiate(KillSound_, transform.position, Quaternion.Euler(0f, 0f, 0f));
                    other.transform.parent.GetComponent<PlayerScript>().Handlebar(15f);
                    {
                        int rand = Random.Range(0, 15);
                        if (rand == 1 || rand == 2) Instantiate(Star, transform.position, Quaternion.Euler(0f, 0f, 0f));
                        else if (rand == 4 || rand == 5 || rand == 6) Instantiate(Hart, transform.position, Quaternion.Euler(0f, 0f, 0f));
                        else if (rand == 8 || rand == 9 || rand == 10) Instantiate(Litening, transform.position, Quaternion.Euler(0f, 0f, 0f));
                        else if (rand == 3 || rand == 7) Instantiate(Bomb, transform.position, Quaternion.Euler(0f, 0f, 0f));
                        else if (rand == 11 || rand == 12) Instantiate(Ice, transform.position, Quaternion.Euler(0f, 0f, 0f));
                        else if (rand == 13 || rand == 14) Instantiate(Shield, transform.position, Quaternion.Euler(0f, 0f, 0f));
                    }

                    if (transform.name == "Can")
                        QM.GetComponent<QuestManager>().TrashOC--;
                    else if (transform.name == "Paper") QM.GetComponent<QuestManager>().Trash2OC--;

                    Destroy(gameObject, 0f);
                }
                else
                {
                    //if (!FRZFlag)
                       // Dir = ((transform.position - other.transform.parent.position) + (transform.position - (other.transform.parent.position + (other.transform.parent.GetComponent<Player>().dir.normalized * 0.25f))));

                }


                var KE1 = Instantiate(StabSound, transform.position, Quaternion.Euler(0f, 0f, 20f));
            }
        }
        else if (other.gameObject.tag == "Body" && other.transform.parent.tag == "Player" && transform.name == "bullet(Clone)")
        {
            other.transform.GetComponent<BodyInteraction>().BoomOn();
            other.transform.parent.GetComponent<Player>().DieLife();
        }



    }
    public void BrokenTrash()
    {
        var KE = Instantiate(KillEffect2, transform.position, Quaternion.Euler(0f, 0f, 0 + Random.Range(-180, 180)));
        var Sound1 = Instantiate(KillSound_, transform.position, Quaternion.Euler(0f, 0f, 0f));
        int rand = Random.Range(0, 15);
        if (rand == 1 || rand == 2) Instantiate(Star, transform.position, Quaternion.Euler(0f, 0f, 0f));
        else if (rand == 4 || rand == 5 || rand == 6) Instantiate(Hart, transform.position, Quaternion.Euler(0f, 0f, 0f));
        else if (rand == 8 || rand == 9 || rand == 10) Instantiate(Litening, transform.position, Quaternion.Euler(0f, 0f, 0f));
        else if (rand == 3 || rand == 7) Instantiate(Bomb, transform.position, Quaternion.Euler(0f, 0f, 0f));
        else if (rand == 11 || rand == 12) Instantiate(Ice, transform.position, Quaternion.Euler(0f, 0f, 0f));
        else if (rand == 13 || rand == 14) Instantiate(Shield, transform.position, Quaternion.Euler(0f, 0f, 0f));
        Destroy(gameObject, 0f);
    }

    public void UpdateOutline(bool outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        S.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", Color.white);
        mpb.SetFloat("_OutlineSize", 15);
        S.SetPropertyBlock(mpb);
    }


    void OnOutline()
    {
        UpdateOutline(true);
    }

    void OffOutline()
    {
        UpdateOutline(false);
    }
}
