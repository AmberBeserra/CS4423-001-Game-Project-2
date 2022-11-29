using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("gold_score_counter", 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
