using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int moveSpeed;
    [SerializeField] Animator animator;

    private Rigidbody2D rb;
    private Vector2 moveDir;

    private moveDirection currentDirection;

    private enum moveDirection
    {
        Idle,
        Left,
        Right,
        Up,
        Down
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentDirection = moveDirection.Idle;
    }

    // --------------------------------------------------------------------
    //                                      Input
    // --------------------------------------------------------------------
    void Update()
    {
        moveDir.x = Input.GetAxis("Horizontal");

        if (moveDir.x > 0)
        {
            currentDirection = moveDirection.Right;
        }
        else if (moveDir.x < 0) 
        {
            currentDirection = moveDirection.Left;
        } 
        else 
        {
            currentDirection = moveDirection.Idle;
        }
        
        moveDir.y = Input.GetAxis("Vertical");

        if (moveDir.y > 0)
        {
            currentDirection = moveDirection.Up;
        }
        else if (moveDir.x < 0)
        {
            currentDirection = moveDirection.Down;
        }
        else
        {
            currentDirection = moveDirection.Idle;
        }       
    }

    // --------------------------------------------------------------------
    //                                      Movement
    // --------------------------------------------------------------------
    void FixedUpdate()
    {
        if (currentDirection.Equals(moveDirection.Left) || currentDirection.Equals(moveDirection.Right))
        {
            moveDir.y = 0;
            animator.SetFloat("Horizontal", moveDir.x);
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
        }

        if (currentDirection.Equals(moveDirection.Up) || currentDirection.Equals(moveDirection.Down))
        {
            moveDir.x = 0;
            animator.SetFloat("Vertical", moveDir.y);
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
        } 
    }
}
