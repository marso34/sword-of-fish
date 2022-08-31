using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    public GameObject Player;
    public GameObject Victem;
    public GameObject AiPlayer;
    public GameObject Camera;
    public GameObject TrashMap;

    public int Goal;

    float timer;

    bool flag;
    bool flag2;
    bool flag3;

    void Start()
    {
        Goal = 0;
        timer = 0f;
        flag = false;
        flag2 = true;
        flag3 = false;
    }

    private void Update()
    {
        if (flag)
        {
            if (flag2)
            {
                Player = GameObject.FindWithTag("Player");
                Camera = GameObject.FindWithTag("MainCamera");
                Camera.GetComponent<Tracking_player>().Speed = 2.5f;

                CreateMob();
                flag2 = false;
                flag3 = true;
            }

            if (flag3)
            {
                AiPlayer = GameObject.FindWithTag("AiPlayer");
                Victem = GameObject.FindWithTag("Victem");
                AiPlayer.GetComponent<AiPlayerScript>().waitingTime = 20f;

                timer += Time.deltaTime;

                if (Victem.GetComponent<VictemScript>().HP == 10)
                {
                    Camera.GetComponent<Tracking_player>().target_set(Victem);

                    if (timer >= 0.5f)
                    {
                        AiPlayer.GetComponent<AiPlayerScript>().dir = Victem.transform.position - AiPlayer.transform.position;
                        timer = 0f;
                    }
                }
                else
                {
                    AiPlayer.GetComponent<AiPlayerScript>().dir = Vector3.right;
                    
                    if (timer >= 0.5f)
                    {
                        Camera.GetComponent<Tracking_player>().target_set(Player);
                    }
                }

                AiPlayer.GetComponent<AiPlayerScript>().Speed = 0.5f;

                if (timer >= 1.5f)
                {
                    Destroy(AiPlayer);
                    Destroy(Victem);
                    flag3 = false;
                    timer = 0f;
                }
            }
            else
            {
                timer += Time.deltaTime;

                if (timer >= 0.5f && timer < 2.5f)
                    Player.GetComponent<Player>().Flag_get = true;

                if (timer >= 2.5f)
                {
                    Player.GetComponent<Player>().Flag_get = false;
                    Invoke("upGoal", 0.5f);
                }

                Camera.GetComponent<Tracking_player>().Speed = 0.7f;
            }

            Player.GetComponent<Player>().RB.velocity = Vector2.zero;
        }
    }

    void CreateMob()
    {
        var frustumHeight = 2.0f * 19 * Mathf.Tan(Camera.GetComponent<Camera>().fieldOfView * 0.5f * Mathf.Deg2Rad);
        var frustumWidth = frustumHeight * Camera.GetComponent<Camera>().aspect;

        var Grandpa = Instantiate(Victem, new Vector3(transform.position.x + frustumWidth / 2, Player.transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90f));
        var Enemy = Instantiate(AiPlayer, new Vector3(transform.position.x + frustumWidth / 2 - 4f, 14.4f, transform.position.z), Quaternion.Euler(0, 0, 0));

        Enemy.GetComponent<Player>().StartFlag = true;
        Enemy.GetComponent<Player>().dir = Vector3.zero;
        Enemy.transform.localScale = Player.transform.localScale;
        Enemy.transform.parent = transform.parent;

        Grandpa.transform.localScale = Player.transform.localScale;
        Grandpa.transform.parent = transform.parent;

    }

    public void succes()
    {
        flag = true;
        TrashMap.GetComponent<WallMove>().MoveFlag = false;
    }
    void upGoal()
    {
        Goal = 1;
        Camera.GetComponent<Tracking_player>().target_set(Player);
        Camera.GetComponent<Tracking_player>().Speed = 2f;
    }
}
