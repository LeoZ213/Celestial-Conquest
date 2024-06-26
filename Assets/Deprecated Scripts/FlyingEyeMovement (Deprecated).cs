using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeMovementDeprecated : MonoBehaviour
{
    public Vector2 startVelocity;
    public Rigidbody2D rb;
    public enum Direction
    {
        Left,
        Right,
    }
    public Direction direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.Right;
        rb.velocity = startVelocity;
    }

    // Update is called once per frame
    void Update()
    {
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
        CheckForWrongDirection();
    }
    public void Flip()
    {
        //Flips the sprite
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
        if (direction == Direction.Left)
        {
            direction = Direction.Right;
        }else
        {
            direction = Direction.Left;
        }
       
    }
    void CheckForWrongDirection()
    {
        //Determines which way it's facing and flips it accordingly
        if (rb.velocity.x < 0 && direction != Direction.Left)
        {
            Flip();
        }
        else if (rb.velocity.x > 0 && direction != Direction.Right)
        {
            Flip();
        }
    }
    public Vector2 GetVelocity()
    {
        return rb.velocity;
    }
    public void SetVelocity(float x, float y)
    {
        rb.velocity = new Vector2(x, y);
    }


}
