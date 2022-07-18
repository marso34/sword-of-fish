using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KomboKillImage : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] kill1;
    public Sprite[] kill2;
    public Sprite[] kill3;
    public Sprite[] kill4;
    public Sprite[] kill5;
    public Sprite[] Current;
    public int AnimFlame = 10;
    public bool flag;
    public bool CStopFlag;
    public int count;
    public void Start()
    {
        ResetColor(0);
        Current = new Sprite[10];
        flag = false;
        ResetSize(1);
        CStopFlag = true;
    }
    IEnumerator kill()//움직임애니매이션재생
    {
        transform.GetComponent<Image>().sprite = Current[0];
        ResetColor(1);
        for (int i = 1; i <= AnimFlame; ++i)
        {           
            ResetSize(i * 70);           
            yield return new WaitForSeconds(0.005f);
        }
        for (int i = 0; i < AnimFlame; ++i)
        {
            
            if (flag) break;
            transform.GetComponent<Image>().sprite = Current[i];
            yield return new WaitForSeconds(0.1f);

        }

        ResetSize(0);
        CStopFlag = true;
    }
    
    public void ResetSize(int n)
    {
        transform.localScale = new Vector3(1, 0.5f, 1) * n;
    }
    public void ResetColor(int n)
    {
        Color c;
        c.a = n;
        c.b = 1;
        c.g = 1;
        c.r = 1;
        transform.GetComponent<Image>().color = c;
    }
    public void Init_Img(int KomboCount)
    {             
        count = KomboCount;
        if (count == 0) InitCurrent(kill1);
        else if (count == 1) InitCurrent(kill2);
        else if (count == 2) InitCurrent(kill3);
        else if (count == 3) InitCurrent(kill4);
        else if (count == 4) InitCurrent(kill5);
       
    }
    public void InitCurrent(Sprite[] array)
    {
        for (int i = 0; i < AnimFlame; ++i)
        {
            Current[i] = array[i];
        }
        ResetSize(0);

        StopCoroutine("kill");
        StartCoroutine("kill");
        
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        
    }
    
} 
