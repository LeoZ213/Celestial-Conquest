using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody rb;
    //We're increasing everything by a factor of 10^6
    private float G = ((float)6.64 * Mathf.Pow(10, -11));

    private DoubleTransform doubleTransform;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        doubleTransform = GetComponent<DoubleTransform>();
    }
    private void FixedUpdate()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach (Attractor attractor in attractors)
        {
            if (attractor != this)
            {
                Attract(attractor);
            }
        }
    }
     void Attract(Attractor objToAttract)
    {
        Debug.Log("Being attracted");
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        //Takes the distance then squaring it
        float distance = direction.sqrMagnitude;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / distance;
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
        Debug.Log("Added force");
    }
    
}
