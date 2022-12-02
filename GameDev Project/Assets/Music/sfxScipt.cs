using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxScipt : MonoBehaviour
{
    public AudioSource menuClick;
    public AudioSource goldSound;

    public void playMenuClick ()
    {
        menuClick.Play();
    }

    public void playGoldSound()
    {
       goldSound.Play();
    }
}
