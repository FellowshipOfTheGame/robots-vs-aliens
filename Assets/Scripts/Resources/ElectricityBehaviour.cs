using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityBehaviour : MonoBehaviour
{
    [SerializeField]private int score;

    private Player player;
    void Start(){
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void InteractWithElectricity(){
        player.AddElectricity(score);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("Collision");
        if(col.gameObject.name == "EndOfScreen")
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("Collision");
        if(col.gameObject.name == "EndOfScreen")
            Destroy(gameObject);
    }
}
