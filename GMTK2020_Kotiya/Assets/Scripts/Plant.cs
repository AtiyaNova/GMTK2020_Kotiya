using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Logic for each individual plant
public class Plant : MonoBehaviour
{
    [SerializeField]
    private PlantType thePlant;

    [SerializeField]
    private float yStart;

    private SpriteRenderer theRenderer;
    private float timer = 0;
    private const float timeLimit = 4;
    private float growthAmount = 0;
    private bool notLimit = true;
    private string gameMiddle = "GameMiddle", gameEnd = "GameEnd";

    private void Start()
    {
        theRenderer = GetComponent<SpriteRenderer>();
        theRenderer.sprite = thePlant.GetSprite();
        yStart = transform.position.y;
    }

    public IEnumerator GrowPlant()
    {
        timer = 0;

        while (timer < timeLimit)
        {
            timer += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, GetY(), transform.position.z);
            if (timer >= timeLimit)
            {
                yield break;
            }
            yield return null;
        }
    }

    float GetY()
    {
        float newY = transform.position.y + (growthAmount * Time.deltaTime);
        return newY >= yStart && notLimit ? newY : transform.position.y;
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
        if (collision.CompareTag(gameMiddle))
        {
            BeginDay.Instance.SetMiddle();
        }
        else if (collision.CompareTag(gameEnd))
        {
            BeginDay.Instance.SetEnd();
            notLimit = false;
        }
    }
}
