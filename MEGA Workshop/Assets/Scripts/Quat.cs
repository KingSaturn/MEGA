using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEditorInternal;
using UnityEngine;

public class Quat
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
    public Quat (Vector3 axis)
    {
        w = 0;
        x = axis.x;
        y = axis.y;
        z = axis.z;
    }
    public Quat(float iw, float ix, float iy, float iz)
    {
        float halfAngle = iw / 2;
        w = Mathf.Cos(halfAngle);
        x = ix * Mathf.Sin(halfAngle);
        y = iy * Mathf.Sin(halfAngle);
        z = iz * Mathf.Sin(halfAngle);
    }
    public static Quat operator*(Quat r, Quat s)
    {
        Quat rv = new Quat(0, new Vector3());
        rv.w = s.w * r.w + ((s.x * r.x) + (s.y * r.y) + (s.z * r.z));
        rv.x = s.w * r.x + (r.w * s.x) + ((r.y * s.z) - (r.z * s.y));
        rv.y = s.w * r.y + (r.w * s.y) + ((r.z * s.x) - (r.x * s.z));
        rv.z = s.w * r.z + (r.w * s.z) + ((r.x * s.y) - (r.y * s.x));
        return rv;
    }
    public static Quat SLERP(Quat q, Quat r, float t)
    {
        t = Mathf.Clamp(t, 0.0f, 1.0f);
        Quat d = r * q.InverseQuat();
        Vector4 AxisAngle = d.AxisFromQuat();
        Quat dT = new Quat(AxisAngle.w * t, new Vector3(AxisAngle.x, AxisAngle.y, AxisAngle.z));

        return dT * q;
    }
    public static Quat FromUnityQuat(Quaternion input)
    {
        Quat output = new Quat(0, 0, 0, 0);
        output.w = input.w;
        output.x = input.x;
        output.y = input.y;
        output.z = input.z;
        return output;
    }
    public Vector4 AxisFromQuat()
    {
        Vector4 returnVector = new Vector4();
        float halfAngle = Mathf.Acos(w);
        returnVector.w = halfAngle * 2;
        returnVector.x = x / Mathf.Sin(halfAngle);
        returnVector.y = y / Mathf.Sin(halfAngle);
        returnVector.z = z / Mathf.Sin(halfAngle);
        return returnVector;
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
    public void SetQuat(float f, Vector3 axis)
    {
        float halfAngle = f / 2;
        w = Mathf.Cos(halfAngle);
        x = axis.x * Mathf.Sin(halfAngle);
        y = axis.y * Mathf.Sin(halfAngle);
        z = axis.z * Mathf.Sin(halfAngle);
    }
    public Matrix4by4 ToRotationMatrix()
    {
        Matrix4by4 rv = new Matrix4by4(new Vector4(), new Vector4(), new Vector4(), new Vector4());
        rv.values[0, 0] = 1 - 2 * ((y * y) + (z * z));
        rv.values[1, 0] = 2 * ((x * y) - (z * w));
        rv.values[2, 0] = 2 * ((x * z) + (y * w));

        rv.values[0, 1] = 2 * ((x * y) + (z * w));
        rv.values[1, 1] = 1 - 2 * ((x * x) + (z * z));
        rv.values[2, 1] = 2 * ((y * z) - (x * w));

        rv.values[0, 2] = 2 * ((x * z) - (y * w));
        rv.values[1, 2] = 2 * ((y * z) + (x * w));
        rv.values[2, 2] = 1 - 2 * ((x * x) + (y * y));

        rv.values[3, 0] = rv.values[3, 1] = rv.values[3, 2] = rv.values[0, 3] = rv.values[1, 3] = rv.values[2, 3] = 0;
        rv.values[3, 3] = 1;

        Matrix4by4 output = Matrix4by4.Transpose(rv);
        return output;
    }
    public static Quat LookRotation(MyVector3 forward, MyVector3 upwards)
    {
        forward.NormalizeMyVector();
        MyVector3 right = MathsLib.CrossProduct(upwards, forward);
        right.NormalizeMyVector();

        MyVector3 up = MathsLib.CrossProduct(forward, right);

        Matrix4by4 rotation = new Matrix4by4(new Vector4(), new Vector4(), new Vector4(), new Vector4());
        rotation.setColumn(0, new Vector4(right.x, right.y, right.z, 0));
        rotation.setColumn(1, new Vector4(up.x, up.y, up.z, 0));
        rotation.setColumn(2, new Vector4(forward.x, forward.y, forward.z, 0));
        rotation.setColumn(3, new Vector4(0, 0, 0, 1));
        Quat returnValue = Matrix4by4.Matrix4by4ToQuat(rotation);
        return returnValue;
    }
}
