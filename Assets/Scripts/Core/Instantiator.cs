using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public Transform dynamic;
    public Object prefab;

    /*Instantiates object in set position*/
    public void InstantiateObj(Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity, dynamic);
    }

    /*Instantiates object at (0, 0, 0)*/
    public void InstantiateObj()
    {
        Instantiate(prefab, Vector3.zero, Quaternion.identity, dynamic);
    }
}
