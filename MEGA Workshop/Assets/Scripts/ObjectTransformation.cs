using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransformation : MonoBehaviour
{
    Vector3[] modelSpaceVertices;
    public Vector3 position;
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

        Matrix4by4 translationMatrix = new Matrix4by4(new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1), new Vector3(position.x, position.y, position.z));

        for (int i = 0; i < transformedMatrix.Length; i++)
        {
            transformedMatrix[i] = translationMatrix * modelSpaceVertices[i];
        }
        MeshFilter MF = GetComponent<MeshFilter>();

        MF.mesh.vertices = transformedMatrix;

        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
