using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControlCutScene : MonoBehaviour
{
    public GameObject QM;
    public VideoPlayer VP;

    float timer;

    void Start()
    {
        QM = GameObject.FindGameObjectWithTag("QM");
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (!VP.isPlaying && timer >= 2f)
        {
            VP.Stop();
            gameObject.SetActive(false);
        }
    }
}
