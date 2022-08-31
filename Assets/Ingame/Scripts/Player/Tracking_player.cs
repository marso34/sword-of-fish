using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking_player : MonoBehaviour
{
    public GameObject[] CameraWall; 
    public Transform target;// Tracking object preferp   
    float shake;
    public float z = -19;
    float bustValue_ = 1;
    bool dieFlag = false;
    bool StartFlag;
    public float Speed;
    Vector3 orgposition;
    Rigidbody2D RB;
    private void Start()
    {
        CameraWall = new GameObject[4];
        StartFlag = true;
        shake = 0;
        target = transform;
        RB = transform.GetComponent<Rigidbody2D>();
        z = -19;
        Speed = 2f;
    }

    public void SetResolution()
    {
        int setWidth = 1280; // 사용자 설정 너비
        int setHeight = 720; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(Screen.width, Screen.width * setWidth / setHeight, true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }

    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    ///
    void Update()
    {
        CameraWall = GameObject.FindGameObjectsWithTag("Finish");

        if (target != null && (target.tag == "Player" || target.tag == "Victem"))
        {
            if (StartFlag)
            {
                z = -19;
                transform.position = new Vector3(target.position.x, target.position.y, z);
                StartFlag = false;
                transform.GetComponent<Camera>().fieldOfView = 22;
            }

            var tenp = transform.GetComponent<Camera>().fieldOfView;

            var dir = target.GetComponent<Player>().MyBody.transform.position - transform.position;
            RB.velocity = dir * Speed;//.normalized * target.GetComponent<PlayerScript>().Speed * 4f;

            if (transform.GetComponent<Camera>().fieldOfView < 28)
            {
                
                transform.GetComponent<Camera>().fieldOfView = 22 + target.transform.localScale.y * 3f;
                
            }
            else transform.GetComponent<Camera>().fieldOfView = 28;



            // CameraWall[1].transform.Translate(new Vector3(0, (transform.GetComponent<Camera>().fieldOfView - tenp)/2, 0));

            // transform.position = target.GetComponent<PlayerScript>().MyBody.transform.position + new Vector3(0f, 0f, z);//Tracking object
            // RaycastHit2D ray2 = Physics2D.Raycast(transform.position, (new Vector3(0,1.1f,0) - transform.position).normalized, 1000f, LayerMask.GetMask("CameraWall"));
            // if (ray2.collider != null)
            // {
            //     transform.position = new Vector3(ray2.point.x + shake, ray2.point.y + shake,z - shake);              
            // }

        }
        else
        {
            StartFlag = true;
            transform.position = transform.position;// "Null instence" error depance
            target = null;
            dieFlag = false;
            transform.GetComponent<Camera>().fieldOfView = 21f;
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        //SetResolution();

        if (dieFlag && z < -11) z += 1;
    }
    public void target_set(GameObject player)
    {
        target = player.transform;

    }
    public void CrushCam()
    {
        StartCoroutine("CamAction");
    }
    IEnumerator CamAction()//카메라 흔들기.
    {
        orgposition = transform.position;
        //shake = (0.05f + (Mathf.Pow(2, target.localScale.y) / 100)) * 2;
        shake = 0.5f;

        transform.position = new Vector3(transform.position.x + Random.Range(-shake,shake),transform.position.y + Random.Range(-shake, shake),transform.position.z + Random.Range(-shake, shake));

        yield return new WaitForSecondsRealtime(0.05f); //+(Mathf.Pow(2, target.localScale.y) / 100)
        transform.position = new Vector3(transform.position.x + Random.Range(-shake, shake), transform.position.y + Random.Range(-shake, shake), transform.position.z + Random.Range(-shake, shake));
        yield return new WaitForSecondsRealtime(0.05f); //+(Mathf.Pow(2, target.localScale.y) / 100)
        //shake = 0;
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
    public void BustValue(bool value)
    {
        if (value)
            bustValue_ = 0.5f;
        else bustValue_ = 1.5f;
    }
    public void DieCamAction()
    {
        dieFlag = true;
    }
}
