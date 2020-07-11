using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Activity", menuName = "Activity", order = 51)]
public class Activity : ScriptableObject
{
    [SerializeField]
    private string activityName;
    [SerializeField]
    private float healAmount; //subject to change
    [SerializeField]
    private string message;

    public string GetName()
    {
        return activityName;
    }

    public float GetHeal()
    {
        return healAmount;
    }

    public string GetMessage()
    {
        return message;
    }
}
