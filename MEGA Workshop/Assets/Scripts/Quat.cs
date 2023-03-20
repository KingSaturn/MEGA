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
        returnV.w = rhs.w * lhs.w + ((rhs.x * lhs.x) + (rhs.y * lhs.y) + (rhs.z * lhs.z));
        returnV.x = rhs.w * lhs.x + (lhs.w * rhs.x) + ((lhs.y * rhs.z) - (lhs.z * rhs.y));
        returnV.x = rhs.w * lhs.y + (lhs.w * rhs.y) + ((lhs.z * rhs.x) - (lhs.x * rhs.z));
        returnV.x = rhs.w * lhs.z + (lhs.w * rhs.z) + ((lhs.x * rhs.y) - (lhs.y * rhs.x));
        return returnV;
    }
    public Quat InverseQuat()
    {
        Quat rv = new Quat(0, new Vector3());
        rv.w = w;
        rv.SetAxis(-GetAxis());
        return rv;
    }
    public Vector3 GetAxis()
    {
        Vector3 rv = new Vector3();
        rv.x = x;
        rv.y = y;
        rv.z = z;
        return rv;
    }
    public void SetAxis(Vector3 input)
    {
        x = input.x;
        y = input.y;
        z = input.z;
    }
}
