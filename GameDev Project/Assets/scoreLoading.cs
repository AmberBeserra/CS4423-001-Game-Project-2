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
        if (GoldToScore != null)
        {
            if (PlayerPrefs.HasKey("gold_score_counter"))
            {
                CurrentScore = PlayerPrefs.GetInt("gold_score_counter");
                GoldToScore.text = CurrentScore.ToString();
            }
            else
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
