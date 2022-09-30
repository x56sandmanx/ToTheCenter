using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject HTPScreen;
    [SerializeField] private Button deleteSaveButton;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("score") || PlayerPrefs.HasKey("level") || PlayerPrefs.HasKey("health"))
            deleteSaveButton.gameObject.SetActive(true);
        else
            deleteSaveButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGameScene()
    {
        if (PlayerPrefs.HasKey("score") || PlayerPrefs.HasKey("level") || PlayerPrefs.HasKey("health"))
        {
            GameData.score = PlayerPrefs.GetInt("score");
            GameData.level = PlayerPrefs.GetString("level");
            GameData.health = PlayerPrefs.GetFloat("health");
            SceneManager.LoadScene("LevelScene");
        }
        else
        {
            GameData.score = 0;
            GameData.level = "Level 1";
            GameData.health = 100;
            SceneManager.LoadScene("LevelScene");
        }
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        deleteSaveButton.gameObject.SetActive(false);
    }

    public void HowToPlayScreen()
    {
        if(HTPScreen.activeSelf)
            HTPScreen.SetActive(false);
        else
            HTPScreen.SetActive(true);
    }
}
