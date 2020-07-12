using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Logic for the empty slot where the player sets each activity
public class EmptySlot : MonoBehaviour
{
    private Activity activity;

    public void SetEffective(bool temp)
    {
        activity.SetEffect(temp);
    }

    public void ReplaceActivity(Activity newActivity)
    {
        activity = newActivity;
    }

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
        if (activity.StillEffective()) return activity.GetMessage();
        else return activity.GetChangedMessage();
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
