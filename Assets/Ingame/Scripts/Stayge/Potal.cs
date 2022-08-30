using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    public GameObject Player;
    public GameObject Victem;
    public GameObject Camera;

    public int Goal;

    bool flag;
    bool flag2;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Camera = GameObject.FindWithTag("MainCamera");
        Goal = 0;
        flag = false;
        flag2 = true;
    }

    private void Update()
    {
        if (flag)
        {
            if (flag2)
            {
                var frustumHeight = 2.0f * 19 * Mathf.Tan(Camera.GetComponent<Camera>().fieldOfView * 0.5f * Mathf.Deg2Rad);
                var frustumWidth = frustumHeight * Camera.GetComponent<Camera>().aspect;
                var Grandpa = Instantiate(Victem, new Vector3(transform.position.x + frustumWidth/2, Player.transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90f));
                Grandpa.transform.localScale = Player.transform.localScale;
                Camera.GetComponent<Tracking_player>().target_set(Grandpa);
                // Grandpa.gameObject.GetComponent<Player>().RB.velocity = Vector2.right;
                flag2 = false;
            }

            Camera.GetComponent<Tracking_player>().Speed = 0.7f;
            Player.GetComponent<Player>().RB.velocity = Vector2.zero;
        }
    }

    public void succes()
    {
        flag = true;
        Invoke("upGoal", 5f);
    }
    void upGoal()
    {
        Goal = 1;
        Camera.GetComponent<Tracking_player>().target_set(Player);
    }
}
