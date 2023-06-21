using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    //the start menu
    [SerializeField]
    private GameObject GameUI;

    private void Start()
    {
        BeginGame();
    }

    public void BeginGame()
    {
        GameSoundManager.Instance.PlayClick();
        GameUI.SetActive(true);
        GameSoundManager.Instance.PlayBGMusic();
        gameObject.SetActive(false);
    }
}
