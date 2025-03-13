using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopOwnerText : MonoBehaviour
{
    public GameObject shopOwnerUI;
    public TMP_Text shopOwnerText;
    private string[] ownerTexts = { "Welcome to my shop!", "I have the best prices in town!", "Take a look at my wares!" };
    private int randomValue;
    void Start()
    {
        shopOwnerUI.SetActive(false);
        shopOwnerText.text = "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            randomValue = Random.Range(0, ownerTexts.Length);
            shopOwnerUI.SetActive(true);
            StartCoroutine(Typing(ownerTexts[randomValue]));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopOwnerUI.SetActive(false);
            shopOwnerText.text = "";
        }
    }

    IEnumerator Typing(string ownerText)
    {
        int i = -1;
        while (!shopOwnerText.text.ToString().Equals(ownerText))
        {
            string typ = ownerText.Substring(i + 1);
            string typadd = typ.Substring(0, 1);
            shopOwnerText.text += typadd;
            yield return new WaitForSeconds(0.1f);
            i++;
        }
    }
}