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
    public static Quat operator*(Quat lhs, Quat rhs)
    {
        Quat returnV = new Quat(0, new Vector3());
        returnV.w = rhs.w * lhs.w + ((rhs.x * lhs.x) + (rhs.y * lhs.y) + (rhs.z * lhs.z));
        returnV.x = rhs.w * lhs.x + (lhs.w * rhs.x) + ((lhs.y * rhs.z) - (lhs.z * rhs.y));
        returnV.y = rhs.w * lhs.y + (lhs.w * rhs.y) + ((lhs.z * rhs.x) - (lhs.x * rhs.z));
        returnV.z = rhs.w * lhs.z + (lhs.w * rhs.z) + ((lhs.x * rhs.y) - (lhs.y * rhs.x));
        return returnV;
    }
    public static Quat SLERP(Quat q, Quat r, float t)
    {
        t = Mathf.Clamp(t, 0.0f, 1.0f);
        Quat d = r * q.InverseQuat();
        Vector4 AxisAngle = d.AxisFromQuat();
        Quat dT = new Quat(AxisAngle.w * t, new Vector3(AxisAngle.x, AxisAngle.y, AxisAngle.z));

        return dT * q;
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
}
