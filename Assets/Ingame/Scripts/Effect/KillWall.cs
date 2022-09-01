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
        watingtime = 0.2f;
    }

    public void OnCollisionEnter2D(Collision2D other2)
    {
        if (other2.transform.tag != "Knife" &&other2.transform.parent != null && other2.transform.parent.tag == "Player")
        {
//            Debug.Log("Ãæµ¹Áß");
                if (transform.tag == "Wall")
                {
                    transform.GetComponent<WallMove>().MoveFlag = false;
                    KillPlayer(other2.transform.parent.gameObject);
                }
                else{
                    other2.transform.parent.gameObject.GetComponent<Player>().HP--;
                other2.transform.parent.gameObject.GetComponent<Player>().HP--;
                    other2.transform.parent.gameObject.GetComponent<Player>().DieLife();
                }
            
        }
    }
    void KillPlayer(GameObject P)
    {
        P.GetComponent<Player>().DieLife();
        P.GetComponent<Player>().HP = 0;
    }
}
