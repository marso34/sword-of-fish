using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTxt : MonoBehaviour
{
    public Text dtxt;
    public GameObject Player;
    float moveSpeed; // 텍스트 이동 속도
    float alphaSpeed; // 알파값(투명도) 변화 속도
    Color alpha;
    public GameObject QM;
    public Gradient ComboColor;
    [Range(0, 1)]
    public float C;

    // Start is called before the first frame update
    void Start()
    {
        QM = GameObject.FindGameObjectWithTag("QM");
        if (GameObject.FindGameObjectWithTag("Player") != null)
            Player = GameObject.FindGameObjectWithTag("Player");
        else Player = null;

        moveSpeed = 1f;
        alphaSpeed = 0.5f;
        alpha = dtxt.color;
        transform.Translate(RandomPosition(), Space.World); // 처음 생성 위치를 기준으로 랜덤한 위치로 이동
        QM.GetComponent<QuestManager>().Score += ++Player.GetComponent<PlayerScript>().KomBoCount;
        C = Player.GetComponent<PlayerScript>().KomBoCount / 100f;

        Debug.Log("색상 : " + C);

        if (C >= 1f)
            C = 1f;

        alpha = ComboColor.Evaluate(C);
        dtxt.text = Player.GetComponent<PlayerScript>().KomBoCount.ToString();

        Invoke("DelTxt", 2f);
    }

    // Update is called once per frame
    void Update() // 피격시 데미지 텍스트로 띄우고 위로 올림
    {
        moveSpeed = Mathf.Lerp(moveSpeed, 0, Time.deltaTime);
        alphaSpeed = Mathf.Lerp(alphaSpeed, 2f, Time.deltaTime * 2f);

        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        dtxt.color = alpha;
    }

    void DelTxt()
    {
        Destroy(gameObject);
    }

    Vector3 RandomPosition()
    {
        float x = Random.Range(0, 1f);
        float y = Random.Range(0, 1f);

        return new Vector3(x, y, 1f).normalized;
    }
}
