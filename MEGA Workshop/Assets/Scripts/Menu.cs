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
    public ObjectTransformation transformRef;
    public Camera cam;
    public TMPro.TextMeshProUGUI itemText;
    Vector2 lastPosition;
    Vector2 currentDirection;
    Vector2 direction;
    Quat currentQuat;
    Quat outputQuat;
    Vector4 outputVector;
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
        //if(CubeItem.activeSelf)
        //{
        //    transformRef = CubeItem.GetComponent<ObjectTransformation>();
        //}
        currentQuat = transformRef.GetQuat();
        if(Input.GetMouseButton(1))
        {
            currentDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            //transformRef.rotation.y += -screenPostion.x;
            //transformRef.rotation.x += screenPostion.y;

            //float targetRotationX = transform.rotation.y - screenPostion.x;
            //float targetRotationY = transform.rotation.x + screenPostion.y;

            Vector3 outputAxis = MathsLib.CrossProduct(currentDirection);

            float angle = MathsLib.Length(currentDirection);

            outputQuat = new Quat(angle, outputAxis);
            Quat resultQuat = outputQuat * currentQuat;
            outputVector = resultQuat.AxisFromQuat();

            //transformRef.angle = outputVector.w;
            //transformRef.rotation.x = outputVector.x;
            //transformRef.rotation.y = outputVector.y;
            //transformRef.rotation.z = outputVector.z;

            lastPosition = currentDirection;

            Debug.Log(resultQuat.w);
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
