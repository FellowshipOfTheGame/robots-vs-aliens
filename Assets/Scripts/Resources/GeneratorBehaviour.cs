using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBehaviour : MonoBehaviour
{
    private Cooldown cooldown;
    private SpawnObject spawnObject;
    private GenerateRandom generateRandom;

    [SerializeField] private int electricityIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        cooldown = GetComponent<Cooldown>();
        spawnObject = GetComponent<SpawnObject>();
        generateRandom = GetComponent<GenerateRandom>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCooldown();
    }

    private void CheckCooldown(){
        if(cooldown.IsCooldownDone){
            float distanceToInstantiate = 0f;
            //CASE 0: AUTOMATIC GENERATION - ELECTRICITY OBJECT FALLING
            if(electricityIndex == 0){
                distanceToInstantiate = gameObject.transform.position.x + generateRandom.GenerateRandomX();
            }
            else if(electricityIndex == 1){     // CASE 1: ROBOT GENERATOR
                distanceToInstantiate = gameObject.transform.position.x;
            }
            spawnObject.Spawn(0, new Vector3(distanceToInstantiate, gameObject.transform.position.y,
                gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
            cooldown.ResetCooldown();
            
        }
    }
}
