using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillBtn : UiButton
{
    public GameObject Player;
    public GameObject Image;
    public Image SkillFill;

    bool SkillFlag; // 스킬 사용 가능하면 true
    float SkillGauge; // 현재 스킬 게이지
    float FullGauge; // 스킬 게이지 가득 찼는지

    public void Start()
    {
        SkillFill = Image.GetComponent<Image>();
        SkillFlag = false;
        SkillGauge = 0f;
        FullGauge = 6f;
    }

    public void Update()
    {
        SkillFill.fillAmount = SkillGauge / FullGauge;

        if (!SkillFlag && Player.GetComponent<PlayerScript>().FishNumber != 0)
        {
            if (!Player.GetComponent<PlayerScript>().SkillFlag) // 스킬 지속시간이 있는 경우에만 SkillFlag == true
                SkillGauge += Time.deltaTime;
            else
                SkillGauge -= Time.deltaTime * 2;

            if (SkillGauge >= FullGauge)
                SkillFlag = true;
            // SkillFill.color = new Color(112/255f, 219/255f, 1f);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (SkillFlag && Player.GetComponent<PlayerScript>().MyBody.tag != "NotBody") // 플레이어가 not일 때는 스킬 사용 못 하게
        {
            Effect();
            if (Player.GetComponent<PlayerScript>().FishNumber == 1 && Player.GetComponent<PlayerScript>().StateMoveFlag_) return;
            else
            {
                Player.GetComponent<PlayerScript>().PlaySkill();
                SkillFlag = false;

                if (!Player.GetComponent<PlayerScript>().SkillFlag) // 스킬 지속 시간이 없는 경우
                    SkillGauge = 0f;

                Debug.Log("스킬 발동");
            }
        }
    }
    public void UseSkill()
    {
        if (SkillFlag && Player.GetComponent<PlayerScript>().MyBody.tag != "NotBody")  // 플레이어가 not일 때는 스킬 사용 못 하게
        {
            if (Player.GetComponent<PlayerScript>().FishNumber == 1 && Player.GetComponent<PlayerScript>().StateMoveFlag_) return;
            else
            {
                Player.GetComponent<PlayerScript>().PlaySkill();
                SkillFlag = false;

                if (!Player.GetComponent<PlayerScript>().SkillFlag)  // 스킬 지속 시간이 없는 경우
                    SkillGauge = 0f;

                Debug.Log("스킬 발동");
            }
        }
    }
}
