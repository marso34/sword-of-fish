using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Buster : MonoBehaviour ,IPointerDownHandler, IPointerUpHandler
{
    public GameObject Player;
    public GameObject BubbleSound;    


    public void OnPointerDown(PointerEventData eventData)
    {
        Player.GetComponent<PlayerScript>().BusterFlag = true;
        var bubbleSound = Instantiate(BubbleSound, transform.position, Quaternion.Euler(0, 0, 0));
        bubbleSound.transform.parent = transform;
        
        Debug.Log("부스터발동");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Player.GetComponent<PlayerScript>().BusterFlag = false;
        if (GameObject.FindGameObjectWithTag("BS") != null)
            Destroy(GameObject.FindGameObjectWithTag("BS"));
        
       
    }
}


