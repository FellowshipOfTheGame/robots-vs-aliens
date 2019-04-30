using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBorder : MonoBehaviour
{   

    //PLACEHOLDER CLASS
    [SerializeField] private Vector3 border = Vector3.zero;

    private void Update()
    {
        OutOfBorders();
    }

    public void OutOfBorders()
    {
        if (transform.position.x > border.x)
        {
            gameObject.GetComponent<DestroyObject>().DestroySelf();
        }
    }
}
