using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ObjectTransformation : MonoBehaviour
{
    public Mesh meshInstance;
    Vector3[] modelSpaceVertices;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter MF = GetComponent<MeshFilter>();
        modelSpaceVertices = MF.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] transformedMatrix = new Vector3[modelSpaceVertices.Length];

        Matrix4by4 rollMatrix = new Matrix4by4(new Vector3(Mathf.Cos(rotation.z), Mathf.Sin(rotation.z), 0), new Vector3(-Mathf.Sin(rotation.z), Mathf.Cos(rotation.z), 0), new Vector3(0, 0, 1), Vector3.zero);
        Matrix4by4 pitchMatrix = new Matrix4by4(new Vector3(1,0,0), new Vector3(0, Mathf.Cos(rotation.x), Mathf.Sin(rotation.x)), new Vector3(0, -Mathf.Sin(rotation.x), Mathf.Cos(rotation.x)), Vector3.zero);
        Matrix4by4 yawMatrix = new Matrix4by4(new Vector3(Mathf.Cos(rotation.y), 0, -Mathf.Sin(rotation.y)), new Vector3(0,1,0), new Vector3(Mathf.Sin(rotation.y), 0, Mathf.Cos(rotation.y)), Vector3.zero);
        Matrix4by4 rotatMatrix = yawMatrix * (pitchMatrix * rollMatrix);

        Matrix4by4 scaleMatrix = new Matrix4by4(new Vector3(1, 0, 0) * scale.x, new Vector3(0, 1, 0) * scale.y, new Vector3(0, 0, 1) * scale.z, Vector3.zero);
        Matrix4by4 translationMatrix = new Matrix4by4(new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1), new Vector3(position.x, position.y, position.z));

        Matrix4by4 matrixTransform = translationMatrix * (rotatMatrix * scaleMatrix);
        for (int i = 0; i < transformedMatrix.Length; i++)
        {
            transformedMatrix[i] = matrixTransform * new Vector4(modelSpaceVertices[i].x, modelSpaceVertices[i].y, modelSpaceVertices[i].z, 1);
        }
        MeshFilter MF = GetComponent<MeshFilter>();

        MF.mesh.vertices = transformedMatrix;

        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
