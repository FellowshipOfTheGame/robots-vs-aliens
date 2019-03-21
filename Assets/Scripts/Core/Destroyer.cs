using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Object entity;

    /*Destroys object passed as parameter*/
    public void DestroyEntity(Object entity)
    {
        Destroy(entity);
    }
    /*Destroys object passed through Inspector*/
    public void DestroyEntity()
    {
        Destroy(this.entity);
    }
}
