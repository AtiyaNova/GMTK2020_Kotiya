using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Activity", menuName = "Activity", order = 51)]
public class Activity : ScriptableObject
{
    [SerializeField]
    private string strActivityName;
    [SerializeField]
    private float healAmount; //subject to change

    public string GetName()
    {
        return strActivityName;
    }

    public float GetHeal()
    {
        return healAmount;
    }
}
