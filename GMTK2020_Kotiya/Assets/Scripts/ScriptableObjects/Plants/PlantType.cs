using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Plant", menuName = "PlantType", order = 52)]
public class PlantType : ScriptableObject
{
    [SerializeField]
    private string plantName;
    [SerializeField]
    private Sprite plantSprite;
    [SerializeField]
    private float growthAmount;

    public string GetName()
    {
        return plantName;
    }

    public Sprite GetSprite()
    {
        return plantSprite;
    }

    public float GetGrowth()
    {
        return growthAmount;
    }

}
