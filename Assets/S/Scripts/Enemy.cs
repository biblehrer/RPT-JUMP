using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject spawnRangePoint;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = spawnPoint.transform.position;
    }

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        float detectionRange = 10f;
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        Vector2 targetPosition;

        if (distanceToPlayer < detectionRange)
        {
            targetPosition = player.transform.position;
        }
        else
        {
            targetPosition = spawnPoint.transform.position;
        }

        // if (transform.position != (Vector3)targetPosition)
        // {
        //     Movment(targetPosition);
        // }
        // else
        // {
        //     GetComponent<Animator>().SetBool("Moving", false);
        // }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 2 * Time.deltaTime);
    }

    private void Movment(Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - (Vector2)transform.position;

        if (direction.x > 0)
        {
            GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetInteger("Direction", 1);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (direction.x < 0)
        {
            GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetInteger("Direction", -1);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (direction.y > 0)
        {
            GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetInteger("Direction", 2);
        }
        else if (direction.y < 0)
        {
            GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetInteger("Direction", -2);
        }
        else
        {
            GetComponent<Animator>().SetBool("Moving", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(10);
            Debug.Log("Player Hit");
        }
    }
}

// Vector2[] spawnRange = new Vector2[4];
// spawnRange[0] = new Vector2(spawnRangePoint.transform.position.x + spawnRangeX, spawnRangePoint.transform.position.y + spawnRangeY);
// spawnRange[1] = new Vector2(spawnRangePoint.transform.position.x - spawnRangeX, spawnRangePoint.transform.position.y + spawnRangeY);
// spawnRange[2] = new Vector2(spawnRangePoint.transform.position.x + spawnRangeX, spawnRangePoint.transform.position.y - spawnRangeY);
// spawnRange[3] = new Vector2(spawnRangePoint.transform.position.x - spawnRangeX, spawnRangePoint.transform.position.y - spawnRangeY);
// float[] distance = new float[4];
// for (int i = 0; i < distance.Length; i++)
// {
//     distance[i] = Vector2.Distance(transform.position, spawnRange[i]);
// }
// bool playerInRange = false;
// for (int i = 0; i < distance.Length; i++)
// {
//     if (distance[i] < 5)
//     {
//         playerInRange = true;
//         break;
//     }
// }
// if (playerInRange)
// {
//     transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime);
// }
// else
// {
//     transform.position = Vector2.MoveTowards(transform.position, spawnPoint.transform.position, 2 * Time.deltaTime);
// }