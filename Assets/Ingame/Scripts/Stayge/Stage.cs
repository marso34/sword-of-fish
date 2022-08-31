using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage: MonoBehaviour
{
    // Start is called before the first frame update
    public int BossHP;
    public GameObject VEC;
    public GameObject QM;
    public bool flag;
    public int GoalCount;
    public Sprite Icon;
    public bool TrashFlag;
    public float TrashGravity;
    public GameObject BlackPanel;
    public int HardConst;
    // Update is called once per frame
   Vector3 DownTPosition()
    {//떨어질쓰레기 위치설정
        GameObject TP = GameObject.FindGameObjectWithTag("TrashPoint");
        int Trange = 13;
        if(QM.GetComponent<QuestManager>().Level_ == 1) Trange = 30;
        else if (QM.GetComponent<QuestManager>().Level_ == 2) Trange = 13;

        return new Vector3(Random.Range(-1*Trange, Trange), TP.transform.position.y, 0);
    }
    void CreateTrash_()
    {
        GameObject T;
        T = Instantiate(QM.GetComponent<QuestManager>().TrashObj, DownTPosition(), Quaternion.Euler(0, 0, Random.Range(0, 360f)));
        T.GetComponent<Rigidbody2D>().gravityScale = TrashGravity;
        TrashFlag = true;
        //T.name = "bullet(Clone)";
    }
    public void TrashOn(){

        if (TrashFlag)
        {
            Invoke("CreateTrash_", 1.5f);
            TrashFlag = false;
        }
    }
    public void initHardConst(){
        HardConst = QM.GetComponent<QuestManager>().Level_ - 2;
        if (HardConst < 0) HardConst = 0;
    }
}
