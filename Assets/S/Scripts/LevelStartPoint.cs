using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartPoint : MonoBehaviour
{
    private Animator animator;
    private GameObject player;
    private GameObject playerEntryPoint;
    private GameObject leaveShop;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<Player_RPG>().wasInShop)
        {
            player.GetComponent<Player_RPG>().wasInShop = false;
            player.transform.position = GameObject.Find("ShopEntryPoint").transform.position;
            Destroy(gameObject);
            return;
        }
        animator = player.GetComponent<Animator>();
        playerEntryPoint = GameObject.Find("PlayerEntryPoint");
        player.transform.position = playerEntryPoint.transform.position;
        if (GameObject.Find("LeaveShop") != null)
        {
            leaveShop = GameObject.Find("LeaveShop");
            leaveShop.SetActive(false);
        }
    }

    void Update()
    {
        if (player.transform.position == transform.position)
        {
            animator.SetBool("Moving", false);
            if (leaveShop != null)
            {
                leaveShop.SetActive(true);
            }
            Destroy(gameObject);
            player.GetComponent<Player_RPG>().PlayerMoving = true;
        }
        else
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, 2 * Time.deltaTime);
            animator.SetBool("Moving", true);
            animator.SetInteger("Direction", -1);
        }
    }
}
