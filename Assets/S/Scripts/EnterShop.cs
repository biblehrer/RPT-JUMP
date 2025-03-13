using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterShop : MonoBehaviour
{
    private string activeLevel;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activeLevel = SceneManager.GetActiveScene().name;
            collision.gameObject.GetComponent<Player_RPG>().activeScene = activeLevel;
            SceneManager.LoadScene("Shop");
        }
    }
}
