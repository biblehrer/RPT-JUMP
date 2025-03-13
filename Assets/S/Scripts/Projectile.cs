using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    public float speed = 10f;
    private int direction;
    void Start()
    {
        direction = GameObject.FindWithTag("Player").GetComponent<Animator>().GetInteger("Direction");
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        if (direction == 1)
        {
            transform.position += speed * Time.deltaTime * transform.up;
        }
        else if (direction == -1)
        {
            transform.position += speed * Time.deltaTime * -transform.up;
        }
        else if (direction == 2 && !GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().flipX)
        {
            transform.position += speed * Time.deltaTime * -transform.right;
        }
        else if (direction == 2 && GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().flipX)
        {
            transform.position += speed * Time.deltaTime * transform.right;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
