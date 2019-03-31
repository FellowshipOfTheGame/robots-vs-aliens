using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehavior : MonoBehaviour
{
    private Attack myAttack;

    private void Awake()
    {
        myAttack = gameObject.GetComponent<Attack>();
        InvokeRepeating("PeriodicAttack", myAttack._attackSpeed, myAttack._attackSpeed); //Start attacking
        gameObject.GetComponent<CollisionControl>().OnCollision += BeingAttacked;
        gameObject.GetComponent<Life>().OnDeath += Death;
    }

    //For taking damage
    private void BeingAttacked(GameObject collided)
    {
        //If object collided with was an alien projectile, then take damage
        if (collided != null && collided.CompareTag("AlienProjectile"))
        {
            gameObject.GetComponent<TakeDamage>().Damage(collided.GetComponent<Projectile>().damage);
            collided.GetComponent<DestroyObject>().DestroySelf();
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
        gameObject.GetComponent<DestroyObject>().DestroySelf();
    }

}
