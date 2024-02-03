using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteRatController : MonoBehaviour
{
    public float runSpeed = 1.0f;

    Rigidbody2D rigidbody2d;

    Animator animator;

    Vector2 lookDirection = new Vector2(0, 0);

    private bool facingRight;


    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //public void LoadData(GameData data)
    //{
    //    this.transform.position = data.playerPosition;
    //}

    //public void SaveData(ref GameData data)
    //{
    //    data.playerPosition = this.transform.position;
    //}


    private void FixedUpdate()
    {
        //if dialogue is playing, freeze the player
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            animator.enabled = false;
            return;
        }
        else
            animator.enabled = true;

        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        rigidbody2d.velocity = new Vector2(moveDirection.x * runSpeed, moveDirection.y * runSpeed);

        //set the animation for moving
        Vector2 move = new Vector2(moveDirection.x, moveDirection.y);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();

            // Flip the sprite based on the movement direction
            if (move.x < 0)
            {
                facingRight = true;
            }
            else if (move.x > 0)
            {
                facingRight = false;
            }

            // Change the facing direction
            if (facingRight) {
                transform.localScale = new Vector2(-1, 1);
            }
            else {
                transform.localScale = new Vector2(1, 1);
            }
        }


        animator.SetFloat("Move X", lookDirection.x);
        animator.SetFloat("Move Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

    }

}
