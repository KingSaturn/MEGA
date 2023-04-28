using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject CubeItem;
    public GameObject CapsuleItem;
    public GameObject CylinderItem;
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
