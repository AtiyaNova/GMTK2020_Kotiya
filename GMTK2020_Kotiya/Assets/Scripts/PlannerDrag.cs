using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Atiya Nova 2020
//Used to drag the planner into view
public class PlannerDrag : MonoBehaviour
     , IDragHandler
     , IEndDragHandler
     , IPointerEnterHandler
     , IPointerExitHandler
{
    float yPos = -200f, xPos = 0, xZero = 83f, xLimit = 1200f, offset = 350f;
    private RectTransform rectTransform;

    [SerializeField]
    private Image image;

    //Singleton
    public static PlannerDrag Instance;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    //Drags the notebook in and out of view
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.position.x < 1000f)
        rectTransform.anchoredPosition = new Vector2(eventData.position.x, yPos);
    }

    //Snaps the position to place
    public void OnEndDrag(PointerEventData eventData)
    {
            float newX = eventData.position.x;

            if (newX <= (xZero + offset))
            {
                rectTransform.anchoredPosition = new Vector2(xZero, yPos);
            }
            else if (newX > (xZero + offset))
            {
                rectTransform.anchoredPosition = new Vector2(xLimit, yPos);
            }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(0.4f,0.4f,0.4f,1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void ResetPosition()
    {
        rectTransform.anchoredPosition = new Vector2(xZero, yPos);
    }
    
    public void SetPlanner(bool temp)
    {
        GetComponent<Collider2D>().enabled = temp;
        image.gameObject.SetActive(temp);
    }
}
