using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interpolate : MonoBehaviour
{
    public float speed;

    private void Start()
    {

    }
    private void Update()
    {
        MyVector3 currentPos = FromUnityVector(transform.position);
        MyVector3 newPos = new MyVector3(0, 0, 0); 

        MyVector3 direction = currentPos - newPos;
        MyVector3 directionNorm = direction.NormalizeMyVector();

        MyVector3 velocity = directionNorm * speed * Time.deltaTime;

        if (MyVector3.DotProduct(direction, velocity) >= 0.5)
        {
            Vector3 v3newPos = transform.position + velocity.ToUnityVector();
            transform.position = v3newPos;
        }
    }
    public MyVector3 FromUnityVector(Vector3 Input)
    {
        MyVector3 returnVal = new MyVector3(0, 0, 0);
        returnVal.x = Input.x;
        returnVal.y = Input.y;
        returnVal.z = Input.z;
        return returnVal;
    }
}
