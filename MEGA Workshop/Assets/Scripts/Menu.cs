using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject CubeItem;
    public GameObject CapsuleItem;
    public TMPro.TextMeshProUGUI itemText;
    void Start()
    {
        itemText.text = "Cube";
        CubeItem.SetActive(true);
        CapsuleItem.SetActive(false);
    }

    void Update()
    {
        
    }
    public void CubeButton()
    {
        itemText.text = "Cube";
        CubeItem.SetActive(true);
        CapsuleItem.SetActive(false);
    }
    public void CapsuleButton()
    {
        itemText.text = "Capsule";
        CapsuleItem.SetActive(true);
        CubeItem.SetActive(false);
    }
    public void NullButton()
    {
        itemText.text = "NULL";
        CubeItem.SetActive(false);
        CapsuleItem.SetActive(false);
    }
    
}
