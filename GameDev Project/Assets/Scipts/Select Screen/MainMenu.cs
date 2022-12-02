using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button HowToPlayButton;
    public GameObject loadHowToPlay;

    public void openHowToPlay()
    {
        loadHowToPlay.SetActive(true);
    }
}
