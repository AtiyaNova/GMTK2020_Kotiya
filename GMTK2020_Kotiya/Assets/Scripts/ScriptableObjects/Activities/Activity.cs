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
    private string changedMessage;
    [SerializeField]
    private ThePlants plantType; //this is the plants that it affects
    [SerializeField]
    private bool effective = true; //this is if it's too late for it to have an effect

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

    public string GetChangedMessage()
    {
        return changedMessage;
    }

    public ThePlants GetTypes()
    {
        return plantType;
    }

    public void SetEffect(bool temp)
    {
        
        effective = temp;
    }

    public bool StillEffective()
    {
        return effective;
    }
}
