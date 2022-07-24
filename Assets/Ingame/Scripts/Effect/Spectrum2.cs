using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum2 : MonoBehaviour
{
    public GameObject Player;
    SpriteRenderer Skin;
    Color alpha;

    float temp;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Skin = transform.GetComponent<SpriteRenderer>();
        imgInit();
        dirInit();
        
        Destroy(gameObject, 0.7f);
    }

    private void Update()
    {
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * 5f);
        Skin.color = alpha;
    }

    void imgInit()
    {
        Skin.sprite = Player.transform.GetComponent<PlayerScript>().MFish.sprite;
        alpha = Skin.color;
        Skin.color = new Color(0,0,0,0);
    }

    void dirInit()
    {
        transform.eulerAngles = new Vector3(0, 0, Player.transform.eulerAngles.z + 90f);
        if (Player.transform.localScale.x < 0)
            transform.localScale = new Vector3(-Player.transform.localScale.x, -Player.transform.localScale.y, Player.transform.localScale.z);
        else 
            transform.localScale = new Vector3(Player.transform.localScale.x, Player.transform.localScale.y, Player.transform.localScale.z);
    }
}
