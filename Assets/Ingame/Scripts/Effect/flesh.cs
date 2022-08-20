using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flesh : MonoBehaviour
{
    public GameObject[] AiPlayers; // J
    public GameObject Player; // J
    public GameObject GM;
    public GameObject eatSound;
    public enum State { first, last, non };//상태들 집합
    public State state;// 현재상태
    SpriteRenderer S;
    Color C;
    float time;
    float Watingtime;
    public float Speed;

    public Vector3 dir; // J

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
        S = transform.GetComponent<SpriteRenderer>();
        C.a = 0f;
        C.b = 1f;
        C.r = 1f;
        C.g = 1f;
        time = 0;
        Watingtime = 0.1f;
        S.color = C;
        state = State.non;
        Speed = 8f;
        Invoke("setActive", 0f);
    }
    IEnumerator non()
    {
        for (int i = 0; i < 2; ++i)
        {
            C.a = 0f;
            S.color = C;
        }
        yield return new WaitForSeconds(0.01f);
    }
    IEnumerator first()
    {
        Invoke("FleshNameset", 0.3f);
        for (int i = 0; i < 50; ++i)
        {
            ShowOnAnim(i);
            yield return new WaitForSeconds(0.005f);
        }
    }
    public void FleshNameset()
    {
        transform.tag = "Flesh";
    }
    public void ShowOnAnim(int index)//죽었을때 애니매이션 재생함수
    {
        if (index == 49)
        {

            Invoke("onLast", 5f);
        }
        else if (S.color.a <= 1)
        {
            for (int i = 0; i < 50; i++)
            {
                if (i == index)
                {
                    C.a += 0.02f;
                    S.color = C;

                }
            }
        }
        if (S.color.a > 1)
        {
            C.a = 1f;
            S.color = C;
        }
    }
    public void onLast()
    {
        StopCoroutine("first");
        StartCoroutine("last");
    }
    IEnumerator last()
    {
        for (int i = 0; i < 50; ++i)
        {
            ShowOffAnim(i);

            yield return new WaitForSeconds(0.01f);
        }
    }
    public void ShowOffAnim(int index)//죽었을때 애니매이션 재생함수
    {
        if (index == 49) Destroy(gameObject); //삭제
        else if (S.color.a >= 0)
        {
            for (int i = 0; i < 50; i++)
            {
                if (i == index)
                {
                    C.a -= 0.02f;
                    S.color = C;
                }
            }
        }
    }
    void setActive()
    {
        StartCoroutine("first");
    }
    public void destroyme(GameObject Obj)
    {
        if (Obj.tag == "Player")
            Instantiate(eatSound, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void eraser_()
    {

        Destroy(gameObject);
    }
    private void Update()
    {
        if (GM.GetComponent<GameManager_>().resetFlag) Destroy(gameObject);

        Player = GameObject.FindGameObjectWithTag("Player");  // J
        AiPlayers = GameObject.FindGameObjectsWithTag("AiPlayer");  // J
        if (Player != null)
        {
            if (transform.tag == "Flesh")
                dir = MinDirWhale();  // J
            if (dir.magnitude < 5f + Player.transform.localScale.y)  // J
                transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);  // J
        }
    }

    Vector3 MinDirWhale() // J
    {//wewew
        Vector3 min = new Vector3(1000, 1000, 1);

        if (Player.GetComponent<Player>().SkillFlag == true && (Player.GetComponent<Player>().FishNumber == 4 || Player.GetComponent<Player>().FishNumber == 5))
            min = Player.transform.position - transform.position;
        Vector3 TrDir;

        // for (int i = 0; i < 4; i++)
        // {
        //     if (AiPlayers[i].GetComponent<AiPlayerScript>().SkillFlag == true && (AiPlayers[i].GetComponent<AiPlayerScript>().FishNumber == 4 || AiPlayers[i].GetComponent<AiPlayerScript>().FishNumber == 5))
        //     {
        //         TrDir = AiPlayers[i].transform.position - transform.position;
        //         if (min.magnitude > TrDir.magnitude) min = TrDir;
        //     }
        // }

        return min;
    } // 스킬 쓰는 가장 가까운 고래신사 방향 반환
    /*
    public float Porce;
    
    private void Start()
    {      
        gameObject.SetActive(false);       
        Invoke("setActive", 2f);
    }   
   

   
    */

}
