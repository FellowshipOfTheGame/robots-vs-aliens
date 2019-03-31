    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public bool durability = false;

    private Cooldown CooldownComponent;

    private void Awake()
    {
        CooldownComponent = gameObject.GetComponent<Cooldown>();

        if (durability)
        {
            CooldownComponent.OnCooldownEnded += CooldownEnded;
        }

    }

    public void CooldownEnded()
    {
        if(gameObject != null)
            gameObject.GetComponent<DestroyObject>().DestroySelf();
    }
}
