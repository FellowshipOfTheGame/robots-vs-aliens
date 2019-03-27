using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehavior : MonoBehaviour
{

    private void Update()
    {
        BeingAttacked();
        PeriodicAttack();
    }

    //For taking damage
    private void BeingAttacked()
    {
        CollisionControl myCollision = gameObject.GetComponent<CollisionControl>();
        if (myCollision.IsColliding())
        {
            //If last object collided with was an enemy projectile, then take damage
            GameObject lastCollision = myCollision.LastObjectCollided();
            if (lastCollision.CompareTag("EnemyProjectile"))
            {
                gameObject.GetComponent<TakeDamage>().Damage(lastCollision.GetComponent<Projectile>().damage);
            }
        }


    }

    //For doing his attacks
    private void PeriodicAttack()
    {
        Attack myAttack = gameObject.GetComponent<Attack>();
        if (Time.time % myAttack._attackSpeed == 0)
        {
            myAttack.ReleaseAttack();
        }
    }

}
