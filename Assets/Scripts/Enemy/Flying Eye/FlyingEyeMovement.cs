using NavMeshPlus.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingEyeMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    private NavMeshAgent agent;
    private Vector2 displacement;

    public enum Direction
    {
        Left,
        Right,
    }
    private Direction direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.Right;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
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
        PursueTarget();
    }
    private void FixedUpdate()
    {

        CheckForWrongDirection();
    }

    public void Flip()
    {
        //Flips the sprite
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }
    private void CheckForWrongDirection()
    {
        displacement = target.position - this.transform.position;
        if (displacement.x > 0 && direction != Direction.Right)
        {
            direction = Direction.Right;
            Flip();
        }else if(displacement.x < 0 && direction != Direction.Left)
        {
            direction = Direction.Left;
            Flip();
        }
    }
    private void PursueTarget()
    {
        Debug.Log(displacement.magnitude);
        if (displacement.magnitude > 100)
        {
            agent.SetDestination(this.transform.position);
        }else
        {
            agent.SetDestination(target.position);
        }
    }
}
