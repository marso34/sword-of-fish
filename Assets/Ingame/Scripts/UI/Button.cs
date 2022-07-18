using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    int index;
    public GameObject LobbyPlayer;
    public void ClickKnifeBtn()
    {
        index = int.Parse(transform.tag);
        LobbyPlayer.GetComponent<LobbyPlayer>().KnifeChange(index);
        Debug.Log("change" + index + transform.tag + int.Parse(transform.tag));

    }
    public void ClickBodyBtn()
    {
        index = int.Parse(transform.tag);
        LobbyPlayer.GetComponent<LobbyPlayer>().BodyChange(index);
        Debug.Log("change" + index + transform.tag + int.Parse(transform.tag) );
    }
}
