using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 0; // 0 if no level is selected. Used by LevelLoader in Game scene.
    public bool levelCompleted = false;

    public static GameManager Instance;

    void Awake()
    {
        // Singleton.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Make the object persist between scene loads.
        }
    }

    public void CompleteLevel()
    {
        levelCompleted = true;
        GameSceneManagerScript gameSceneManager = GameObject.Find("Game Scene Manager").GetComponent<GameSceneManagerScript>();
        gameSceneManager.ActivateLevelCompletedPanel();
    }

    public void RestartLevel()
    {
        levelCompleted = false;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void GoToMainMenu()
    {
        levelCompleted = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void SetLevelAndLoadGame(int levelNo)
    {
        currentLevel = levelNo;
        SceneManager.LoadScene("Game");
    }
}
