using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_Player : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 momentum;

    public void SetAnimation()
    {
        if (momentum.y > 0)
        {
            // Jump Animation
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
        if (momentum.y < 0)
        {
            // Fall Animation
            animator.SetBool("falling", true);
        }
        if (momentum.x > 0)
        {
            // Walk Animation
        }
        if (momentum.x < 0)
        {
            // Walk Animation
            // Reverse
        }
    }
}
