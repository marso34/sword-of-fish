using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiButton : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    public GameObject click;

    public void Effect()
    {
        var c = Instantiate(click, transform.position, Quaternion.Euler(0f, 0f, 0f));
        c.transform.SetParent(transform.parent, false);
        c.transform.GetComponent<ButtonE>().Set(gameObject);
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        // 자식 버튼에서 구현
    }
}