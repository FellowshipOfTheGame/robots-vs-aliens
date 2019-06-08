using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float damage = 0f;         //Attack Damage
    [SerializeField] private float speed = 0f;          //Projectile speed
    [SerializeField] private Vector2 direction = Vector2.zero;
    private SpawnObject mySpawnObject;

    private Transform GUIDynamic = null;

    public float _attackSpeed = 0f;  //Seconds per attack


    private void Awake()
    {
        GUIDynamic = GameObject.FindGameObjectWithTag("Dynamic").transform;
        mySpawnObject = gameObject.GetComponent<SpawnObject>();
    }

    public void ReleaseAttack()
    {
        GameObject attack = mySpawnObject.Spawn(0, transform.position, Quaternion.identity, GUIDynamic);
        
        attack.GetComponent<Projectile>().damage = damage;
        if(attack.GetComponent<Movement>() != null)
            attack.GetComponent<Movement>().setParameters(speed, direction);
    }

    //With Specified location
    public void ReleaseAttack(Vector3 local)
    {
        GameObject attack = mySpawnObject.Spawn(0, local, Quaternion.identity, GUIDynamic);

        attack.GetComponent<Projectile>().damage = damage;
        if (attack.GetComponent<Movement>() != null)
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
