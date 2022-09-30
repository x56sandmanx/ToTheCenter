using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private ObstacleSpawner obstacleSpeed;
    [SerializeField] private ObstacleSpawner rockSpawner;
    // Start is called before the first frame update
    void Start()
    {
        levelText.text = GameData.level;
        SetLevel(GameData.level);
        StartCoroutine(LevelPopUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevel(string level)
    {
        if(level == "Level 1")
        {
            GameData.level = levelText.text = "Level 1";
            obstacleSpeed.timer = 2.0f;
            rockSpawner.timer = 4.0f; 
            Debug.Log(GameData.level + ": Obstacle Speed: " + obstacleSpeed.speed + " RockSpawner: " + rockSpawner.timer);
            StartCoroutine(LevelPopUp());
        }
        if (level == "Level 2")
        {
            GameData.level = levelText.text = "Level 2";
            obstacleSpeed.timer = 1.5f;
            rockSpawner.timer = 3.0f;
            Debug.Log(GameData.level + ": Obstacle Speed: " + obstacleSpeed.speed + " RockSpawner: " + rockSpawner.timer);
            StartCoroutine(LevelPopUp());
        }
        if (level == "Level 3")
        {
            GameData.level = levelText.text = "Level 3";
            obstacleSpeed.timer = 1.0f;
            rockSpawner.timer = 2.0f;
            Debug.Log(GameData.level + ": Obstacle Speed: " + obstacleSpeed.speed + " RockSpawner: " + rockSpawner.timer);
            StartCoroutine(LevelPopUp());
        }
        if (level == "Level 4")
        {
            GameData.level = levelText.text = "Level 4";
            obstacleSpeed.timer = 0.5f;
            rockSpawner.timer = 1.0f;
            Debug.Log(GameData.level + ": Obstacle Speed: " + obstacleSpeed.speed + " RockSpawner: " + rockSpawner.timer);
            StartCoroutine(LevelPopUp());
        }
        if(level == "Win")
        {
            ChangeScene("WinScene");
        }
    }

    public void PauseScreen(bool isPaused)
    {
        if (isPaused)
            pauseScreen.SetActive(true);
        else
            pauseScreen.SetActive(false);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("score", GameData.score);
        PlayerPrefs.SetString("level", levelText.text);
        PlayerPrefs.SetFloat("health", GameData.health);
        ChangeScene("StartScene");
    }

    IEnumerator LevelPopUp()
    {
        levelText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        levelText.gameObject.SetActive(false);
    }
}
