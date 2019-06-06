using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehavior : MonoBehaviour
{
    private Attack myAttack = null;
    private Animation animationScript = null;
    private CellOccupation occupiedCell = null;
    private BoxCollider2D myCollider = null;

    private bool rayCollision = false;

    [SerializeField] private Cooldown attackCooldown = null;
    [SerializeField] private Cooldown animationCooldown = null;



    private void Awake()
    {
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
        if (rayCollision)
        {
            myAttack.ReleaseAttack();
        }
    }

    private void AttackAnimation()
    {
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
        occupiedCell.UpdateCellOccupation(false);
        gameObject.GetComponent<DestroyObject>().DestroySelf();
    }

    bool RayCollision()
    {
        /*Physics2D.queriesStartInColliders = false;
        ContactFilter2D thisfilter = new ContactFilter2D();
        thisfilter.layerMask = LayerMask.GetMask("Alien"); */
        RaycastHit2D[] hitInfo = new RaycastHit2D[11];
        //Physics2D.Raycast(transform.position, transform.right, thisfilter, hitInfo);
        Physics2D.Raycast(transform.position, transform.right, new ContactFilter2D(), hitInfo);

        foreach (RaycastHit2D hit in hitInfo){
            if (hit.collider != null)
                if(hit.collider.CompareTag("Alien")) return true;
        }
        return false;
    }

}
