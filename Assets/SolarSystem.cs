using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    readonly float G = 100f;
    GameObject[] celestials;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] actors = GameObject.FindGameObjectsWithTag("Actors");
        GameObject[] trackingObjects = GameObject.FindGameObjectsWithTag("TrackingObject");
        celestials = new GameObject[trackingObjects.Length + actors.Length];

        System.Array.Copy(trackingObjects, 0, celestials, 0, trackingObjects.Length);
        System.Array.Copy(actors, 0, celestials, trackingObjects.Length, actors.Length);

        InitialVelocity();
    }

    void FixedUpdate()
    {
        SimulateGravity();
    }
    void SimulateGravity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2)) / (r * r));
                }
            }
        }
    }

    void InitialVelocity()
    {
        foreach(GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent <Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / r);

                }
            }
        }
    }
}
