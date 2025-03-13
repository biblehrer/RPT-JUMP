using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject[] bars;
    private bool inventoryOpen = false;
    private float timescale;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timescale = Time.timeScale;
        inventoryUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryOpen)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }
    }

    IEnumerator StopTime(float scale)
    {
        Time.timeScale = scale;
        yield return null;
    }

    public void OpenInventory()
    {
        inventoryUI.SetActive(true);
        for (int i = 0; i < bars.Length; i++)
        {
            bars[i].SetActive(false);
        }
        inventoryOpen = true;
        player.GetComponent<Player_RPG>().PlayerMoving = false;
        StartCoroutine(StopTime(0));
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
        for (int i = 0; i < bars.Length; i++)
        {
            bars[i].SetActive(true);
        }
        inventoryOpen = false;
        player.GetComponent<Player_RPG>().PlayerMoving = true;
        StartCoroutine(StopTime(timescale));
    }
}