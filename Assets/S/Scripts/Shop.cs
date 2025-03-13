using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public bool randomize = false;
    public GameObject shopUI;
    private GameObject player;
    private string activeLevel;
    private string previousLevel;
    private string[][] shopItems = {
        new string[] { "Health Potion - Simple", "10", "50" },
        new string[] { "Health Potion - Greater", "5", "100" },
        new string[] { "Health Potion - Ultimate", "2", "200" },
        new string[] { "Mana Potion - Simple", "10", "50" },
        new string[] { "Mana Potion - Greater", "5", "100" },
        new string[] { "Mana Potion - Ultimate", "2", "200" }
    }; // Item Name, Quantity, Price
    private int[] randomShopItems = new int[3];
    public GameObject[] shopSlots;
    public GameObject[] shopSlotTexts;
    public GameObject[] shopSlotQuantities;
    public GameObject[] shopSlotPrices;
    public Sprite[] shopItemSprites;
    private int[] quantities = new int[3];
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shopUI.SetActive(false);
        player.GetComponent<Player_RPG>().wasInShop = true;
        activeLevel = player.GetComponent<Player_RPG>().activeScene;
        previousLevel = player.GetComponent<Player_RPG>().previousScene;
        //if (activeLevel != previousLevel || randomize)
        //{
        for (int i = 0; i < randomShopItems.Length; i++)
        {
            int randomValue = Random.Range(0, 100);
            if (randomValue < 50)
            {
                randomShopItems[i] = Random.Range(0, 2);
            }
            else if (randomValue < 80)
            {
                randomShopItems[i] = Random.Range(2, 4);
            }
            else
            {
                randomShopItems[i] = Random.Range(4, 6);
            }
        }
        //}
        for (int i = 0; i < 3; i++)
        {
            shopSlots[i].GetComponent<Image>().sprite = shopItemSprites[randomShopItems[i]];
            shopSlotTexts[i].GetComponent<TMP_Text>().text = shopItems[randomShopItems[i]][0];
            shopSlotQuantities[i].GetComponent<TMP_Text>().text = shopItems[randomShopItems[i]][1] + "x";
            quantities[i] = int.Parse(shopItems[randomShopItems[i]][1]);
            shopSlotPrices[i].GetComponent<TMP_Text>().text = shopItems[randomShopItems[i]][2];
        }
    }

    void Update()
    {
        for (int i = 0; i < randomShopItems.Length; i++)
        {
            if (shopSlotQuantities[i].GetComponent<TMP_Text>().text == "0x")
            {
                shopSlotPrices[i].GetComponent<TMP_Text>().text = "Sold Out";
                shopSlotPrices[i].GetComponent<TMP_Text>().color = Color.red;
                shopSlotPrices[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                shopUI.SetActive(true);
                player.GetComponent<Player_RPG>().PlayerMoving = false;
            }
        }
    }

    public void CloseUI()
    {
        shopUI.SetActive(false);
        player.GetComponent<Player_RPG>().PlayerMoving = true;
    }

    public void PurchaseIteam_One()
    {

    }

    public void PurchaseIteam_Two()
    {

    }

    public void PurchaseIteam_Three()
    {

    }
}