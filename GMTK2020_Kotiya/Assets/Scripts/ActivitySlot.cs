using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//the slots representing each individual activity
public class ActivitySlot : MonoBehaviour
         , IDragHandler
         , IEndDragHandler
     , IPointerEnterHandler
     , IPointerExitHandler
     , IPointerClickHandler
{
    [SerializeField]
    private Activity activity;
    private Image image;
    private RectTransform rectTransform;
    private Vector2 originalPos, newPos;
    private bool overlap = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        image = GetComponent<Image>();
        image.sprite = activity.GetImage();

        originalPos = rectTransform.anchoredPosition;

    }

    public void ResetTransform()
    {
        rectTransform.anchoredPosition = originalPos;
        overlap = false;
    }

    //Drags to the slot
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!overlap) rectTransform.anchoredPosition = originalPos;
        else transform.position = newPos;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(0.3f, 0.3f, 0.3f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GameSoundManager.Instance.PlayClick();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EmptySlot>().IsClear())
        {
            overlap = true;
            collision.GetComponent<EmptySlot>().SetActivity(activity);
            BeginDay.Instance.CheckSlots();
            newPos = collision.GetComponent<RectTransform>().position;
        }
        else overlap = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        overlap = false;
        if (collision.GetComponent<EmptySlot>().GetActivity() == activity)
            collision.GetComponent<EmptySlot>().ClearActivity();
    }

    
}
