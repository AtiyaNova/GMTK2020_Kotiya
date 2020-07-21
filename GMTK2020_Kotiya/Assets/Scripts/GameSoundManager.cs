using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages the sounds in the games
public class GameSoundManager : MonoBehaviour
{
    //Singleton
    public static GameSoundManager Instance;
    [SerializeField]
    private AudioSource pageFlipping, bookDrag, bookClose, click; 

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void PlayPageFlip()
    {
        pageFlipping.Play();
    }

    public void PlayBookDrag()
    {
        bookDrag.Play();
    }

    public void PlayBookClose()
    {
        bookClose.Play();
    }

    public void PlayClick()
    {
        click.Play();
    }
}
