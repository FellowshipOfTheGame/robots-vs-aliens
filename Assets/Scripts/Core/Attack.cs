using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float damage = 0f;         //Attack Damage
    [SerializeField] private float speed = 0f;          //Projectile speed
    [SerializeField] private Vector2 direction = Vector2.zero;
    [SerializeField] private SpawnObject mySpawnObject;

    public float _attackSpeed = 0.5f;  //Seconds per attack

    private void Start()
    {
        mySpawnObject = gameObject.GetComponent<SpawnObject>();
    }

    public void ReleaseAttack()
    {
        GameObject attack = mySpawnObject.Spawn(0, Vector3.zero, Quaternion.identity, transform);

        attack.GetComponent<Projectile>().damage = damage;
        if(attack.GetComponent<Movement>() != null)
            attack.GetComponent<Movement>().setParameters(speed, direction);
    }

    //Funcao para futuros upgrades na planta
    public void changeParameters(float damage, float speed, float attackSpeed)
    {
        this.damage = damage;
        this.speed = speed;
        this._attackSpeed = attackSpeed;
    }
}
