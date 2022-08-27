using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    
    Rigidbody2D RB;
    public Vector3 dir;
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2.0f);
        
       
    }
    // Update is called once per frame
    void Update()
    {
        if (dir != null && !transform.GetComponent<Trush>().FRZFlag)
            RB.velocity = dir.normalized * 5;
    }
    public void SetDir(Vector3 dir_)
    {
        dir = dir_;
        
         
       
        Debug.Log("방향설정");
    }

    public void DelBullet()
    {
        Destroy(gameObject, 2.0f);
    }

}
