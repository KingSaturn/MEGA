using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public class ObjectTransformation : MonoBehaviour
{
    public Mesh meshInstance;
    Vector3[] modelSpaceVertices;
    public GameObject currentObject;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    public Vector4 v4transformation;
    public Matrix4by4 rotationMatrix;
    public float angle;
    public Quat rotationQuat;
    public Quat currentQuat;

    void Start()
    {
        MeshFilter MF = GetComponent<MeshFilter>();
        MF.sharedMesh = Instantiate(meshInstance);
        modelSpaceVertices = MF.sharedMesh.vertices;
        rotationQuat = new Quat(angle, rotation);
        if (gameObject.activeSelf)
        {
            scale.x = 1;
            scale.y = 1;
            scale.z = 1;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
        //    Cursor.lockState = CursorLockMode.Confined;
        //    Cursor.visible = false;

        }
        if(Input.GetMouseButtonUp(1))
        {
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }
        if (scale.x >= 0 && scale.y >= 0 && scale.z >= 0)
        {
            scale.x = scale.x + Input.mouseScrollDelta.y / 10;
            scale.y = scale.y + Input.mouseScrollDelta.y / 10;
            scale.z = scale.z + Input.mouseScrollDelta.y / 10;
        }
        else
        {
            
            scale.x = 0;
            scale.y = 0;
            scale.z = 0;
        }

        Vector3[] transformedMatrix = new Vector3[modelSpaceVertices.Length];

        //Matrix4by4 rollMatrix = new Matrix4by4(new Vector3(Mathf.Cos(rotation.z), Mathf.Sin(rotation.z), 0), new Vector3(-Mathf.Sin(rotation.z), Mathf.Cos(rotation.z), 0), new Vector3(0, 0, 1), Vector3.zero);
        //Matrix4by4 pitchMatrix = new Matrix4by4(new Vector3(1,0,0), new Vector3(0, Mathf.Cos(rotation.x), Mathf.Sin(rotation.x)), new Vector3(0, -Mathf.Sin(rotation.x), Mathf.Cos(rotation.x)), Vector3.zero);
        //Matrix4by4 yawMatrix = new Matrix4by4(new Vector3(Mathf.Cos(rotation.y), 0, -Mathf.Sin(rotation.y)), new Vector3(0,1,0), new Vector3(Mathf.Sin(rotation.y), 0, Mathf.Cos(rotation.y)), Vector3.zero);
        //Matrix4by4 rotatMatrix = yawMatrix * (pitchMatrix * rollMatrix);

        //angleX = rotation.x;
        //angleY = rotation.y;
        //angleZ = rotation.z;
        //Quat pitchQuat = new Quat(angleX, new Vector3(1,0,0));
        //Quat yawQuat = new Quat(angleY, new Vector3(0,1,0));
        //Quat rollQuat = new Quat(angleZ, new Vector3(0,0,1));

        //Matrix4by4 rollMatrix = rollQuat.ToRotationMatrix();
        //Matrix4by4 pitchMatrix = pitchQuat.ToRotationMatrix();
        //Matrix4by4 yawMatrix = yawQuat.ToRotationMatrix();

        //Matrix4by4 rotationMatrix = yawMatrix * (pitchMatrix * rollMatrix);

        //rotationQuat = Quat.FromAxisToQuat(angle, rotation);
        //Quat yawQuat = new Quat(Time.deltaTime, 0, 1, 0);
        //rotationQuat = yawQuat * rotationQuat;

        currentQuat = rotationQuat;

        rotationMatrix = rotationQuat.ToRotationMatrix();
        Matrix4by4 scaleMatrix = new Matrix4by4(new Vector3(1, 0, 0) * scale.x, new Vector3(0, 1, 0) * scale.y, new Vector3(0, 0, 1) * scale.z, Vector3.zero);
        Matrix4by4 translationMatrix = new Matrix4by4(new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1), new Vector3(position.x, position.y, position.z));

        Matrix4by4 matrixTransform = translationMatrix * (rotationMatrix * scaleMatrix);
        for (int i = 0; i < transformedMatrix.Length; i++)
        {
            transformedMatrix[i] = matrixTransform * new Vector4(modelSpaceVertices[i].x, modelSpaceVertices[i].y, modelSpaceVertices[i].z, 1);
        }
        MeshFilter MF = GetComponent<MeshFilter>();

        MF.sharedMesh.vertices = transformedMatrix;

        MF.sharedMesh.RecalculateNormals();
        MF.sharedMesh.RecalculateBounds();
    }
    public Matrix4by4 InverseTranslation()
    {
        Matrix4by4 returnValue = new Matrix4by4(new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1), new Vector3(-position.x, -position.y, -position.z));

        return returnValue;
    }
    public Matrix4by4 InverseRotation(Matrix4by4 rotationMatrix)
    {
        Matrix4by4 returnValue = Matrix4by4.Transpose(rotationMatrix);

        return returnValue;
    }
    public Matrix4by4 InverseScale()
    {

        Matrix4by4 returnValue = new Matrix4by4(new Vector3(1, 0, 0) / scale.x, new Vector3(0, 1, 0) / scale.y, new Vector3(0, 0, 1) / scale.z, Vector3.zero);
        return returnValue;
    }
    public Quaternion setQuaternion(Vector4 input)
    {
        Quaternion rv = new Quaternion(input.x, input.y, input.z, input.w);

        return rv;
    }
    public Quat GetCurrentQuat()
    {
        //rv = Matrix4by4.Matrix4by4ToQuat(rotationMatrix);
        //Quat.FromUnityQuat(currentObject.transform.rotation);
        return currentQuat;
    }
}
