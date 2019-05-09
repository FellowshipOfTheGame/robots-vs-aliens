using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeBehaviour : MonoBehaviour
{
    private CollisionControl myCollisionControl;
    private Movement movementScript;
    private Cooldown cooldownScript;

    private GameObject lastCollided = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        myCollisionControl = gameObject.GetComponent<CollisionControl>();

        myCollisionControl.OnCollision += Move;
        myCollisionControl.OnCollision += AlienEncounter;
        myCollisionControl.OnCollisionExit += AlienEncounter;


        movementScript = gameObject.GetComponent<Movement>();

        cooldownScript = gameObject.GetComponent<Cooldown>();

        cooldownScript.OnCooldownEnded += CooldownEnded;
        cooldownScript.CooldownRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move(GameObject collided)
    {
        if (collided != null && collided.CompareTag("Alien"))
        {
            movementScript._move = true;
        }
    }

    private void AlienEncounter(GameObject collided)
    {
        //If object collided was an alien, basically destroys it.
        if (collided != null && collided.CompareTag("Alien"))
        {
            Debug.Log("Collided");
            //attackScript.ReleaseAttack(collided.transform.localPosition);
            /*attackScript.ReleaseAttack(collided.transform.localPosition);
            Debug.Log("AlienEncounter");*/

            if(lastCollided != collided)
            {
                lastCollided = collided;

                collided.gameObject.GetComponent<AlienBehavior>().Death();

                if (!cooldownScript.CooldownRunning)
                {
                    cooldownScript.ResetCooldown();
                }
            }

            
        }

        
    }

    private void CooldownEnded()
    {
        gameObject.GetComponent<DestroyObject>().DestroySelf();
    }
}
