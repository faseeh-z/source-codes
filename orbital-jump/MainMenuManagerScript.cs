using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManagerScript : MonoBehaviour
{
    // Button Mappings.
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
