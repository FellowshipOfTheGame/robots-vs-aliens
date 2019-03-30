using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public delegate void DestroyDelegate();
    public DestroyDelegate OnDestroy;

    public delegate void DestroyObjectDelegate(GameObject obj);
    public DestroyObjectDelegate OnObjectDestroy;

    public void DestroySelf()
    {
        OnDestroy?.Invoke();
        OnObjectDestroy?.Invoke(gameObject);
        GameObject.Destroy(gameObject);
    }
}
