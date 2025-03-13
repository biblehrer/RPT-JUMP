using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    private GameObject player;
    private Animator playerAnimator;
    private GameObject enemy;
    private Animator enemyAnimator;
    public GameObject move;
    public GameObject startPoint;
    public GameObject endPoint;
    bool endpointreached = false;
    bool startpointreached = false;

    void Start()
    {
        player = GameObject.Find("Player");
        playerAnimator = player.GetComponent<Animator>();
        enemy = GameObject.Find("Enemy");
        enemyAnimator = enemy.GetComponent<Animator>();
        move.transform.position = startPoint.transform.position;
        startpointreached = true;
        StartCoroutine(AnimationPlaying());
    }

    IEnumerator AnimationPlaying()
    {
        if (startpointreached)
        {
            yield return new WaitForSeconds(5);
            while (move.transform.position != endPoint.transform.position)
            {
                move.transform.position = Vector3.MoveTowards(move.transform.position, endPoint.transform.position, 2 * Time.deltaTime);
                playerAnimator.SetBool("Moving", true);
                playerAnimator.SetInteger("Direction", 2);
                player.GetComponent<SpriteRenderer>().flipX = true;
                enemyAnimator.SetBool("Moving", true);
                enemyAnimator.SetInteger("Direction", 2);
                enemy.GetComponent<SpriteRenderer>().flipX = true;
                yield return null;
            }
            endpointreached = true;
            startpointreached = false;
        }
        else if (endpointreached)
        {
            yield return new WaitForSeconds(5);
            while (move.transform.position != startPoint.transform.position)
            {
                move.transform.position = Vector3.MoveTowards(move.transform.position, startPoint.transform.position, 2 * Time.deltaTime);
                playerAnimator.SetBool("Moving", true);
                playerAnimator.SetInteger("Direction", 2);
                player.GetComponent<SpriteRenderer>().flipX = false;
                enemyAnimator.SetBool("Moving", true);
                enemyAnimator.SetInteger("Direction", 2);
                enemy.GetComponent<SpriteRenderer>().flipX = false;
                yield return null;
            }
            startpointreached = true;
            endpointreached = false;
        }
    }
}
