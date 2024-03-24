using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DoubleVector3
{

    public double x, y, z;

    public DoubleVector3(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static explicit operator Vector3(DoubleVector3 v)
    {

        return new Vector3((float)v.x, (float)v.y, (float)v.z);
    }
}
public class DoubleTransform : MonoBehaviour
{

    private DoubleVector3 _position;

    public DoubleVector3 Position
    {

        get => _position;

        set
        {

            _position = value;
            transform.position = (Vector3)_position;
        }
    }
}