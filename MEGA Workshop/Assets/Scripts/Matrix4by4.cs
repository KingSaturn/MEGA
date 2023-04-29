using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Matrix4by4
{
    public Matrix4by4(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
    {
        values = new float[4, 4];

        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = column1.w;

        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = column2.w;

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
    public static Matrix4by4 operator *(Matrix4by4 lhs, Matrix4by4 rhs)
    {
        Matrix4by4 output = new Matrix4by4(new Vector4(), new Vector4(), new Vector4(), new Vector4());

        for (int i = 0; i < 4; i++)
        {
            for (int t = 0; t < 4; t++)
            {
                output.values[i, t] = (lhs.values[i, 0] * rhs.values[0, t]) + (lhs.values[i, 1] * rhs.values[1, t]) + (lhs.values[i, 2] * rhs.values[2, t]) + (lhs.values[i, 3] * rhs.values[3, t]);
            }
        }
        return output;
    }
    public  Matrix4by4 setColumn(int index, Vector4 input)
    {
        Matrix4by4 returnValue = new Matrix4by4(new Vector4(), new Vector4(), new Vector4(), new Vector4());

        returnValue.values[index, 0] = input.x;
        returnValue.values[index, 1] = input.y;
        returnValue.values[index, 2] = input.z;
        returnValue.values[index, 3] = input.w;
        return returnValue;
    }
    public static Matrix4by4 Transpose(Matrix4by4 inputMatrix)
    {
        Matrix4by4 rV = new Matrix4by4(new Vector4(), new Vector4(), new Vector4(), new Vector4());
        rV.values[0, 0] = inputMatrix.values[0, 0];
        rV.values[1, 0] = inputMatrix.values[0, 1];
        rV.values[2, 0] = inputMatrix.values[0, 2];
        rV.values[3, 0] = inputMatrix.values[0, 3];

        rV.values[0, 1] = inputMatrix.values[1, 0];
        rV.values[1, 1] = inputMatrix.values[1, 1];
        rV.values[2, 1] = inputMatrix.values[1, 2];
        rV.values[3, 1] = inputMatrix.values[1, 3];

        rV.values[0, 2] = inputMatrix.values[2, 0];
        rV.values[1, 2] = inputMatrix.values[2, 1];
        rV.values[2, 2] = inputMatrix.values[2, 2];
        rV.values[3, 2] = inputMatrix.values[2, 3];

        rV.values[0, 3] = inputMatrix.values[3, 0];
        rV.values[1, 3] = inputMatrix.values[3, 1];
        rV.values[2, 3] = inputMatrix.values[3, 2];
        rV.values[3, 3] = inputMatrix.values[3, 3];

        return rV;
    }
    public static Quat Matrix4by4ToQuat(Matrix4by4 inputMatrix)
    {
        float t = 1 + inputMatrix.values[0,0] + inputMatrix.values[1,1] + inputMatrix.values[2,2];
        float w, x, y, z;
        if(t > 0.00000001)
        {
            float s = Mathf.Sqrt(t * 2.0f);
            x = (inputMatrix.values[2, 1] - inputMatrix.values[1, 2]) / s;
            y = (inputMatrix.values[0, 2] - inputMatrix.values[2, 0]) / s;
            z = (inputMatrix.values[1, 0] - inputMatrix.values[0, 1]) / s;
            w = 0.25f * s;
        }
        else
        {
            if(inputMatrix.values[0,0] > inputMatrix.values[1,1] && inputMatrix.values[0,0] > inputMatrix.values[2,2])
            {
                float s = Mathf.Sqrt(1.0f + inputMatrix.values[0, 0] - inputMatrix.values[1, 1] - inputMatrix.values[2, 2]) * 2;
                x = 0.25f * s;
                y = (inputMatrix.values[1, 0] + inputMatrix.values[0, 1]) / s;
                z = (inputMatrix.values[0, 2] + inputMatrix.values[2, 0]) / s;
                w = (inputMatrix.values[3, 1] + inputMatrix.values[1, 3]) / s;
            }
            else if(inputMatrix.values[1,1] > inputMatrix.values[2, 2])
            {
                float s = Mathf.Sqrt(1.0f + inputMatrix.values[1,1] - inputMatrix.values[0,0] - inputMatrix.values[2,2]) * 2;
                x = (inputMatrix.values[1, 0] + inputMatrix.values[0,1]) / s;
                y = 0.25f * s;
                z = (inputMatrix.values[3, 1] + inputMatrix.values[1,3]) / s;
                w = (inputMatrix.values[0, 2] + inputMatrix.values[2,0]) / s;
            }
            else
            {
                float s = Mathf.Sqrt(1.0f + inputMatrix.values[2, 2] - inputMatrix.values[0, 0] - inputMatrix.values[1, 1]);
                x = (inputMatrix.values[0, 2] + inputMatrix.values[2, 0]) / s;
                y = 0.25f * s;
                z = (inputMatrix.values[3, 1] + inputMatrix.values[1, 3]) / s;
                w = (inputMatrix.values[1, 0] + inputMatrix.values[0, 1]) / s;
            }
        }
        return new Quat(w, x, y, z);
    }
}
