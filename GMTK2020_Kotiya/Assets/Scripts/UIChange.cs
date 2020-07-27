using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChange : MonoBehaviour
{
    //the UI changes based off of which plant gets eliminated
    [SerializeField]
    private GameObject[] changes;
    [SerializeField]
    private ThePlants plantType;

    private void Start()
    {
        for (int i = 0; i < changes.Length; i++)
        {
            changes[i].SetActive(false);
        }
    }

    public void ActivateChange()
    {
        for (int i = 0; i < changes.Length; i++)
        {
            changes[i].SetActive(true);
        }
    }

    public ThePlants GetPlantType()
    {
        return plantType;
    }
}
