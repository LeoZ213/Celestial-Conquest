using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlyingEyeAI : MonoBehaviour
{
    private enum State
    {
        Idle,
        Attack,
        Damaged,
        Death,
    }
    private State state;
    private bool isPlayerNear = false;
    public Animator myAnim;
    public Collider2D[] collider2Ds;
    public FlyingEyeMovement moveScript;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                if (isPlayerNear)
                {
                    Debug.Log("Successfully switched to attack state");
                    state = State.Attack;
                }
                break;
            case State.Attack:
                myAnim.Play("FlyingEyeAttack");
                break;
            case State.Damaged:
                break;
            case State.Death:
                break;
        }   
    }

    void FixedUpdate()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collider2Ds[0].IsTouching(collision)) //Determines if the inner CircleCollider touches the player
            {
                isPlayerNear = true;
            }
            if (collider2Ds[1].IsTouching(collision)) //Determines if the outer BoxCollider touches the player
            {
                // Determines how far the collision is from FlyingEye itself
                Vector2 direction = (collision.transform.position - transform.position).normalized;
                float speed = moveScript.rb.velocity.magnitude; // Assuming you want to maintain the same speed

                // Set the new velocity based on the direction towards the player
                moveScript.SetVelocity(direction.x * speed, direction.y * speed);
            }
        }
    }
    private void OnAttackAnimationFinished()
    {
        state = State.Idle;
        isPlayerNear = false;
        myAnim.Play("FlyingEyeIdle");
    }
}
