using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;

    private float horizontal;
    private float vertical;
    [SerializeField]
    private float speed = 800f;

    void Update()
    {    
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);

        // Convert the mouse position to world coordinates
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        // Calculate the direction from the player to the mouse position
        Vector2 lookDir = mouseWorldPos - rb.position;
        // Calculate the angle to rotate to
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        rb.rotation = angle;
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }
}
