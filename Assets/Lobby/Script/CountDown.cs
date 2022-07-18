using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour
{
    public GameObject CountText;
    public GameObject ResBtn;
    public float setTime = 5.0f;
    public Text countdownText;

    public void Start()
    {
        countdownText.text = setTime.ToString();

    }

    // Update is called once per frame
    public void Update()
    {
        if (setTime > 1)
            setTime -= Time.deltaTime;

        else if (setTime <= 1)
        {
            CountText.SetActive(false);
            HideBtn();
        }
        countdownText.text = Mathf.Round(setTime).ToString();
    }

    public void HideBtn()
    {
        ResBtn.SetActive(false);
    }

    /*
    public float Timer = 5.0f;
    public float thisTime;
    public Text countdown;
    public void Start()
    {
        countdown.text = Timer.ToString();

    }
    public void Update()
    {
        if (Timer == 0f)
        {
           Time.timeScale = 0f;
        }
        else if(Timer <= 5)
        {
            Timer -= 1;
        }
        countdown.text = Mathf.Round(Timer).ToString();
    }
    */
}
