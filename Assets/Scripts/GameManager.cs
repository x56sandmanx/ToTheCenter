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
        levelText.text = "Level 1";
        StartCoroutine(LevelPopUp());
    }

    // Update is called once per frame
    void Update()
    {
        if(Score.score == 100)
        {
            levelText.text = "Level 2";
            obstacleSpeed.timer = 1.5f;
            rockSpawner.timer = 3.0f;
            StartCoroutine(LevelPopUp());
        }
        if (Score.score == 200)
        {
            levelText.text = "Level 3";
            obstacleSpeed.timer = 1.0f;
            rockSpawner.timer = 2.0f;
            StartCoroutine(LevelPopUp());
        }
        if (Score.score == 300)
        {
            levelText.text = "Level 4";
            obstacleSpeed.timer = 0.5f;
            rockSpawner.timer = 1.0f;
            StartCoroutine(LevelPopUp());
        }
        if(Score.score == 400)
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

    }

    IEnumerator LevelPopUp()
    {
        levelText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        levelText.gameObject.SetActive(false);
    }
}
