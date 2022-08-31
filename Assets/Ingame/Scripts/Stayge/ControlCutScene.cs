using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControlCutScene : MonoBehaviour
{
    public GameObject QM;
    public VideoPlayer VP;

    float timer;
    public AudioSource Music;
    public GameObject PlayBtn;
    void Start()
    {
        QM = GameObject.FindGameObjectWithTag("QM");
        timer = 0f;
        Music.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        if (!VP.isPlaying && timer >= 2f)
        {
            QM.GetComponent<QuestManager>().IngameLevel++;
            Music.Play();
            VP.Stop();
            PlayBtn.GetComponent<GoIntro>().OnClick();
            gameObject.SetActive(false);
            
        }
    }
}
