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
    Crypture FirstCrypture;

    [SerializeField, Range(10f, 288f)]
    float m_leverRange;
    Vector2 m_vtInputVector;
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
        //Debug.Log("Begin");
        ControlJoystickLever(eventData);
        m_bInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag");
        ControlJoystickLever(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End");
        m_bInput = false;
        m_lever.anchoredPosition = Vector2.zero;
    }

    void ControlJoystickLever(PointerEventData eventData)
    {
        Vector2 inputDir = new Vector2(eventData.position.x - m_rectTransform.position.x, eventData.position.y - m_rectTransform.position.y) ;
        Vector2 clampedDir = inputDir.magnitude < m_leverRange ? inputDir : inputDir.normalized * m_leverRange;
        m_lever.anchoredPosition = clampedDir;
        m_vtInputVector = clampedDir / m_leverRange;
    }

    void InputControlVector()
    {
        //Debug.Log($"{m_vtInputVector.x}, {m_vtInputVector.y}");
        FirstCrypture.SetDirection(m_vtInputVector);
    }
}
