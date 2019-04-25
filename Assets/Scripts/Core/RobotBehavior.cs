using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehavior : MonoBehaviour
{
    private Attack myAttack;
    private Animation animationScript;
    private CellOccupation occupiedCell;

    private void Awake()
    {
        myAttack = gameObject.GetComponent<Attack>();
        animationScript = GetComponent<Animation>();
        occupiedCell = transform.parent.GetComponent<CellOccupation>();
        if(myAttack != null)
        {
            InvokeRepeating("PeriodicAttack", myAttack._attackSpeed, myAttack._attackSpeed); //Start attacking
            InvokeRepeating("AttackAnimation", myAttack._attackSpeed-animationScript.animationTime, myAttack._attackSpeed); //Start attacking animation
        }
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

    private void AttackAnimation()
    {
        animationScript.PlayTriggerAnimation("Attack");
    }

    //Destroys Object when dead
    private void Death()
    {
        occupiedCell.UpdateCellOccupation(false);
        gameObject.GetComponent<DestroyObject>().DestroySelf();
    }

}
