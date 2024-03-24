using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FlyingEyeAI : MonoBehaviour
{
    public Vector2 velocity;

    public Rigidbody2D rb;
    private enum State
    {
        Idle,
        Attack,
        Damaged,
        Death,
    }

    private enum Direction
    {
        Left,
        Right,
    }

    private State state;
    private Direction direction;  
    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        direction = Direction.Right;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                if (IsPlayerNear())
                {
                    state = State.Attack;
                }
                break;
            case State.Attack:
                break;
            case State.Damaged:
                break;
            case State.Death:
                break;
        }

        switch (direction)
        {
            case Direction.Left:
                break;
            case Direction.Right:
                break;
        }
    }

    void FixedUpdate()
    {
        //Determines which way it's facing and flips it accordingly
        if (rb.velocity.x < 0 && direction != Direction.Left)
        {
            Flip();
            direction = Direction.Left;
        }else if (rb.velocity.x > 0 && direction != Direction.Right)
        {
            Flip();
            direction = Direction.Right;
        }


        rb.velocity = velocity;
    }
    private bool IsPlayerNear()
    {
        //TODO
        return true;
    }
    private void Flip()
    {
        //Flips the sprite
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }
}
