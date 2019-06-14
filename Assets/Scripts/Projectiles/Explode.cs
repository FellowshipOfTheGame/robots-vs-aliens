using UnityEngine;

public class Explode : MonoBehaviour
{
    private Cooldown myCooldown;
    private Transform _Dynamic;

    private void Start()
    {
        myCooldown = gameObject.GetComponent<Cooldown>();
        myCooldown.OnCooldownEnded += ExplodeObject;
        _Dynamic = GameObject.FindGameObjectWithTag("Dynamic").transform;
    }

    public void ExplodeObject()
    {
        SFXController.PlayClip("Bomb");
        gameObject.GetComponent<SpawnObject>().Spawn(transform.position, Quaternion.identity, _Dynamic);
        Life life = GetComponent<Life>();
        life.DecreaseLife(life.getLife());
    }
}
