using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonE : MonoBehaviour
{
    RectTransform rect;
   
    public Color alpha;
    public float size;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        alpha = transform.GetComponent<Image>().color;
        size = transform.localScale.y;

        rect.anchoredPosition = new Vector3(0, 0, 0);
        rect.sizeDelta = transform.parent.GetComponent<RectTransform>().sizeDelta;
        
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        size = Mathf.Lerp(size, 3f, Time.deltaTime * 2f);
        alpha.a = Mathf.Lerp(alpha.a, 0f, Time.deltaTime * 4f);
        transform.localScale = new Vector3(size, size, 1f);
        transform.GetComponent<Image>().color = alpha;
    }
}
