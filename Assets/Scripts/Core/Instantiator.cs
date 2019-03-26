using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private Transform dynamic;

    public Object prefab;

    /*Instantiates object in set position, as dynamic child, and returns it*/
    public Object InstantiateObj(Vector3 position)
    {
        return Instantiate(prefab, position, Quaternion.identity, dynamic);
    }

    /*Instantiates object at (0, 0, 0), as dynamic child, and returns it*/
    public Object InstantiateObj()
    {
        return Instantiate(prefab, Vector3.zero, Quaternion.identity, dynamic);
    }
}
