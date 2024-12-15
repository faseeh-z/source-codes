using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSceneManagerScript: MonoBehaviour
{
    public GameObject[] levels; // Array to store references to Level prefabs.
    public GameObject levelCompletedPanel;

    private void Start()
    {
        Instantiate(levels[GameManager.Instance.currentLevel - 1], new Vector3(0, 0, 0), Quaternion.identity);
        levelCompletedPanel.SetActive(false);
    }

    public void ActivateLevelCompletedPanel()
    {
        levelCompletedPanel.SetActive(true);
    }

    public void Restart()
    {
        GameManager.Instance.RestartLevel();
    }

    public void GoToMainMenu()
    {
        GameManager.Instance.GoToMainMenu();
    }
}
