using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void NewGame()
    {
        // Reset Save-Files
        SceneManager.LoadScene("LoadGame");
    }

    public void LoadGame()
    {
        // Load the game scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
