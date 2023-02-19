using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interpolate : MonoBehaviour
{
    public float speed;
    public float targetX;
    public float targetY;
    public float targetZ;
    public MyVector3 targetPosition = new MyVector3(0,0,0);
    private void Start()
    {
        targetPosition.x = targetX;
        targetPosition.y = targetY;
        targetPosition.z = targetZ;
    }
    private void Update()
    {
        MyVector3 currentPos = FromUnityVector(transform.forward);
        MyVector3 direction = targetPosition - currentPos;
        MyVector3 directionNorm = direction.NormalizeMyVector();

        MyVector3 velocity = MathsLib.MyLerp(currentPos, directionNorm, 0.5f) * speed * Time.deltaTime;
        Vector3 v3newPos = transform.position + velocity.ToUnityVector();
        if(v3newPos.z < 20.0f)
        {
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
