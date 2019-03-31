using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehavior : MonoBehaviour
{
    private Attack myAttack;
    private CollisionControl myCollisionControl;
    private bool willAttack = false;
    private GameObject lastRobotColidedWith = null;

    private void Awake()
    {
        myAttack = gameObject.GetComponent<Attack>();
        myCollisionControl = gameObject.GetComponent<CollisionControl>();
        InvokeRepeating("PeriodicAttack", myAttack._attackSpeed, myAttack._attackSpeed); //Start attacking

        gameObject.GetComponent<Life>().OnDeath += Death;
        myCollisionControl.OnCollision += BeingAttacked;
        myCollisionControl.OnCollision += RobotEncounter;
        //myCollisionControl.OnCollisionExit += noRobot;
    }

    private void Update()
    {
        noRobot();
    }

    public void BeingAttacked(GameObject colided)
    {
        //If last object collided with was a robot projectile, then take damage
        if (colided != null && colided.CompareTag("RobotProjectile"))
        {
            gameObject.GetComponent<TakeDamage>().Damage(colided.GetComponent<Projectile>().damage);
            colided.GetComponent<DestroyObject>().DestroySelf();
        }
    }

    //For doing his attacks
    private void PeriodicAttack()
    {
        if(willAttack)
            myAttack.ReleaseAttack(Vector3.left);
    }

    //Destroys Object when dead
    private void Death()
    {
       gameObject.GetComponent<DestroyObject>().DestroySelf();
    }

    public void RobotEncounter(GameObject colided)
    {
        //If last object collided with was a robot, then stop moving and start attacking
        if (colided != null && colided.CompareTag("Robot"))
        {
            lastRobotColidedWith = colided;
            gameObject.GetComponent<Movement>()._move = false;
            willAttack = true;
        }
    }

    private void noRobot()
    {
        if (lastRobotColidedWith == null)
        {
            willAttack = false;
            gameObject.GetComponent<Movement>()._move = true;
        }
    }

}
