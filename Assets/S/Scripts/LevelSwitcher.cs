using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    int activeLevel;
    string[] nextLevel = { "StartGame-0", "Level-1", "Level-2" };
    void Start()
    {
        string level = SceneManager.GetActiveScene().name;
        activeLevel = int.Parse(level.Split('-')[1]);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_RPG>().previousScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(nextLevel[activeLevel + 1]);
        }
    }
}