using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBorder : MonoBehaviour
{
    [SerializeField] private Vector3 border;
    public bool OutOfBorders()
    {
        if (transform.position.x > border.x)
        {
            return true;
        }
        else return false;
    }
}
