using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public void onCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "")
        {
            Debug.Log(collision.gameObject.name);
        }
        if(collision.gameObject.tag == "")
        {
            Debug.Log(collision.gameObject.tag);
        }
    }



}
