using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Atiya Nova 2020
//Used to drag the planner into view
public class PlannerDrag : MonoBehaviour
     , IDragHandler
     , IEndDragHandler
     , IPointerEnterHandler
     , IPointerExitHandler
{
    float yPos = -40f, xPos = 0, xZero = 74f, xLimit = 800f, offset = 350f;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    //Drags the notebook in and out of view
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = new Vector2(eventData.position.x, yPos);
    }

    //Snaps the position to place
    public void OnEndDrag(PointerEventData eventData)
    {
        float newX = eventData.position.x;

        if (newX <= (xZero+offset))
        {
            rectTransform.anchoredPosition = new Vector2(xZero, yPos);
        }
        else if (newX > (xZero+offset))
        {
            rectTransform.anchoredPosition = new Vector2(xLimit, yPos);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      // highlight 1
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      // highlight no
    }
}
