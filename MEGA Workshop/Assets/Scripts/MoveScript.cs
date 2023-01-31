using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float speed;

    private void Start()
    {

    }
    private void Update()
    {
        GameObject evaderObj = GameObject.Find("Evader");
     

        MyVector3 persuerPos = FromUnityVector(transform.position);
        MyVector3 evaderPos = FromUnityVector(evaderObj.transform.position);
        MyVector3 direction = evaderPos - persuerPos;
        MyVector3 directionNorm = direction.NormalizeMyVector();
        MyVector3 evaderDirection = FromUnityVector(evaderObj.transform.forward);
        MyVector3 velocity = directionNorm * speed * Time.deltaTime;
        if(MyVector3.DotProduct(evaderDirection, direction) >= 0.5)
        {
            Vector3 v3newPos = transform.position + velocity.ToUnityVector();
            transform.position = v3newPos;
        }
        Debug.Log(MyVector3.DotProduct(evaderDirection, direction));
        
    }
    public MyVector3 FromUnityVector(Vector3 Input)
    {
        MyVector3 returnVal = new MyVector3(0,0,0);
        returnVal.x = Input.x;
        returnVal.y = Input.y;
        returnVal.z = Input.z;
        return returnVal;
    }
}
