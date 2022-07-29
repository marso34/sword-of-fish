using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Buster : MonoBehaviour ,IPointerDownHandler, IPointerUpHandler
{
    public GameObject Player;
    public Image img;
    public GameObject BubbleSound;    
    public Color color;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        img = transform.GetComponent<Image>();
        color = transform.GetComponent<Image>().color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Player.GetComponent<PlayerScript>().BusterFlag = true;
        var bubbleSound = Instantiate(BubbleSound, transform.position, Quaternion.Euler(0, 0, 0));
        bubbleSound.transform.parent = transform;
        Color color = new Color(50f/255f,190f/255f,255f/255f,255f/255f);
        transform.GetComponent<Image>().color = color;
        Debug.Log("부스터발동");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Player.GetComponent<PlayerScript>().BusterFlag = false;
         color = new Color(255f/255f,255f/255f,255f/255f,255f/255f);
        if (GameObject.FindGameObjectWithTag("BS") != null)
            Destroy(GameObject.FindGameObjectWithTag("BS"));
        transform.GetComponent<Image>().color = color;
        
       
    }
}


