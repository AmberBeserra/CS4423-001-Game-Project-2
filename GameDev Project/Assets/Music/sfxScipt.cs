using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxScipt : MonoBehaviour
{
    public AudioSource menuClick;
    public AudioSource goldSound;
    public AudioSource swordSound;
    public AudioSource blockSound;
    public AudioSource swordMissSound;

    public void playMenuClick ()
    {
        menuClick.Play();
    }

    public void playGoldSound()
    {
       goldSound.Play();
    }

    public void playSwordSound()
    {
        swordSound.Play();
    }

    public void playBlockSound()
    {
        blockSound.Play();
    }

    public void playSwordMissSound()
    {
        swordMissSound.Play();
    }
}
