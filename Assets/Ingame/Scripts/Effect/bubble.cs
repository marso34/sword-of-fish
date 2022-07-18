using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bubble : MonoBehaviour
{
    public enum State { first,last};//상태들 집합
    public State state;// 현재상태
    SpriteRenderer S;
    Color C;
    float time;
    float Watingtime;
    public float Speed;
    public Vector3 dir;
    public GameObject GM;
    private IEnumerator Start()
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
        state = State.first;
        while (true) yield return StartCoroutine(state.ToString());//코루틴 실행 매프레임마다.  코루틴 인터넷 검색해서 알아보기 
    }   
    IEnumerator first()
    {
        
        for (int i = 0; i < 50; ++i)
        {
            float R = 0.008f;
            if (Speed == 0.03f)
                R = 0.001f;
            ShowOnAnim(i);

            yield return new WaitForSeconds(R);
        }
    }
    public void onLast()
    {
        state = State.last;
    }
    public void ShowOnAnim(int index)//죽었을때 애니매이션 재생함수
    {
        if (index == 49)
        {
            float R = Random.Range(0.05f, 0.2f);
            if (Speed == 0.03f)
                R =0f;
            Invoke("onLast",R );
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
        if(S.color.a >1)
        {
            C.a = 1f;
            S.color = C;
        }
    }
    IEnumerator last()
    {
        for (int i = 0; i < 50; ++i)
        {
            float R = 0.008f;
            if (Speed == 0.03f)
                R = 0.001f;
            ShowOffAnim(i);

            yield return new WaitForSeconds(R);
        }
    }
    public void eraser()
    {
        Destroy(gameObject);
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
    private void Update()
    {

        if (GM.GetComponent<GameManager_>().resetFlag) Destroy(gameObject);
        transform.Translate(dir.normalized * Speed, Space.World);
        
    }
   

}