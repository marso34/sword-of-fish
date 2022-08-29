using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonE : MonoBehaviour
{
    Image img;
    RectTransform rect;
    RectTransform rect2;
   
    public Color alpha;
    public float size;

    void Start()
    {
        img = transform.GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        alpha = img.color;
        img.color = Color.clear;
        
        size = transform.localScale.y;

        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        SetSize();
        size = Mathf.Lerp(size, 3f, Time.deltaTime * 2f);
        alpha.a = Mathf.Lerp(alpha.a, 0f, Time.deltaTime * 4f);
        transform.localScale = new Vector3(size, size, 1f);
        img.color = alpha;
    }

    public void Set(GameObject Button)
    {
        rect2 = Button.GetComponent<RectTransform>();
        transform.SetAsFirstSibling();
    }

    void SetSize()
    {
        rect.anchoredPosition = rect2.anchoredPosition;
        rect.sizeDelta = rect2.sizeDelta;
    }
}
