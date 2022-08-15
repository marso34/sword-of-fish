using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Buster : UiButton, IPointerUpHandler
{
    public GameObject Player;
    public Image img;
    public GameObject BubbleSound;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        img = transform.GetComponent<Image>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Effect();
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


