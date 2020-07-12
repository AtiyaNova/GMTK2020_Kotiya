﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Atiya Nova 2020
//Handles the logic for the planner menu
public class PlannerDrag : MonoBehaviour
     , IDragHandler
     , IEndDragHandler
    , IBeginDragHandler
{
    float yPos = -200f, xZero = 83f, xLimit = 1200f, offset = 350f;
    private RectTransform rectTransform;

    [SerializeField]
    private GameObject image;

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameSoundManager.Instance.BookDrag();
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

    public void ResetPosition()
    {
        rectTransform.anchoredPosition = new Vector2(xZero, yPos);
    }
    
    public void SetPlanner(bool temp)
    {
        GetComponent<Collider2D>().enabled = temp;
        image.SetActive(temp);
    }
}
