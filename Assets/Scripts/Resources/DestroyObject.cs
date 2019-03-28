using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public delegate void DestroyDelegate();
    public DestroyDelegate OnDeath;

    public void DestroySelf()
    {
        OnDeath.Invoke();
        GameObject.Destroy(gameObject);
    }
}
