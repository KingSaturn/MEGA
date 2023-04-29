using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MyVector3
{
    public float x;
    public float y;
    public float z;

    public MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static MyVector3 AddVector(MyVector3 a, MyVector3 b)
    {
        MyVector3 returnVal = new MyVector3(0, 0, 0);
        returnVal.x = a.x + b.x;
        returnVal.y = a.y + b.y;
        returnVal.z = a.z + b.z;

        return returnVal;
    }
    public static MyVector3 SubtractVector(MyVector3 a, MyVector3 b)
    {
        MyVector3 returnVal = new MyVector3(0, 0, 0);
        returnVal.x = a.x - b.x;
        returnVal.y = a.y - b.y;
        returnVal.z = a.z - b.z;

        return returnVal;
    }
    public float Length()
    {
        float returnVal = 0;
        returnVal = Mathf.Sqrt(x * x + y * y + z * z);
        return returnVal;
    }
    public float LengthSq()
    {
        float returnVal = 0;
        returnVal = x * x + y * y + z * z;
        return returnVal;
    }
    public static MyVector3 VectorScaler(MyVector3 vector, float scaler)
    {
        MyVector3 returnVal = new MyVector3(0, 0, 0);

        returnVal.x = vector.x * scaler;
        returnVal.y = vector.y * scaler;
        returnVal.z = vector.z * scaler;

        return returnVal;
    }
    public static MyVector3 VectorDivisor(MyVector3 vector, float divisor)
    {
        MyVector3 returnVal = new MyVector3(0, 0, 0);

        returnVal.x = vector.x / divisor;
        returnVal.y = vector.y / divisor;
        returnVal.z = vector.z / divisor;

        return returnVal;
    }
    public MyVector3 NormalizeMyVector()
    {
        MyVector3 returnVal = new MyVector3(0, 0, 0);
        returnVal.x = x;
        returnVal.y = y;
        returnVal.z = z;

        returnVal = returnVal / returnVal.Length();

        return returnVal;
    }
    public static float DotProduct(MyVector3 a, MyVector3 b, bool NormCheck = true)
    {
        float returnVal;

        if (NormCheck)
        {
            MyVector3 normA = a.NormalizeMyVector();
            MyVector3 normB = b.NormalizeMyVector();

            returnVal = normA.x * normB.x + normA.y * normB.y + normA.z * normB.z;
        }
        else
        {
            returnVal = a.x * b.x + a.y * b.y + a.z * b.z;
        }
        return returnVal;
    }
    public static float AngleBetweenVectors(MyVector3 lhs, MyVector3 rhs)
    {
        float dotP = MyVector3.DotProduct(lhs, rhs);
        float magP = lhs.Length() * rhs.Length();
        float angle = Mathf.Acos(dotP / magP);
        float angleInDeg = angle * (180/Mathf.PI);
        return angleInDeg;
    }
    public static MyVector3 operator+(MyVector3 lhs, MyVector3 rhs)
    {
        return AddVector(lhs, rhs);
    }
    public static MyVector3 operator-(MyVector3 lhs, MyVector3 rhs)
    {
        return SubtractVector(lhs, rhs);
    }
    public static MyVector3 operator*(MyVector3 lhs, float rhs)
    {
        return VectorScaler(lhs, rhs);
    }
    public static MyVector3 operator/(MyVector3 lhs, float rhs)
    {
        return VectorDivisor(lhs, rhs);
    }
    public static MyVector3 EulerAnglesToDirection(MyVector3 Euler)
    {
        MyVector3 returnValue = new MyVector3(0, 0, 0);

        returnValue.x = Mathf.Cos(Euler.y) * Mathf.Cos(Euler.x);
        returnValue.y = Mathf.Sin(Euler.x);
        returnValue.z = Mathf.Cos(Euler.x) * Mathf.Sin(Euler.y);

        return returnValue;
    }
    public Vector3 ToUnityVector()
    {
        Vector3 returnVal = new Vector3();
        returnVal.x = x;
        returnVal.y = y;
        returnVal.z = z;
        return returnVal;
    }
    public Vector2 FromMyVector3()
    {
        Vector2 output = new Vector2();

        output.x = x;
        output.y = y;

        return output;
    }
}
