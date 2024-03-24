using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 initialVelocity = new Vector3(10.78f, 0, 0);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(initialVelocity, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
