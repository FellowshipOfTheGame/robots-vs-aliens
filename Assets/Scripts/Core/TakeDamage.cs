using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    //Damages the object with this component
    public void Damage(float damageDone)
    {
        damageDone = damageDone < 0 ?  -damageDone : damageDone; //Sets damage to positive
        Life life = gameObject.GetComponent<Life>(); //Gets the Life component of the gameObject
        life.DecreaseLife(damageDone); //Decreases life by damageDone
    }

}
