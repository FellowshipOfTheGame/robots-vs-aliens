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

        if (durability)
        {
            CooldownComponent.OnCooldownEnded += CooldownEnded;
        }
    }

    public void CooldownEnded()
    {
        gameObject.GetComponent<DestroyObject>().DestroySelf();
    }
}
