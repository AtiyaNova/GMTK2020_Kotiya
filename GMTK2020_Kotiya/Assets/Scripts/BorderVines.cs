using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code for the way the vines grow into the center of the screen
public class BorderVines : MonoBehaviour
{
    float timer = 0, growthAmount = 0;
    const float timeLimit = 4;
    Vector3 finalSize = new Vector3(2.18f, 2.18f, 2.18f);

    public IEnumerator GrowVines()
    {
        timer = 0;
        CalculateGrowthAmount();

        while (timer < timeLimit)
        {
            if (transform.localScale.x > finalSize.x)
            {
                transform.localScale = new Vector3(transform.localScale.x - (growthAmount*Time.deltaTime), transform.localScale.y - (growthAmount * Time.deltaTime), growthAmount);
            }

            timer += Time.deltaTime;

            if (timer >= timeLimit)
            {
                PlannerDrag.Instance.SetPlanner(true);
                yield break;
            }
            yield return null;
        }
    }

    void CalculateGrowthAmount()
    {
        growthAmount = BeginDay.Instance.AveragePlantGrowth()*1.2f;
    }
}
