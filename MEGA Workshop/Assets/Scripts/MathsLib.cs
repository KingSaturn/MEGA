using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsLib : MonoBehaviour
{
    public static MyVector3 DegreesToRadians(MyVector3 input)
    {
        MyVector3 output = new MyVector3(0, 0, 0);
        output.x = input.x/(180/Mathf.PI);
        output.y = input.y/(180/Mathf.PI);
        output.z = input.z/(180/Mathf.PI);

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
    public static MyVector3 myLerp(MyVector3 a, MyVector3 b, float t)
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
}
