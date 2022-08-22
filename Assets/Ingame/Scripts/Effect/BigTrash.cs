using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTrash : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP = 30;
    public GameObject HitEffect;
    public GameObject KillEffect;
    public GameObject BoombEffect;
    public GameObject BoombSound;
    public GameObject KillSound;
    public GameObject PT;
    public GameObject DamageText;

    public bool Flag;
    void Start()
    {
        Flag = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (HP > 0)
        {
            if (other.gameObject.tag == "Knife" && other.transform.parent.gameObject.tag == "Player")
            {
                other.transform.GetComponent<HitFeel>().TimeStop(0.8f);
                HP -= 1;

                var DT = Instantiate(DamageText, other.contacts[0].point, Quaternion.Euler(0f, 0f, 0f));
                DT.GetComponent<DamageTxt>().dtxt.text = 1.ToString();
                DT.transform.localScale *= 2f;

                float x_ = transform.localScale.x;
                if (x_ > 0)
                    x_ *= -1;
                var KE = Instantiate(HitEffect, other.contacts[0].point, Quaternion.Euler(0, 0, Random.Range(-180f, 180f)));
                KE.transform.localScale = new Vector3(x_, transform.localScale.y, transform.localScale.z).normalized * 3.5f;
                KE.gameObject.GetComponent<Effect>().SetEffect(1);

                var KS = Instantiate(KillSound, other.contacts[0].point, Quaternion.Euler(0, 0, 0));
            }

        }

    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EXPL")
        {
            var DT = Instantiate(DamageText, transform.position, Quaternion.Euler(0f, 0f, 0f));
            DT.GetComponent<DamageTxt>().dtxt.text = 5.ToString();
            DT.transform.localScale *= 2f;
            HP -= 5;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 && Flag)
        {
            Flag = false;
            // var KE1 = Instantiate(KillEffect, PT.transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
            // KE1.transform.localScale *= Random.Range(2.0f, 4.0f);
            // var KE = Instantiate(HitEffect, PT.transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
            var BE = Instantiate(BoombEffect, new Vector3(transform.position.x - 2f, transform.position.y + 3.5f, transform.position.z), Quaternion.Euler(0, 0, 0));
                BE.transform.localScale *= 2;
                //BE.transform.GetChild(2).tag = "AiPlayer";
                var BS = Instantiate(BoombSound, transform.position, Quaternion.Euler(0, 0, 0));
            gameObject.layer = 4;
            if (transform.name == "_Kraken") // 크라켄 쓰레기일 경우만
            {
                
                Invoke("win", 1f);
            }
            Destroy(transform.parent.gameObject, 3f);

        }
    }
    void win()
    {
        gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().BigTrashC++;
    }
}
