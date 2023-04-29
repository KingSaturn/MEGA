using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject CubeItem;
    public GameObject CapsuleItem;
    public GameObject CylinderItem;
    public ObjectTransformation transformRef;
    public Camera cam;
    public TMPro.TextMeshProUGUI itemText;
    void Start()
    {
        itemText.text = "Pick an Item";
        CubeItem.SetActive(false);
        CapsuleItem.SetActive(false);
        CylinderItem.SetActive(false);
    }

    void Update()
    {
        //if(CubeItem.activeSelf)
        //{
        //    transformRef = CubeItem.GetComponent<ObjectTransformation>();
        //}
        if(Input.GetMouseButton(1))
        {
            Vector2 screenPostion = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            transformRef.rotation.y += -screenPostion.x;
            transformRef.rotation.x += screenPostion.y;

            float targetRotationX = transform.rotation.y - screenPostion.x;
            float targetRotationY = transform.rotation.x + screenPostion.y;


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
