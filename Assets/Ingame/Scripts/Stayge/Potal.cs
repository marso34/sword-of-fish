using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    public GameObject Victem;

    public int Goal;
    bool flag;


    void Start()
    {
        Goal = 0;
        flag = false;
    }

    private void Update()
    {
        if (flag)
        {
            var Grandpa = Instantiate(Victem, new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90f));
            var anemy = Instantiate(Victem, new Vector3(transform.position.x + 8f, transform.position.y + 2f, transform.position.z), Quaternion.Euler(0, 0, -90f));

            anemy.GetComponent<VictemScript>().FishNumber = 5;
            Grandpa.transform.parent = transform;
            anemy.transform.parent = transform;

            flag = false;
        }
    }

    public void succes()
    {
        flag = true;
        // Invoke("upGoal", 3f);
    }
    void upGoal()
    {
        Goal = 1;
    }
}
