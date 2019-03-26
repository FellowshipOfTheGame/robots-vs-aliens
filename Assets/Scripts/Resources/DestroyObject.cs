using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public void DestroySelf()
    {
        GameObject.Destroy(gameObject);
    }
}
