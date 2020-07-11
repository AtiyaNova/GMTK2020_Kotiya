using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code for the way the vines grow into the center of the screen
public class BorderVines : MonoBehaviour
{
    float timer = 0;
    const float timeLimit = 4;
    Vector3 finalSize = new Vector3(0.5f, 0.5f, 0.5f);
    public IEnumerator GrowVines()
    {
        timer = 0;

        while (timer < timeLimit)
        {
            timer += Time.deltaTime;
            if (timer >= timeLimit)
            {
                transform.localScale = finalSize;
                PlannerDrag.Instance.SetPlanner(true);
                print("done");
                yield break;
            }
            yield return null;
        }
    }

    float CalculateGrowthAmount()
    {
        return 0;
    }
}
