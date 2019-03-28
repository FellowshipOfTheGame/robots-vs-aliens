using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    [SerializeField] private GameObject lastCollision = null;
    [SerializeField] private bool isColliding = false;

    public delegate void CollisionDelegate();

    //PROVISORIO
    public CollisionDelegate OnAlienAttackCollision;
    public CollisionDelegate OnRobotAttackCollision;
    //PROVISORIO

    public CollisionDelegate OnEnemyCollision;

    private void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();
        Rigidbody2D rigid = gameObject.AddComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lastCollision = collision.gameObject;
        
        if (collision.gameObject.CompareTag("EnemyProjectile")){
            OnAlienAttackCollision.Invoke();
        }
        else if (collision.gameObject.CompareTag("RobotProjectile"))
        {
            OnRobotAttackCollision.Invoke();
        }
        else if (collision.gameObject.CompareTag("Robot"))
        {
            //collision.gameObject.GetComponent<DestroyObject>().OnDeath += 
            OnEnemyCollision.Invoke();
        }
        //DEBUG
        Debug.Log("Colidi com: " + collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }

    public GameObject LastObjectCollided()
    {
        GameObject entity = lastCollision;
        lastCollision = null;
        return entity;
    }
}
