using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{

    [SerializeField] private GameObject lastCollision = null;
    [SerializeField] private bool isColliding = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lastCollision = collision.gameObject;
        isColliding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }

    public GameObject LastObjectCollided()
    {
        GameObject entity = lastCollision;
        lastCollision = null;
        return entity;
    }

    public bool IsColliding()
    {
        return isColliding;
    }



}
