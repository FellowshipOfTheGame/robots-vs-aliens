using UnityEngine;

public class Explode : MonoBehaviour
{
    private Cooldown myCooldown;
    [SerializeField] private Transform _Dynamic;

    private void Start()
    {
        myCooldown = gameObject.GetComponent<Cooldown>();
        myCooldown.OnCooldownEnded += ExplodeObject;
        _Dynamic = GameObject.FindGameObjectWithTag("Dynamic").transform;
    }

    public void ExplodeObject()
    {
        gameObject.GetComponent<SpawnObject>().Spawn(transform.position, Quaternion.identity, _Dynamic);
        Debug.Log("Exploding...");
    }
}
