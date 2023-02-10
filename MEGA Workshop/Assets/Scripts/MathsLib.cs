using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsLib : MonoBehaviour
{
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
    public static MyVector3 CrossProduct(MyVector3 a, MyVector3 b)
    {
        MyVector3 c = new MyVector3(0, 0, 0);
        c.x = a.y * b.z - a.z * b.y;
        c.y = a.z * b.x - a.x * b.z;
        c.z = a.x * b.y - a.y * b.x;
        return c;
    }
}
