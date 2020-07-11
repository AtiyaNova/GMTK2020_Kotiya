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
            transform.position = new Vector3(transform.position.x, transform.position.y + (thePlant.GetGrowth() * Time.deltaTime), transform.position.z);
            if (timer >= timeLimit)
            {
                print("done plant");
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
