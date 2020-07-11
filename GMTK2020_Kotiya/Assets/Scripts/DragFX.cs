using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragFX : MonoBehaviour
     , IPointerEnterHandler
     , IPointerExitHandler
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(0.4f, 0.4f, 0.4f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

}
