using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// 简易版的摇杆
/// </summary>
public class TJoystick : MonoBehaviour ,IPointerDownHandler,IDragHandler,IPointerUpHandler{

    public Image bg;
    public Image knob;

    public float radius;

    public Vector2 asix;

    public Vector2 orgin;
    public Vector2 pos;
    /// <summary>
    /// 是否仅仅需要方向
    /// </summary>
    public bool isPureDirection;

    public event Action OnUpEvent;
    public event Action OnDragEvent;

    private RectTransform knobRect;
    private Canvas canvas;
	// Use this for initialization
	void Start () {
        canvas = this.GetComponentInParent<Canvas>();
        //矩形 x y应该一样大小才对
        radius = bg.GetComponent<RectTransform>().sizeDelta.x/2 * canvas.scaleFactor;
        orgin = knob.GetComponent<RectTransform>().position;
        knobRect = knob.GetComponent<RectTransform>();
        
	}
	
    public void OnDrag(PointerEventData eventData)
    {
        if (bg == null || knob == null)
        {
            Debug.Log("摇杆未赋值");
            return;
        }

        float dis = Vector2.Distance(eventData.position, orgin);

        Vector2 direction = eventData.position - orgin;
        Debug.Log(radius * direction.normalized);
        if (dis > radius)
            knobRect.position = orgin + radius * direction.normalized;
        else
            knobRect.position = eventData.position;

        asix = direction.normalized;
        //如果还需要长度
        if (!isPureDirection)
        {
            dis = Vector2.Distance(knobRect.position, orgin);
            float len = dis / radius;
            asix *= len;
        }

        if (OnDragEvent != null)
            OnDragEvent();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        knobRect.position = orgin;
        asix = Vector2.zero;

        if (OnUpEvent != null)
            OnUpEvent();
    }
}
