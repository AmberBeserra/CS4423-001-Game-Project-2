using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreLoading : MonoBehaviour
{
    public Text GoldToScore;

    int CurrentScore;
    // Start is called before the first frame update
    void Start()
    {
        if (GoldToScore != null) //checks to make sure GoldToScore is on the scene before providing the counter
        {
            if (PlayerPrefs.HasKey("gold_score_counter")) //checks if counter already exists at the correct amount
            {
                CurrentScore = PlayerPrefs.GetInt("gold_score_counter");
                GoldToScore.text = CurrentScore.ToString();
            }
            else //provides a new counter with a base gold of 100
            {
                CurrentScore = 100;
                GoldToScore.text = "100";
                PlayerPrefs.SetInt("gold_score_counter", 100);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
