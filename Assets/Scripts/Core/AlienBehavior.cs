using UnityEngine;

public class AlienBehavior : MonoBehaviour
{

    private static TriggerGameOver GameOverScript = null;

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
            if (lastRobotColidedWith != null) myAttack.ReleaseAttack(lastRobotColidedWith.transform.localPosition);
            else myAttack.ReleaseAttack(Vector3.left);
        }
    }

    //Destroys Object when dead
    private void Death()
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
