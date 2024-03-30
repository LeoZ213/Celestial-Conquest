using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCrumb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCountdown());
    }
    IEnumerator DestroyCountdown()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
