using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameData.score.ToString();
        GameData.score = 0;
        GameData.level = "Level 1";
        GameData.health = 100;
        PlayerPrefs.SetInt("score", GameData.score);
        PlayerPrefs.SetString("level", GameData.level);
        PlayerPrefs.SetFloat("health", GameData.health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
