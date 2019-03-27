using UnityEngine;

public class Destroyer : MonoBehaviour
{
    /*Destroys object passed as parameter*/
    public void DestroyEntity(Object entity)
    {
        Destroy(entity);
    }
    /*Destroys the gameObject with this component*/
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
