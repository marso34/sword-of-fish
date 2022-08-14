
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QM;
    public bool flag;
    public int GoalCount;
    public Sprite Icon;
    public bool TrashFlag;
    

    // Update is called once per frame
   Vector3 DownTPosition()
    {//떨어질쓰레기 위치설정
        return new Vector3(Random.Range(-13, 13), 10f, 0);
    }
    void CreateTrash_()
    {
        GameObject T;
        T = Instantiate(QM.GetComponent<QuestManager>().TrashObj, DownTPosition(), Quaternion.Euler(0, 0, Random.Range(0, 360f)));
        T.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        TrashFlag = true;
        //T.name = "bullet(Clone)";
    }
    public void TrashOn(){
        if (TrashFlag)
        {
            Debug.Log("쓰레기 생성");
            Invoke("CreateTrash_", 0.5f);
            TrashFlag = false;
        }
    }
}
