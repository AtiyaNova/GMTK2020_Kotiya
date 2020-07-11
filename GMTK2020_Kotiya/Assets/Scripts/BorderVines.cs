using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderVines : MonoBehaviour
{
    float timer = 0, timeLimit = 2;

    public IEnumerator GrowVines()
    {
        timer = 0;

        while (timer < timeLimit)
        {
            timer += Time.deltaTime;
            if (timer >= timeLimit)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                PlannerDrag.Instance.SetPlanner(true);
                print("done");
                yield break;
            }
            yield return null;
        }
    }
}
