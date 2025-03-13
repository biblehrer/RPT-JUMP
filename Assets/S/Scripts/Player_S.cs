using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_S : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rbody2D;
    float movementSpeed = 5;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * x * Time.deltaTime * movementSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rbody2D.velocity.y) < 0.01f)
        {
            rbody2D.AddForce(new Vector2(0, 6.5f), ForceMode2D.Impulse);
        }
        AnimationRunner(x);
    }

    void AnimationRunner(float x)
    {
        if (rbody2D.velocity.y > 0.1f)
        {
            animator.SetBool("Jumping", true);
            animator.SetBool("Falling", false);
        }
        else if (rbody2D.velocity.y < -0.1f)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", false);
        }

        if (animator != null)
        {
            animator.SetBool("IsMoving", Mathf.Abs(x) > 0);
        }
        if (x < 0 && spriteRenderer != null)
        {
            spriteRenderer.flipX = true;
        }
        if (x > 0 && spriteRenderer != null)
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("Crouching", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Crouching", false);
        }
    }
}