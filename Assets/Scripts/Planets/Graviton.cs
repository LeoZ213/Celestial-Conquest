using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Graviton : MonoBehaviour
{
    [SerializeField]
    public bool hasInitialVelocity = true;

    public Vector3 initialVelocity = new Vector3();
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {


        if (hasInitialVelocity)
        {
            if (initialVelocity != null)
            {
                rb.AddForce(initialVelocity, ForceMode.Impulse);
            }
        }
    }
}
