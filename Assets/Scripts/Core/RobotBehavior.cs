using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehavior : MonoBehaviour
{
    private Attack myAttack;

    private void Start()
    {
        myAttack = gameObject.GetComponent<Attack>();
        InvokeRepeating("PeriodicAttack", 0f, myAttack._attackSpeed); //Start attacking
    }

    private void Update()
    {
        BeingAttacked();
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
                lastCollision.GetComponent<DestroyObject>().DestroySelf();
            }
        }
    }

    //For doing his attacks
    private void PeriodicAttack()
    {
        myAttack.ReleaseAttack();
    }

    //Destroys Object when dead
    private void Death()
    {
        if (!gameObject.GetComponent<Life>().isAlive())
        {
            gameObject.GetComponent<DestroyObject>().DestroySelf();
        }
    }

}
