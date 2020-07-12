using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Vector2 origPos;
    public float xLimit = 11;

    void Start()
    {
        origPos = new Vector2(-46.56f, -1.18f);
    }
    void Update()
    {
        if (transform.position.x < xLimit)
        {
            Vector3 newPos = transform.position;
            newPos.x += (1.0f) * Time.deltaTime;
            transform.position = newPos;
        }
        else transform.position = origPos;
    }
}
