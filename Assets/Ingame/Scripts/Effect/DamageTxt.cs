using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTxt : MonoBehaviour
{
    public Text dtxt;

    float moveSpeed;
    float alphaSpeed;
    Color alpha;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        alphaSpeed = 1f;
        alpha = dtxt.color;
        transform.Translate(RandomPosition(), Space.World);
        Invoke("DelTxt", 2f);
    }

    // Update is called once per frame
    void Update()
    {
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
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
    
        return new Vector3(x, y, 1f).normalized;
    }
}
