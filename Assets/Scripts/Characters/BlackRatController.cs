using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRatController : MonoBehaviour
{
    private float speed = 3.0f;
    private Transform target;
    private float stoppingDistance = 1.2f;

    Animator animator;
    Vector2 lookDirection = new Vector2(0, 0);



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance) //if the position between rats is greater than stoppingDistance
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //make it follow the white rat
            HandleMovement();
        } else
        {
            animator.SetFloat("Speed", 0);
        }
        
    }

    private void HandleMovement()
    {

        //set the animation for moving
        Vector2 move = (target.position - transform.position).normalized;

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Move X", lookDirection.x);
        animator.SetFloat("Move Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }
}
