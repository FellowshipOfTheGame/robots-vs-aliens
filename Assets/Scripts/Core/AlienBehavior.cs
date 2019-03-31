using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehavior : MonoBehaviour
{
    private Attack myAttack;
    private CollisionControl myCollisionControl;
    private bool willAttack = false;

    private void Awake()
    {
        myAttack = gameObject.GetComponent<Attack>();
        myCollisionControl = gameObject.GetComponent<CollisionControl>();
        InvokeRepeating("PeriodicAttack", myAttack._attackSpeed, myAttack._attackSpeed); //Start attacking

        myCollisionControl.OnRobotAttackCollision += BeingAttacked;
        myCollisionControl.OnEnemyCollision += RobotEncounter;
    }

    private void Update()
    {
        Death();
    }

    public void BeingAttacked()
    {
        //If last object collided with was a robot projectile, then take damage
        GameObject lastCollision = myCollisionControl.LastObjectCollided();
        if (lastCollision.CompareTag("RobotProjectile"))
        {
            gameObject.GetComponent<TakeDamage>().Damage(lastCollision.GetComponent<Projectile>().damage);
            lastCollision.GetComponent<DestroyObject>().DestroySelf();
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

    public void RobotEncounter()
    {
        /*if (myCollisionControl.IsColliding())
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
        }*/
    }

}
