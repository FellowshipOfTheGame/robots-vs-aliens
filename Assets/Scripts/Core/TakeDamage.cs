using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private Life _life;

    public void Damage(int damageDone)
    {
        _life.setLife(_life.getLife() - damageDone);
    }

}
