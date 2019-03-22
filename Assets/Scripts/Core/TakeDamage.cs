using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    public void Damage(int damageDone)
    {
        Life life = gameObject.GetComponent<Life>();
        life.setLife(life.getLife() - damageDone);
    }

}
