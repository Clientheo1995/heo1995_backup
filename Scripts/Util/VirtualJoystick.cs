using System;
using UnityEngine;
using UnityEngine.EventSystems;
//https://wergia.tistory.com/231
public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    RectTransform m_lever;
    RectTransform m_rectTransform;

    [SerializeField]
    Character FirstCrypture;

    Vector2 lastPos;
    Vector2 currentPos;
    bool m_bInput;

    void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (m_bInput)
        {
            InputControlVector();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_lever.gameObject.SetActive(true);
        lastPos = eventData.position;
        ControlJoystickLever(eventData);
        m_bInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_bInput = false;
        m_lever.gameObject.SetActive(false);
        FirstCrypture.SetDirection(Vector2.zero);
        
    }

    void ControlJoystickLever(PointerEventData eventData)
    {
        currentPos = eventData.position;

        m_lever.position = currentPos;

        Vector2 pos = currentPos - lastPos;
        currentPos = pos.normalized;
    }

    void InputControlVector()
    {
        FirstCrypture.SetDirection(currentPos);
    }
}
