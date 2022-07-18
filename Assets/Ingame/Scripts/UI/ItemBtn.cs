using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemBtn : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Image;
    public GameObject Bombs;
    public ParticleSystem Preeze;


    public Image img;
    public Sprite Defualt;
    public Sprite ItemBomb;
    public Sprite ItemIce;
    public Sprite ItemShield;

    int ItemNumber;

    void Start()
    {
        img = Image.GetComponent<Image>();
        img.sprite = Defualt;
        ItemNumber = 0;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
 

    public void OnPointerDown(PointerEventData eventData)
    {
        if (img.sprite != Defualt)
        {
            img.sprite = Defualt;

            if (ItemNumber == 1)  // ��ź
            {
                var a = Instantiate(Bombs, Player.transform.position, Quaternion.Euler(0f, 0f, 0f));
                a.GetComponent<Bombs>().Active = true;
            }
            else if (ItemNumber == 2)  // ����
            {
                var a = Instantiate(Preeze, Player.transform.position, Quaternion.Euler(0f, 0f, 0f));
            }
            else if (ItemNumber == 3)  // ����
                Player.GetComponent<Player>().CreatBarriar();
            

            ItemNumber = 0;
        }
    }

    public void UseItem()
    {
        if (img.sprite != Defualt)
        {
            img.sprite = Defualt;

            if (ItemNumber == 1)  // ��ź
            {
                var a = Instantiate(Bombs, Player.transform.position, Quaternion.Euler(0f, 0f, 0f));
                a.GetComponent<Bombs>().Active = true;
            }
            else if (ItemNumber == 2)  // ����
            {
                var a = Instantiate(Preeze, Player.transform.position, Quaternion.Euler(0f, 0f, 0f));
            }
            else if (ItemNumber == 3)  // ����
            {
                Player.GetComponent<Player>().CreatBarriar();
            }

            ItemNumber = 0;
        }
    }

    public void ChangeImage(int i)
    {
        // if (img.sprite == Defualt) {
        ItemNumber = i;

        if (i == 1) img.sprite = ItemBomb;
        else if (i == 2) img.sprite = ItemIce;
        else if (i == 3) img.sprite = ItemShield;
        // }
    }
}