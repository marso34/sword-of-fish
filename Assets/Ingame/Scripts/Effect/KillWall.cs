using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWall : MonoBehaviour
{
    float timer;
    float watingtime;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        watingtime = 2f;
    }

    public void OnCollisionStay2D(Collision2D other2)
    {
        if (other2.transform.tag == "Body")
        {
            Debug.Log("충돌중");
            timer += Time.deltaTime;
            if (timer > watingtime) KillPlayer(other2.transform.parent.gameObject);
        }
    }
    public void OnCollisionExit2D(Collision2D other2)
    {
        if (other2.transform.tag == "Body")
        {
            {
                timer = 0;
                Debug.Log("NOT충돌중");
            }
        }
    }
    void KillPlayer(GameObject P)
    {

        P.GetComponent<Player>().DieLife();
        P.GetComponent<Player>().HP = 0;
    }
}
