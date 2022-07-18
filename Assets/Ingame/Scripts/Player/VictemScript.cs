using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictemScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool Prizen = true;
   
    GameObject QM;
    public GameObject GoodSounds;
    public GameObject[] Attacker_;
    int maxAttacker = 2;
    private void Start()
    {
       
        
        QM = GameObject.FindGameObjectWithTag("QM");
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!Prizen && other.transform.tag == "Body" && other.transform.parent.tag == "Player")
        {
            QM.GetComponent<QuestManager>().CurrentCount++;
            var KS = Instantiate(GoodSounds, transform.position, Quaternion.Euler(0f, 0f, 20f));
            //상호작용 EX 이팩트, 사운드 넣기
            Destroy(gameObject, 0f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        for(int i=0; i <Attacker_.Length;++i){
            Prizen = false;
            if(Attacker_[i].GetComponent<AttackerScript>().Life) Prizen = true;
        }      

    }
}
