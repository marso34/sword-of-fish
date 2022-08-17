using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSkill : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnSkill(other.gameObject);
    }
    /// <summary>
    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tornado" && gameObject.tag == "Body" && transform.parent.tag == "Player")
        {
            transform.parent.gameObject.GetComponent<PlayerScript>().RB.velocity = (other.transform.position - transform.parent.position).normalized * Random.Range(0.01f, 0.11f);
            Debug.Log("½ÇÇàµÊ");
        }
    }
    void OnSkill(GameObject other)
    {
         if (other.gameObject.transform.tag == "Potal")
        {
            Debug.Log("¼º°ø");
            other.GetComponent<Potal>().succes();
        }
    
        if (other.gameObject.tag == "SkillB" && transform.tag == "Body")
        {
            if (other.name == "Bullet" && transform.parent.tag == "Player")
            {
                transform.parent.GetComponent<PlayerScript>().DieLife();
                transform.parent.gameObject.GetComponent<Player>().SlowMoveSpeed(0.8f);
                transform.parent.gameObject.GetComponent<Player>().SlowRotateSpeed(0.2f);
                other.transform.gameObject.GetComponent<Skill2>().DelFalg = true;
            }

            if (transform.parent.tag == "AiPlayer")
            {
                transform.parent.gameObject.GetComponent<Player>().SlowMoveSpeed(0.8f);
                transform.parent.gameObject.GetComponent<Player>().SlowRotateSpeed(0.2f);
                other.transform.gameObject.GetComponent<Skill2>().DelFalg = true;
            }
        }

        if (other.gameObject.tag == "SkillO" && transform.tag == "Body")
        {
            transform.parent.gameObject.GetComponent<Player>().DieLife();
            //other.transform.gameObject.GetComponent<Skill2>().DelFalg = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().KillScoreUp();
            var KE22 = Instantiate(transform.GetComponent<BodyInteraction>().KillEffectO, transform.parent.position, Quaternion.Euler(0f, 0f, Random.Range(-80, 80)));
            KE22.transform.localScale = transform.localScale;
        }

        if (other.gameObject.tag == "FRZ" && transform.tag == "Body" && transform.parent.tag != "Player")
        {
            transform.parent.gameObject.GetComponent<Player>().C = new Color(60f / 255f, 150f / 255f, 255f / 255f);
            transform.parent.gameObject.GetComponent<Player>().ResetColor();
            transform.parent.GetComponent<Player>().StopMoveSpeed();
            transform.parent.GetComponent<Player>().StopRotateSpeed();
        }
        if (transform.parent.tag != "Player")
        {
            if (other.gameObject.tag == "EXPL" && transform.tag == "Body")
            {
                transform.parent.GetComponent<Player>().HP = -5;
            }
        }
        if (other.gameObject.tag == "SkillP" && transform.gameObject.tag == "Body" && transform.parent.tag == "Player")
        {
            if (transform.tag == "Body" && transform.parent.tag == "Player" && other.transform.tag == "SkillP")
            {
                var SK = Instantiate(other.GetComponent<Skill2>().Tornado, other.transform.position, Quaternion.Euler(0f, 0f, 0f));

                if (other.transform.localScale.x < 0)
                    SK.transform.localScale = new Vector3(-1f, 1f, 1f);
                Destroy(other.gameObject);
            }
        }
        
    }
}
