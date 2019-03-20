using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintName : MonoBehaviour
{
    public void PrintObjectName()
    {
        Debug.Log("Object -> " + gameObject.name, gameObject);
    }
}
