using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public bool isOveraped = false;

    Renderer myRenderer;

    public Color touchColor;
    Color originalColor;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOveraped = true;
            myRenderer.material.color = touchColor;
        }
    }

    void OnTriigerExit(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOveraped = false;
            myRenderer.material.color = originalColor;
        }
    }

    void OnTriigerStay(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOveraped = true;
            myRenderer.material.color = touchColor;
        }
    }
}
