using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Activity", menuName = "Activity", order = 51)]
public class Activity : ScriptableObject
{
    [SerializeField]
    private Sprite image;
    [SerializeField]
    private float healAmount; //subject to change
    [SerializeField]
    private string message;
    [SerializeField]
    private ThePlants plantType; //this is the plants that it affects

    public Sprite GetImage()
    {
        return image;
    }

    public float GetHeal()
    {
        return healAmount;
    }

    public string GetMessage()
    {
        return message;
    }

    public ThePlants GetTypes()
    {
        return plantType;
    }
}
