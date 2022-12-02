using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxScipt : MonoBehaviour
{
    public AudioSource menuClick;
    public AudioSource goldSound;
    public AudioSource swordSound;
    public AudioSource blockSound;

    public void playMenuClick ()
    {
        menuClick.Play();
    }

    public void playGoldSound()
    {
       goldSound.Play();
    }

    public void playBlockSound()
    {
        swordSound.Play();
    }

    public void playSwordSound()
    {
        blockSound.Play();
    }
}
