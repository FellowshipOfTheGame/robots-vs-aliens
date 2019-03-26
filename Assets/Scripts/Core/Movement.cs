using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0;
    public Vector2 direction = Vector2.zero;

    private Rigidbody2D myRigidBody;

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        myRigidBody.velocity = direction * speed;
        Debug.Log(myRigidBody.velocity);
    }
}
