using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_RPG : MonoBehaviour
{
    private Animator animator;
    [HideInInspector]
    public string activeScene;
    private float health;
    private float maxHealth;
    public Image playerHealthBar;
    public TMP_Text playerHealthText;
    public Image playerManaBar;
    public TMP_Text playerManaText;
    [HideInInspector]
    public bool PlayerMoving = false;
    private float mana = 100f;
    private float maxMana = 100f;
    private float attackSpeed = 1f;
    public GameObject projectile;
    [HideInInspector]
    public string previousScene;
    [HideInInspector]
    public bool wasInShop = false;
    private GameObject mainCamera;
    private string[][] inventoryPlayer = new string[3][];
    void Start()
    {
        for (int i = 0; i < inventoryPlayer.Length; i++)
        {
            inventoryPlayer[i] = new string[2];
        }
        DontDestroyOnLoad(gameObject);
        animator = GetComponent<Animator>();
        animator.SetInteger("Direction", 0);
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        SetInventory("Potion", 5);
        SetInventory("Sword", 1);
        SetInventory("Shield", 1);
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
        {
            Destroy(gameObject);
        }

        health = GetComponent<Health>().health;
        maxHealth = GetComponent<Health>().maxHealth;
        PlayerHealthBarDisplay();
        PlayerManaBarDisplay();
        if (mana < maxMana)
        {
            float generateMana = 1f;
            RegenerateMana(generateMana);
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);
            mainCamera.transform.parent = null;
            mainCamera.SetActive(true);
            return;
        }

        if (!PlayerMoving && SceneManager.GetActiveScene().name != "StartGame-0")
        {
            return;
        }

        if (attackSpeed <= 0 && mana >= 10f)
        {
            bool attack = PlayerAttack();
            if (attack)
            {
                return;
            }
        }
        else
        {
            attackSpeed -= Time.deltaTime;
        }

        animator.SetBool("Moving", false);
        float x = 0;
        float y = 0;
        Movment(x, y);
    }

    private void RegenerateMana(float generateMana)
    {
        mana += generateMana * Time.deltaTime;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }

    private bool PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            CreateProjectile();
            mana -= 10;
            attackSpeed = 1f;
            return true;
        }
        return false;
    }

    private void CreateProjectile()
    {
        Instantiate(projectile, transform.position + new Vector3(1, 0, 0), transform.rotation);
    }

    private void PlayerManaBarDisplay()
    {
        if (playerManaBar.gameObject.GetComponent<Image>().fillAmount > 0)
        {
            playerManaBar.gameObject.GetComponent<Image>().fillAmount = mana / maxMana;

        }
        string manaText = (Math.Floor(mana * 10) / 10).ToString();
        if (manaText.Length == 1)
        {
            manaText = "0" + manaText + ",0";
        }
        else if (manaText.Length == 2)
        {
            manaText += ",0";
        }
        playerManaText.text = manaText + " / " + maxMana.ToString();
    }

    private void PlayerHealthBarDisplay()
    {
        if (playerHealthBar.gameObject.transform.localScale.x > 0)
        {
            playerHealthBar.gameObject.transform.localScale = new Vector3(health / maxHealth, playerHealthBar.gameObject.transform.localScale.y, playerHealthBar.gameObject.transform.localScale.z);
        }
        playerHealthText.text = health.ToString() + " / " + maxHealth.ToString();
    }

    private void Movment(float x, float y)
    {
        if (Input.GetKey(KeyCode.W))
        {
            y += 1;
            GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetInteger("Direction", 1);
            GetComponent<Animator>().SetBool("OtherIdle", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            y -= 1;
            GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetInteger("Direction", -1);
            GetComponent<Animator>().SetBool("OtherIdle", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= 1;
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetInteger("Direction", 2);
            GetComponent<Animator>().SetBool("OtherIdle", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            x += 1;
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetInteger("Direction", 2);
            GetComponent<Animator>().SetBool("OtherIdle", true);
        }
        if (x != 0 && y != 0)
        {
            x *= 0.7f;
            y *= 0.7f;
        }
        transform.position += 4 * Time.deltaTime * (Vector3.up * y + Vector3.right * x);
    }

    public void SetInventory(string name, int quantity)
    {
        int stelle = -1;
        for (int i = 0; i < inventoryPlayer.Length; i++)
        {
            if (inventoryPlayer[i][0] == name)
            {
                inventoryPlayer[i][1] = (int.Parse(inventoryPlayer[i][1]) + quantity).ToString();
                return;
            }
            if (inventoryPlayer[i][0] == null)
            {
                stelle = i;
                break;
            }
        }
        if (stelle != -1)
        {
            inventoryPlayer[stelle][0] = name;
            inventoryPlayer[stelle][1] = quantity.ToString();
        }
        else
        {
            Debug.Log("Inventory is full, cannot add item: " + name);
        }
    }

    public string[] GetInventory()
    {
        string[] items = new string[inventoryPlayer.Length];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = inventoryPlayer[i][0] + ":" + inventoryPlayer[i][1];
        }
        return items;
    }
}