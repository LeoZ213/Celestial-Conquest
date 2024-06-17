using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour, IPooledObject
{
    private Rigidbody rb;
    private Vector2 velocity;
    private float xVelocity;
    private float yVelocity;
    private float xScale;
    private float yScale;
    private float zScale;

    public void OnObjectSpawn()
    {
        xVelocity = Random.Range(1, 5000);
        yVelocity = Random.Range(1, 5000);
        velocity = new Vector2(xVelocity, yVelocity);

        rb = GetComponent<Rigidbody>();
        rb.velocity = velocity;
        rb.mass = Random.Range(0.001f, 0.01f);

        xScale = Random.Range(0.001f, 0.1f);
        yScale = Random.Range(0.001f, 0.1f);
        zScale = Random.Range(0.001f, 0.1f);

        this.gameObject.transform.localScale = new Vector3(xScale, yScale, zScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
