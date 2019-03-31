using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    public delegate void CollisionDelegate(GameObject colided);

    public CollisionDelegate OnCollision;
    public CollisionDelegate OnCollisionExit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision?.Invoke(collision.gameObject);
        //DEBUG
        //Debug.Log("Colidi com: " + collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnCollisionExit?.Invoke(collision.gameObject);
        //DEBUG
        //Debug.Log("Nao colido mais com" + collision.gameObject);
    }

}
