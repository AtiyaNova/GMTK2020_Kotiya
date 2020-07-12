using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

//this is to switch between the tutorial and gameplay pages
public class Tab : MonoBehaviour
     , IPointerEnterHandler
     , IPointerExitHandler
    , IPointerClickHandler
{
    private Image image;
    private Color originalColor;
    public GameObject thisPage, otherPage;

    private void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(0.4f, 0.4f, 0.4f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = originalColor;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        thisPage.SetActive(true);
        otherPage.SetActive(false);
    }
}
