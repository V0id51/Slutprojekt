using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //Om vi kan g� h�ger och v�nster med WASD
        movement.y = Input.GetAxisRaw("Vertical"); //Om vi kan g� upp och ner med WASD

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("Last_Horizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("Last_Vertical", Input.GetAxisRaw("Vertical"));
        }

        if (movement == Vector2.zero)
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }
    
    }

    private void FixedUpdate()
    {
        rb.velocity = movement.normalized * moveSpeed;
    }
}
