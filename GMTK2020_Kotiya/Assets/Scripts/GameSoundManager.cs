using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages the sounds in the games
public class GameSoundManager : MonoBehaviour
{
    //Singleton
    public static GameSoundManager Instance;
    public AudioSource pageFlipping, bookDrag, click; 

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void PlayPageFlip()
    {
        pageFlipping.Play();
    }

    public void BookDrag()
    {
        bookDrag.Play();
    }

    public void Click()
    {
        click.Play();
    }
}
