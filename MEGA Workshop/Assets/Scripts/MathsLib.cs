using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MathsLib : MonoBehaviour
{
    public Vector3 AxisAngleRotat(float angle, Vector3 axis, Vector3 position)
    {
        Vector3 returnVal = (position * Mathf.Cos(angle)) + Vector3.Dot(position, axis) * axis * (1 - Mathf.Cos(angle)) + Vector3.Cross(axis, position) * Mathf.Sin(angle);

        return returnVal;
    }

    public static MyVector3 DegreesToRadians(MyVector3 input)
    {
        MyVector3 output = new MyVector3(0, 0, 0);
        output.x = input.x / (180 / Mathf.PI);
        output.y = input.y / (180 / Mathf.PI);
        output.z = input.z / (180 / Mathf.PI);

        return output;
    }
    public static float VectorToRadians(Vector2 v2)
    {
        float rv = 0.0f;

        rv = Mathf.Atan(v2.y / v2.x);

        return rv;
    }
    public static Vector2 RadiansToVector(float angle)
    {
        Vector2 rv = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        return rv;
    }
    public static MyVector3 MyLerp(MyVector3 a, MyVector3 b, float t)
    {
        MyVector3 c = new MyVector3(0, 0, 0);
        c = a * (1.0f - t) + b * t;
        return c;
    }
    public static MyVector3 DirectionFromEuler(MyVector3 Euler)
    {
        MyVector3 output = new MyVector3(0, 0, 0);
        output.z = Mathf.Cos(Euler.y) * Mathf.Cos(Euler.x);
        output.y = -Mathf.Sin(Euler.x);
        output.x = Mathf.Cos(Euler.x) * Mathf.Sin(Euler.y);

        return output;
    }
    public static MyVector3 CrossProduct(MyVector3 a, MyVector3 b)
    {
        MyVector3 c = new MyVector3(0, 0, 0);
        c.x = a.y * b.z - a.z * b.y;
        c.y = a.z * b.x - a.x * b.z;
        c.z = a.x * b.y - a.y * b.x;
        return c;
    }
    public static Vector2 CrossProduct(Vector2 v)
    {
        float result = v.x * v.y;
        return new Vector2(result, -result);
    }
    public static float Length(Vector2 v)
    {
        return MathF.Sqrt((v.x * v.x) + (v.y * v.y));
    }
    //public static Vector4 AxisFromQuat(Quaternion q)
    //{
    //    Vector4 returnVector = new Vector4();
    //    float halfAngle = Mathf.Acos(q.w);
    //    returnVector.w = halfAngle * 2;
    //    returnVector.x = q.x / Mathf.Sin(halfAngle);
    //    returnVector.y = q.y / Mathf.Sin(halfAngle);
    //    returnVector.z = q.z / Mathf.Sin(halfAngle);
    //    return returnVector;
    //}
    public static Quaternion ToUnityQuat(Quat input)
    {
        Quaternion output = new Quaternion(0, 0, 0, 0);
        output.w = input.w;
        output.x = input.x;
        output.y = input.y;
        output.z = input.z;
        return output;
    }
}
