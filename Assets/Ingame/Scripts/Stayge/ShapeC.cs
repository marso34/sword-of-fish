using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeC : MonoBehaviour
{
    public GameObject QM;
    public float time_ = 0;
    public float waitTime = 1f;
    public bool hitPlayerFlag;
    private void Start()
    {
        QM = GameObject.FindGameObjectWithTag("QM");
    }
    public void OnCollisionStay2D(Collision2D other)
    {      
       if (other.transform.tag == "Body" && other.transform.parent.tag == "Player" && (QM.GetComponent<QuestManager>().OccupationTime < 10))
       {
            Debug.Log("sssss");
            hitPlayerFlag = true;
       }    
    }
    public void OnCollisionExit2D(Collision2D other2) {
        if (other2.transform.tag =="Body" && other2.transform.parent.tag == "Player" && (QM.GetComponent<QuestManager>().OccupationTime < 10))
        {
            hitPlayerFlag = false;
        }
    }
    private void Update()
    {
        if (hitPlayerFlag && !QM.GetComponent<QuestManager>().GM.GetComponent<GameManager_>().EndFlag)
        {
            time_ += Time.deltaTime;
            if (time_ > waitTime)
            {
                time_ = 0;
                QM.GetComponent<QuestManager>().OccupationTime++;
            }
        }
        else time_ = 0;
    }
}
