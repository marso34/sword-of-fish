using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillBtn : MonoBehaviour, IPointerDownHandler
{
    public GameObject Player;
    public GameObject Image;
    public Image SkillFill;
    
    bool SkillFlag; // 스킬 사용 가능하면 true
    float timer;
    float WaitTime;

    public void Start()
    {
        SkillFill = Image.GetComponent<Image>();
        SkillFlag = false;
        timer = 0f;
        WaitTime = 6f;
    }

    public void Update()
    {
        SkillFill.fillAmount = timer / WaitTime;

        if (!SkillFlag && Player.GetComponent<PlayerScript>().FishNumber != 0) 
        {
            if (!Player.GetComponent<PlayerScript>().SkillFlag) // 스킬 지속시간이 있는 경우에만 SkillFlag == true
                timer += Time.deltaTime; 
            else
                timer -= Time.deltaTime * 2;

            if (timer >= WaitTime)
            {
                SkillFlag = true;
                // SkillFill.color = new Color(112/255f, 219/255f, 1f);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (SkillFlag && Player.GetComponent<PlayerScript>().MyBody.tag != "NotBody")
        {
            Player.GetComponent<PlayerScript>().PlaySkill();
            SkillFlag = false;

            if (!Player.GetComponent<PlayerScript>().SkillFlag)
                timer = 0f;

            Debug.Log("스킬 발동");
        }
    }
    public void UseSkill()
    {
        if (SkillFlag && Player.GetComponent<PlayerScript>().MyBody.tag != "NotBody")
        {
            Player.GetComponent<PlayerScript>().PlaySkill();
            SkillFlag = false;

            if (!Player.GetComponent<PlayerScript>().SkillFlag)
                timer = 0f;

            Debug.Log("스킬 발동");
        }
    }
}
