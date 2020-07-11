using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActivitySlot : MonoBehaviour
         , IDragHandler
         , IEndDragHandler
{
    [SerializeField]
    private Activity activity;

    private Text Name;
    private RectTransform rectTransform;
    private Vector2 originalPos;
    private float yOffset = 60;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        Name = GetComponentInChildren<Text>();
        Name.text = activity.GetName();

        originalPos = rectTransform.anchoredPosition;

    }


    //Drags to the slot
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = originalPos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EmptySlot>().SetActivity(activity);
    }
}
