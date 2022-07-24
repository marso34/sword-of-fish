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
        float x_  = (float)Screen.width / 1920f; // 기준 해상도에 따른 현재 해상도 가로 비율
        float y_= (float)Screen.height / 1080f;  // 기준 해상도에 따른 현재 해상도 세로 비율
        Vector2 primeVector =  (eventData.position - new Vector2(rect.position.x,rect.position.y)); // 기준 해상도에 맞는 조이스틱 벡터의 크기, 즉 원래 벡터 크기
        float RatioC = (new Vector2(x_, y_)).magnitude / (new Vector2(1, 1)).magnitude; // 조이스틱 벡터의 크기 비율 (기준 해상도 벡터 크기를 1로), Clean으로도 계산 가능하지만 코드 더러워짐, 어떻게 보면 화면 해상도 가로세로의 선형보간을 벡터로 구한 것
        
        Vector2 Clean = new Vector2((eventData.position.x  * x_)- (rect.position.x * x_), (eventData.position.y * y_) - (rect.position.y* y_)); // / widthHalf 제거. 어차피 normalized해서 사용, touch에서 / widthHalf
   
        touch = Clean.normalized * primeVector.magnitude / (widthHalf * RatioC); // Clean의 방향만 가져오고 원래 벡터 크기로 변경. 
                                                                              // widthHarf도 기준 해상도 비율에 맞게 보정.
        

        if(touch.magnitude > 1) 
            touch = touch.normalized;// joystick handle can't out from rect due to this code
        value.joyTouch = touch.normalized; // moved object by handle put in touch point
        handle.anchoredPosition = touch * widthHalf;// it's show moved handle 
    }
    public void OnPointerDown(PointerEventData eventData) //only touch starting moment
    {
       
        OnDrag(eventData);
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    public void OnPointerUp(PointerEventData eventData)//only touch outing moment
    {
     
        
        // handle.anchoredPosition = Vector2.zero;// handle is moved 0,0 point
        // value.joyTouch = Vector2.zero;// stop moving moved object by handle object
      

    }
}
