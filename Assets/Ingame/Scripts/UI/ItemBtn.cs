using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemBtn : UiButton
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

    public bool TutorialItem = false; //y

    int ItemNumber;
    float timer;

    void Start()
    {
        img = Image.GetComponent<Image>();
        img.sprite = Defualt;
        ItemNumber = 0;
        timer = 0f;
    }

    private void Update()
    {
        if (img.sprite != Defualt) // 아이템 먹었을 때 푸른색으로 깜빡거리게
        {
            timer += Time.deltaTime;

            if (timer > 1f)
            {
                Effect();
                timer = 0f;
            }
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (img.sprite != Defualt)  // 아이템 버튼 이미지가 기본 상태가 아니면, 즉 아이템을 먹었으면
        {
            img.sprite = Defualt;
            Effect();

            TutorialItem = true;
            if (ItemNumber == 1)  // 폭탄
            {
                var a = Instantiate(Bombs, Player.transform.position, Quaternion.Euler(0f, 0f, 0f));
                a.GetComponent<Bombs>().Active = true;
            }
            else if (ItemNumber == 2)  // 얼음
            {
                var a = Instantiate(Preeze, Player.transform.position, Quaternion.Euler(0f, 0f, 0f));
            }
            else if (ItemNumber == 3)  // 쉴드
                Player.GetComponent<Player>().CreatBarriar();

            ItemNumber = 0;
        }
    }

    public void UseItem()
    {
        if (img.sprite != Defualt) // 아이템 버튼 이미지가 기본 상태가 아니면, 즉 아이템을 먹었으면
        {
            img.sprite = Defualt;

            if (ItemNumber == 1)  // 폭탄
            {
                var a = Instantiate(Bombs, Player.transform.position, Quaternion.Euler(0f, 0f, 0f));
                a.GetComponent<Bombs>().Active = true;
            }
            else if (ItemNumber == 2)  // 얼음
            {
                var a = Instantiate(Preeze, Player.transform.position, Quaternion.Euler(0f, 0f, 0f));
            }
            else if (ItemNumber == 3)  // 쉴드
            {
                Player.GetComponent<Player>().CreatBarriar();
            }

            ItemNumber = 0;
        }
    }

    public void ChangeImage(int i) // 플레이어가 아이템 먹었을 때 호출
    {
        // if (img.sprite == Defualt) {
        ItemNumber = i;

        if (i == 1) img.sprite = ItemBomb;        // 폭탄
        else if (i == 2) img.sprite = ItemIce;    // 얼음
        else if (i == 3) img.sprite = ItemShield; // 쉴드
        // }
    }
}