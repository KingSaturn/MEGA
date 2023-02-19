using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix4by4
{
    public Matrix4by4(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
    {
        values = new float[4, 4];

        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = column1.w;

        values[0,1] = column2.x;
        values[1,2] = column2.y;
        values[2,3] = column2.z;
        values[3,4] = column2.w;

        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = column3.w;

        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = column4.w;
    }
    public Matrix4by4(Vector3 column1, Vector3 column2, Vector3 column3, Vector3 column4)
    {
        values = new float[4, 4];

        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = 0;

        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0;

        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0;

        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = 1;
    }
    public float[,] values;
    public static Vector4 operator *(Matrix4by4 lhs, Vector4 rhs)
    {
        Vector4 output = new Vector4();

        output.x = (lhs.values[0, 0] * rhs.x) + (lhs.values[0, 1] * rhs.y) + (lhs.values[0, 2] * rhs.z) + (lhs.values[0, 3] * rhs.w);
        output.y = (lhs.values[1, 0] * rhs.x) + (lhs.values[1, 1] * rhs.y) + (lhs.values[1, 2] * rhs.z) + (lhs.values[1, 3] * rhs.w);
        output.z = (lhs.values[2, 0] * rhs.x) + (lhs.values[2, 1] * rhs.y) + (lhs.values[2, 2] * rhs.z) + (lhs.values[2, 3] * rhs.w);
        output.w = (lhs.values[3, 0] * rhs.x) + (lhs.values[3, 1] * rhs.y) + (lhs.values[3, 2] * rhs.z) + (lhs.values[3, 3] * rhs.w);

        return output;
    }
}
