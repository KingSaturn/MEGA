using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    [System.NonSerialized] public float cameraSpeed = 2.0f;
    MyVector3 objectVelocity = new MyVector3(0,0,0);
    [SerializeField] Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float h = cameraSpeed * Input.GetAxis("Mouse X");
        float v = -cameraSpeed * Input.GetAxis("Mouse Y");
        MyVector3 currentForward = FromUnityVector(transform.forward);
        MyVector3 forwardNorm = currentForward.NormalizeMyVector();
        MyVector3 currentRight = FromUnityVector(transform.right);
        MyVector3 rightNorm = currentRight.NormalizeMyVector();
        MyVector3 newPos = FromUnityVector(transform.position);
        MyVector3 forwardVelocity = forwardNorm * speed * Time.deltaTime;
        MyVector3 rightVelocity = rightNorm * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            newPos = newPos + forwardVelocity;
            SetVelocity(forwardVelocity);
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos = newPos - forwardVelocity;
            SetVelocity(forwardVelocity);
        }
        if(Input.GetKey(KeyCode.D))
        {
            newPos = newPos + rightVelocity;
            SetVelocity(rightVelocity);
        }
        if(Input.GetKey(KeyCode.A))
        {
            newPos = newPos - rightVelocity;
            SetVelocity(rightVelocity);
        }
        Vector3 v3Pos = newPos.ToUnityVector();
        transform.position = v3Pos;
        transform.Rotate(0, h, 0);
        cam.transform.Rotate(v, 0, 0);
    }
    private void SetVelocity(MyVector3 velocity)
    {
        objectVelocity = velocity;
    }
    public MyVector3 GetVelocity()
    {
        MyVector3 returnVal = new MyVector3(0, 0, 0);
        returnVal = objectVelocity;
        return returnVal;
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
