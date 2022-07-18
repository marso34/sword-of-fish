using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JMove : MonoBehaviour,IPointerDownHandler, IPointerUpHandler, IDragHandler{

    RectTransform rect; //joystick background object
    Vector2 touch = Vector2.zero;// normalized mounse touch position from canvuce angle 
    public RectTransform handle;// joystick handle object
    float widthHalf;// joystick handle can't out from rect due to this var

    public JoystickValue value; //it is moved object by handle

    private void Start()
    {
        rect = GetComponent<RectTransform>(); 
        widthHalf = rect.sizeDelta.x * 0.5f;
    }
    public void OnDrag(PointerEventData eventData)//touch and moving mouce   1280 * 720   현재 해상도 x * y    x / 1280  y720 
    {
        float x_  = (float)Screen.width / 1280f; // 기기 너비 저장
        float y_= (float)Screen.height / 720f;
       // RectTransform z = new RectTransform();
        //z.position = new Vector2(x_,y_);
       // Vector2 Clean = (eventData.position - rect.anchoredPosition);
        //Vector2 Clean;
        Vector2 Clean =new Vector2((eventData.position.x  * x_)- (rect.position.x * x_),(eventData.position.y * y_) - (rect.position.y* y_)) / (widthHalf);//- new Vector2(rect.anchoredPosition.x * x_,rect.anchoredPosition.y * y_));
        //touch = Clean; /// (widthHalf); // touch point sort from canverce. if not this code , touch point and handle touch value is not same   1920 1080 => 145 130  ;    2160  1080 =>170 140    2560 1440=>330 300    2960 1440 => 470 390   ->(new Vector2(eventData.position.x  * x_,eventData.position.y * y_) - new Vector2(rect.anchoredPosition.x * x_,rect.anchoredPosition.y * y_)) - new Vector2(rect.transform.position.x,rect.transform.position.y) ;
        float C = 220 * y_ -220;                //100 100   
        touch = Clean;//(eventData.position -rect.anchoredPosition) - new Vector2(72f,75f); // touch point sort from canverce. if not this code , touch point and handle touch value is not same
        if(touch.magnitude > 1) 
            touch = touch.normalized;// joystick handle can't out from rect due to this code
        value.joyTouch = touch.normalized; // moved object by handle put in touch point
        handle.anchoredPosition = touch * widthHalf;// it's show moved handle 
    }
    public void OnPointerDown(PointerEventData eventData) //only touch starting moment
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)//only touch outing moment
    {
     
        
        // handle.anchoredPosition = Vector2.zero;// handle is moved 0,0 point
        // value.joyTouch = Vector2.zero;// stop moving moved object by handle object
      

    }
}
