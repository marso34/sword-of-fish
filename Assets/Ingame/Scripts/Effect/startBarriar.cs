using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBarriar : MonoBehaviour
{
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0f;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= 2f)
            DelBarriar();
    }

    void DelBarriar()
    {
        transform.parent.gameObject.GetComponent<Player>().Init_();
        Destroy(gameObject);
    }

    public void OnCollisionExit2D(Collision2D other)
    { 
        if (other.gameObject.name == "bullet(Clone)" || other.gameObject.name == "Bullet(Clone)" || other.gameObject.tag == "EXPL" || other.gameObject.tag == "SkillB" || other.gameObject.tag == "SkillO" || other.gameObject.tag == "BossSkillA" || (other.gameObject.tag == "Knife" && (other.transform.parent.tag == "InkOct" || other.transform.parent.gameObject.tag == "AiPlayer"))) {
            if (other.gameObject.tag == "SkillB")
                other.gameObject.GetComponent<Skill2>().DelFalg = true;
            if (other.gameObject.name == "Bullet(Clone)")
                other.gameObject.GetComponent<Skill2>().DestroyBossSkill(transform.parent.gameObject);
            if (other.gameObject.name == "bullet(Clone)")
                other.gameObject.GetComponent<bullet>().DelBullet();
            DelBarriar();
        }
    }
}
