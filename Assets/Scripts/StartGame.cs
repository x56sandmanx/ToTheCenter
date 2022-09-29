using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject HTPScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameScene()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void HowToPlayScreen()
    {
        if(HTPScreen.activeSelf)
            HTPScreen.SetActive(false);
        else
            HTPScreen.SetActive(true);
    }
}
