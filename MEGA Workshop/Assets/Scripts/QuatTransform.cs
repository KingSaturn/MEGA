using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuatTransform : MonoBehaviour
{
    // Start is called before the first frame update
    [System.NonSerialized] public float t;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * 0.5f;

        Quat qA = new Quat(Mathf.PI * 0.5f, new Vector3(1, 0, 0));
        Quat qB = new Quat(Mathf.PI * 2.0f, new Vector3(0, 0, 0));

        Quat slerped = Quat.SLERP(qA, qB, t);

        Vector3 vectorPos = new Vector3(2, 2, 2);

        Quat qC = new Quat(vectorPos);

        Quat qD = slerped * qC * slerped.InverseQuat();

        Vector3 newPos = qD.GetAxis();

        transform.position = newPos;
    }
}
