using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quat : MonoBehaviour
{
    public float w, x, y, z;
    public Quat (float angle, Vector3 axis)
    {
        float halfAngle = angle / 2;
        w = Mathf.Cos(halfAngle);
        x = axis.x * Mathf.Sin(halfAngle);
        y = axis.y * Mathf.Sin(halfAngle);
        z = axis.z * Mathf.Sin(halfAngle);
    }
    public static Quat operator*(Quat lhs, Quat rhs)
    {
        Quat returnV = new Quat(0, new Vector3());
        //w = rhs.w * lhs.w + DotProduct(rhs.v, lhs.V)
        returnV.w = rhs.w * lhs.w;
        return returnV;
    }
}
