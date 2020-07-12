using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Logic for the empty slot where the player sets each activity
public class EmptySlot : MonoBehaviour
{
    private Activity activity;

    public void SetActivity(Activity newActivity)
    {
        activity = newActivity;
        BeginDay.Instance.CheckSlots();
    }

    public void ClearActivity()
    {
        activity = null;
        BeginDay.Instance.CheckSlots();
    }

    public string DisplayMessage()
    {
        return activity.GetMessage();
    }

    public Activity GetActivity()
    {
        return activity;
    }

    public bool IsClear()
    {
        return activity == null ? true : false;
    }
}
