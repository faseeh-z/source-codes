using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenuManagerScript : MonoBehaviour
{
    public GameObject levelsPanel;
    public GameObject titlePanel;

    public void showLevelsPanel()
    {
        levelsPanel.SetActive(true);
    }

    public void hideTitle()
    {
        titlePanel.SetActive(false);
    }

    // Level loading functions.
    public void LoadLv1()
    {
        GameManager.Instance.SetLevelAndLoadGame(1);
    }
    public void LoadLv2()
    {
        GameManager.Instance.SetLevelAndLoadGame(2);
    }
    public void LoadLv3()
    {
        GameManager.Instance.SetLevelAndLoadGame(3);
    }
}
