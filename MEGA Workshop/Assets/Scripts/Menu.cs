using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Animations;
using System.Linq.Expressions;

public class Menu : MonoBehaviour
{
    public GameObject CubeItem;
    public GameObject CapsuleItem;
    public GameObject CylinderItem;
    private GameObject activeObject;
    public ObjectTransformation transformRef;
    public Camera cam;
    public TMPro.TextMeshProUGUI itemText;
    Vector2 lastDirection;
    Vector2 currentDirection;
    Quat currentQuat;
    Quat outputQuat;
    Quat pitchQuat;
    Quat yawQuat;
    Vector4 outputVector;
    Vector2 newDirection;
    void Start()
    {
        itemText.text = "Pick an Item";
        CubeItem.SetActive(false);
        CapsuleItem.SetActive(false);
        CylinderItem.SetActive(false);
        outputVector = Vector4.zero;
    }

    void Update()
    {
        if (CubeItem.activeSelf)
        {
            transformRef = CubeItem.GetComponent<ObjectTransformation>();
            activeObject = CubeItem;
        }
        else if (CapsuleItem.activeSelf)
        {
            transformRef = CapsuleItem.GetComponent<ObjectTransformation>();
            activeObject = CapsuleItem;
        }
        else if (CylinderItem.activeSelf)
        {
            transformRef = CylinderItem.GetComponent<ObjectTransformation>();
            activeObject = CylinderItem;
        }
        else
        {
            return;
        }

        currentQuat = transformRef.GetCurrentQuat();
        if(Input.GetMouseButton(1))
        {
            lastDirection = currentDirection;
            currentDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            newDirection = (currentDirection - lastDirection);

            //transformRef.rotation.y += -screenPostion.x;
            //transformRef.rotation.x += screenPostion.y;

            //float targetRotationX = transform.rotation.y - screenPostion.x;
            //float targetRotationY = transform.rotation.x + screenPostion.y;
            if(newDirection != Vector2.zero)
            {

                float angle = MathsLib.Length(currentDirection);
                //Vector3 outputAxis;
                Vector2 direction = currentDirection.normalized;

                //outputAxis = MathsLib.CrossProduct(currentDirection);

                yawQuat = new Quat(currentDirection.y, 1, 0, 0);

                pitchQuat = new Quat(-currentDirection.x, 0,1,0);

                outputQuat = pitchQuat * yawQuat;

                Quat resultQuat = outputQuat * currentQuat;

                transformRef.rotationQuat = resultQuat;
                //outputVector = resultQuat.AxisFromQuat();
                

                //outputQuat = new Quaternion(outputAxis.x, outputAxis.y, outputAxis.z, angle);
                //Quaternion resultQuat = outputQuat * cQuat;

                //transformRef.angle += outputVector.w / 100;
                //transformRef.rotation.x = outputVector.x;
                //transformRef.rotation.y = outputVector.y;
                //transformRef.rotation.z = outputVector.z;
            }
        }
    }
    public void CubeButton()
    {
        itemText.text = "Cube";
        CubeItem.SetActive(true);
        CapsuleItem.SetActive(false);
        CylinderItem.SetActive(false);
    }
    public void CapsuleButton()
    {
        itemText.text = "Capsule";
        CubeItem.SetActive(false);
        CapsuleItem.SetActive(true);
        CylinderItem.SetActive(false);
    }
    public void CylinderButton()
    {
        itemText.text = "Cylinder";
        CubeItem.SetActive(false);
        CapsuleItem.SetActive(false);
        CylinderItem.SetActive(true);
    }

}
