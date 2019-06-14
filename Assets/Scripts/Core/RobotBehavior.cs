using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehavior : MonoBehaviour
{
    private Attack myAttack = null;
    private Animation animationScript = null;
    private CellOccupation occupiedCell = null;
    private BoxCollider2D myCollider = null;
    private Life myLife = null;

    private bool rayCollision = false;

    [SerializeField] private Cooldown attackCooldown = null;
    [SerializeField] private Cooldown animationCooldown = null;
    [SerializeField] private Cooldown deathCooldown = null;

    [SerializeField]private int robotId = 0;


    private void Awake()
    {
        deathCooldown = gameObject.AddComponent<Cooldown>();
        myAttack = gameObject.GetComponent<Attack>();
        animationScript = GetComponent<Animation>();
        myCollider = GetComponent<BoxCollider2D>();
        occupiedCell = transform.parent.GetComponent<CellOccupation>();
        if(myAttack != null)
        {
            attackCooldown.CooldownTime = animationScript.animationTime;
            animationCooldown.CooldownTime = myAttack._attackSpeed;

            attackCooldown.OnCooldownEnded += PeriodicAttack;
            animationCooldown.OnCooldownEnded += AttackAnimation;
        }
        gameObject.GetComponent<CollisionControl>().OnCollision += BeingAttacked;
        myLife = gameObject.GetComponent<Life>();
        myLife.OnDeath += Death;
    }

    private void Destroy()
    {
        occupiedCell.UpdateCellOccupation(false);
        gameObject.GetComponent<DestroyObject>().DestroySelf();
    }

    //For taking damage
    private void BeingAttacked(GameObject collided)
    {
        if (!myLife.isAlive()) return;
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
        if (!myLife.isAlive()) return;
        if (rayCollision)
        {
            if (robotId == 0)
                SFXController.PlayClip("RobotShot");
            myAttack.ReleaseAttack();
        }
    }

    private void AttackAnimation()
    {
        if (!myLife.isAlive()) return;
        rayCollision = RayCollision();
        if (rayCollision)
        {
            animationScript.PlayTriggerAnimation("Attack");
            animationCooldown.ResetCooldown();
            attackCooldown.ResetCooldown();
        }
    }

    //Destroys Object when dead
    private void Death()
    {
        myCollider.enabled = false;
        deathCooldown.CooldownTime = animationScript.deathAnimationTime;
        animationScript.PlayTriggerAnimation("Die");
        deathCooldown.ResetCooldown();
        deathCooldown.OnCooldownEnded += Destroy;
    }

    private bool RayCollision()
    {
        if (!myLife.isAlive()) return false;
        RaycastHit2D[] hitInfo = new RaycastHit2D[11];
        Physics2D.Raycast(transform.position, transform.right, new ContactFilter2D(), hitInfo);

        foreach (RaycastHit2D hit in hitInfo){
            if (hit.collider != null)
                if(hit.collider.CompareTag("Alien")) return true;
        }
        return false;
    }

}
