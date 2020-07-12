using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Logic for each individual plant
public class Plant : MonoBehaviour
{
    [SerializeField]
    private PlantType thePlant;
    private SpriteRenderer theRenderer;
    float timer = 0;
    const float timeLimit = 4;
    float growthAmount = 0;

    private void Start()
    {
        theRenderer = GetComponent<SpriteRenderer>();
        theRenderer.sprite = thePlant.GetSprite();
    }

    public IEnumerator GrowPlant()
    {
        timer = 0;

        while (timer < timeLimit)
        {
            timer += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + (growthAmount * Time.deltaTime), transform.position.z);
            if (timer >= timeLimit)
            {
                yield break;
            }
            yield return null;
        }
    }

    //This resets the growth calculation
    public void ResetGrowth()
    {
        growthAmount = thePlant.GetGrowth();
    }

    //This calculates how much it should grow by
    public void CalculateGrowthAmount(Activity theActivity)
    {
        if (theActivity.GetTypes() == thePlant.GetPlantType())
        {
            growthAmount -= theActivity.GetHeal();
        }  
    }

    public float GetGrowth()
    {
        return growthAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("animoop");
    }
}
