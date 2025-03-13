using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveShop : MonoBehaviour
{
    private string activeLevel;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activeLevel = collision.gameObject.GetComponent<Player_RPG>().activeScene;
            SceneManager.LoadScene(activeLevel);
        }
    }
}
