using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginDay : MonoBehaviour
{
    [SerializeField]
    private List<EmptySlot> activitySlots;

    public BorderVines borderVines;

    public void Proceed()
    {
        StartCoroutine(borderVines.GrowVines());

        //makes it so that you can't set the day 
        PlannerDrag.Instance.SetPlanner(false);

        for (int i = 0; i < activitySlots.Count; i++)
        {
            activitySlots[i].ClearActivity();
        }


    }
}
