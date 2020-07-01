using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ------------------------------------------------------------------
    //                              TODO
    // seperation of concerns
    // cleanup
    // ------------------------------------------------------------------

    [SerializeField] float moveSpeed;
    [SerializeField] Animator animator;
    [SerializeField] GameObject grabArea;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private moveDirection currentDirection;

    private enum moveDirection
    {
        Idle = 0,
        Left = -1,
        Right = 1,
        Up = 2,
        Down = -2,
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentDirection = moveDirection.Down;
        grabArea.transform.position = rb.position + Vector2.zero;
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);

        print(grabArea);
    }

    // --------------------------------------------------------------------
    //                                      Input
    // --------------------------------------------------------------------
    void Update()
    {
        moveDir = Vector2.zero;
        // Get raw so that we go directly to 0 - 1
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        float absX = Mathf.Abs(moveDir.x);
        float absY = Mathf.Abs(moveDir.y);

        if (absX > absY)
        {
            if (moveDir.x > 0)
            {
                currentDirection = moveDirection.Right;
                grabArea.transform.position = rb.position + Vector2.right;
            }
            else if (moveDir.x < 0)
            {
                currentDirection = moveDirection.Left;
                grabArea.transform.position = rb.position + Vector2.left;
            }
        }
        else if (absX < absY)
        {
            if (moveDir.y > 0)
            {
                currentDirection = moveDirection.Up;
                grabArea.transform.position = rb.position + Vector2.up;
            }
            else if (moveDir.y < 0)
            {
                currentDirection = moveDirection.Down;
                grabArea.transform.position = rb.position + Vector2.down;
            }
        }

        //print("{" + absX + "," + absY + "}" + "- " + currentDirection.ToString());
    }

    // --------------------------------------------------------------------
    //                                      Movement
    // --------------------------------------------------------------------
    void FixedUpdate()
    {
        AnimeMovement();       
        MoveCharacter();
    }

    private void AnimeMovement()
    {
        if (moveDir.x == 0 && moveDir.y == 0)
        {
            int tempDir = Mathf.Clamp((int)currentDirection, -1, 1); // this is terrible, clamping the weird trash enum value

            animator.SetFloat("Horizontal", currentDirection == moveDirection.Left || currentDirection == moveDirection.Right
            ? tempDir : 0);
            animator.SetFloat("Vertical", currentDirection == moveDirection.Up || currentDirection == moveDirection.Down
                ? tempDir : 0);
        }
        else
        {
            animator.SetFloat("Horizontal", currentDirection == moveDirection.Left || currentDirection == moveDirection.Right
            ? moveDir.x : 0);
            animator.SetFloat("Vertical", currentDirection == moveDirection.Up || currentDirection == moveDirection.Down
                ? moveDir.y : 0);
        }
        
    }

    private void MoveCharacter()
    {
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }
}
