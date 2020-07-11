using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    [SerializeField]
    private GameObject instructions;

    private float timer = 0, timeLimit = 3;

    //really simple code to quit the game if they press esc
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!instructions.activeSelf) instructions.SetActive(true);
            else Application.Quit();
        }

        if (instructions.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= timeLimit)
            {
                timer = 0;
                instructions.SetActive(false);
            }
        }
    }
}
