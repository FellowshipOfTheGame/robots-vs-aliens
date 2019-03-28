    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public bool durability = false;

    private Cooldown CooldownComponent;

    private void Start()
    {
        CooldownComponent = gameObject.GetComponent<Cooldown>();
        CooldownComponent.ResetCooldown();
    }

    private void FixedUpdate()
    {
        Durability();
    }

    //Checks if projectile has usefull life(vida util) and destroys it when it ends if so.
    private void Durability()
    {
        if (durability)
        {
            if (CooldownComponent.IsCooldownDone)
            {
                gameObject.GetComponent<DestroyObject>().DestroySelf();
            }
        }
    }
}
