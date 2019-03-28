using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehavior : MonoBehaviour
{
    private Attack myAttack;
    private CollisionControl myCollisionControl;
    private bool willAttack = false;

    private void Start()
    {
        myAttack = gameObject.GetComponent<Attack>();
        myCollisionControl = gameObject.GetComponent<CollisionControl>();
        InvokeRepeating("PeriodicAttack", 0f, myAttack._attackSpeed); //Start attacking
    }

    private void Update()
    {
        BeingAttacked();
        Death();
        RobotEncounter();
    }

    //For taking damage
    private void BeingAttacked()
    {
        if (myCollisionControl.IsColliding())
        {
            //If last object collided with was a robot projectile, then take damage
            GameObject lastCollision = myCollisionControl.LastObjectCollided();
            if (lastCollision.CompareTag("RobotProjectile"))
            {
                gameObject.GetComponent<TakeDamage>().Damage(lastCollision.GetComponent<Projectile>().damage);
                lastCollision.GetComponent<DestroyObject>().DestroySelf();
            }
        }
    }

    //For doing his attacks
    private void PeriodicAttack()
    {
        if(willAttack)
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

    private void RobotEncounter()
    {
        if (myCollisionControl.IsColliding())
        {
            //If last object collided with was a robot, then stop moving and start attacking
            GameObject lastCollision = myCollisionControl.LastObjectCollided();
            if (lastCollision.CompareTag("Robot"))
            {
                gameObject.GetComponent<Movement>()._move = false;
                willAttack = true;
            }
        }
        else
        {
            gameObject.GetComponent<Movement>()._move = true;
            willAttack = false;
        }
    }

}
