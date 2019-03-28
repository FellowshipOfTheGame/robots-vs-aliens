using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 0;

    [SerializeField] private DestroyObject destroyObjectComponent;
    [SerializeField] private OutOfBorder outOfBorderComponent;

    private void Start()
    {
        destroyObjectComponent = gameObject.GetComponent<DestroyObject>();
        outOfBorderComponent = gameObject.GetComponent<OutOfBorder>();
    }

    private void Update()
    {
        //if (outOfBorderComponent.OutOfBorders())
          //  destroyObjectComponent.DestroySelf();
    }

}
