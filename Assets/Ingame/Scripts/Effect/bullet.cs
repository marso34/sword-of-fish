using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 dir;
    private void Start()
    {
        Destroy(gameObject, 2.0f);
    }
    // Update is called once per frame
    void Update()
    {
        if (dir != null && !transform.GetComponent<Trush>().FRZFlag)
            transform.Translate(dir.normalized * 5 * Time.deltaTime, Space.World);

    }
    public void SetDir(Vector3 dir_)
    {
        dir = dir_;
    }

    public void DelBullet()
    {
        Destroy(gameObject, 2.0f);
    }

}
