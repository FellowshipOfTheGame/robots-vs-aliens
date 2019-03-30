using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public delegate void DestroyDelegate();
    //public DestroyDelegate OnDeath;

    public void DestroySelf()
    {
        GameObject.Destroy(gameObject);
    }
}
