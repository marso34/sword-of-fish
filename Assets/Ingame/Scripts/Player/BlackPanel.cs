using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackPanel : MonoBehaviour
{
    public bool flag;
    public Image S;
    public Color C;
    // Start is called before the first frame update
    void Start()
    {
        S = GetComponent<Image>();
        C = Color.clear;
        S.color = C;
    }

    // Update is called once per frame
   public void OnPanel(){
        S.color = Color.white;
   }
   public void QuickOffPanel(){
        S.color = Color.clear;
   }
   public void OffPanel(){
        StartCoroutine("Die");
   }
    IEnumerator Die() //Ï£ΩÏùå ?ï†?ãà
    {
        for (int i = 0; i < 50; ++i)
        {
            
            //if (Life) break;
            ShowDieAnim(i);

            yield return new WaitForSeconds(0.01f);
        }
    }
    public void ShowDieAnim(int index)//Ï£ΩÏóà?ùÑ?ïå ?ï†?ãàÎß§Ïù¥?Öò ?û¨?Éù?ï®?àò
    {

        if (S.color.a > 0)
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
}
