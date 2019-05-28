using UnityEngine;

public class AlienBehavior : MonoBehaviour
{

    private static TriggerGameOver GameOverScript = null;

    private Attack myAttack;
    private CollisionControl myCollisionControl;
    private bool willAttack = false;
    private GameObject lastRobotColidedWith = null;
    private Animation myAnimation;

    private void Awake()
    {
        myAttack = gameObject.GetComponent<Attack>();
        myAnimation = gameObject.GetComponent<Animation>();
        myCollisionControl = gameObject.GetComponent<CollisionControl>();
        InvokeRepeating("PeriodicAttack", myAttack._attackSpeed, myAttack._attackSpeed); //Start attacking

        gameObject.GetComponent<Life>().OnDeath += Death;
        myCollisionControl.OnCollision += BeingAttacked;
        myCollisionControl.OnCollision += RobotEncounter;
        myCollisionControl.OnCollision += ReachedEndOfScreen;

        //myCollisionControl.OnCollisionExit += noRobot;
    }

    private void Update()
    {
        noRobot();
    }

    public void ReachedEndOfScreen(GameObject collided)
    {
        if(GameOverScript == null)
        {
            GameOverScript = FindObjectOfType<TriggerGameOver>();
        }
        //If collided with the end of screen, triggers game over
        if (collided != null && collided.CompareTag("GameOver"))
        {
            GameOverScript.GameOver();
        }
    }

    public void BeingAttacked(GameObject collided)
    {
        //If last object collided with was a robot projectile, then take damage
        if (collided != null && collided.CompareTag("RobotProjectile"))
        {
            gameObject.GetComponent<TakeDamage>().Damage(collided.GetComponent<Projectile>().damage);
            collided.GetComponent<DestroyObject>().DestroySelf();
        }
    }

    //For doing his attacks
    private void PeriodicAttack()
    {
        if (willAttack)
        {
            Debug.Log(lastRobotColidedWith.name + " Health: " + lastRobotColidedWith.GetComponent<Life>().getLife());//DEBUG
            if (lastRobotColidedWith != null) myAttack.ReleaseAttack(lastRobotColidedWith.transform.position);
            else myAttack.ReleaseAttack(transform.position + Vector3.left);
        }
    }

    //Destroys Object when dead
    public void Death()
    {
        EnemyCounter.AddEnemyKilled();
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
            myAnimation.ChangeAnimationBool("willAttack", willAttack);
        }
    }

    private void noRobot()
    {
        if (lastRobotColidedWith == null)
        {
            willAttack = false;
            gameObject.GetComponent<Movement>()._move = true;
            myAnimation.ChangeAnimationBool("willAttack", willAttack);
        }
    }

}
