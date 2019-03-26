using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float durabilityTime = 0;
    public bool durability = false;

    private void FixedUpdate()
    {
        Durability();
    }

    //Checks if projectile has usefull life(vida util) and destroys it when it ends if so.
    private void Durability()
    {
        if (durability)
        {
            durabilityTime = durabilityTime - 1 * Time.deltaTime;
            if (durabilityTime < 0)
            {
                Destroy(gameObject); //Ser trocada pelo componente de destroy ou spawn.
            }
        }
    }
}
