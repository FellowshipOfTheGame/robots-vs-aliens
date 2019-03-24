using UnityEngine;

public class GeneratorBehaviour : MonoBehaviour
{
    private Cooldown CooldownScript;
    private SpawnObject SpawnObjectScript;
    private RandomElectricitySpawn RandomElectricityScript;

    [SerializeField] private bool IsRobot = false;
    private Vector2 SpawnPosition = new Vector2(0,0);

    private void Awake(){
        CooldownScript = GetComponent<Cooldown>();
        SpawnObjectScript = GetComponent<SpawnObject>();
        RandomElectricityScript = GetComponent<RandomElectricitySpawn>();
    }

    private void Update()
    {
        CheckCooldown();
    }

    private void CheckCooldown(){
        if(CooldownScript.IsCooldownDone){

            SpawnPosition = RandomElectricityScript.RandomSpawnPosition(IsRobot);

            GameObject obj = SpawnObjectScript.Spawn(SpawnPosition, Quaternion.identity, gameObject.transform);
            
            //TEMPORARIO, NÃO SEI COMO FAZER MELHOR
            obj.transform.localPosition = SpawnPosition;
            obj.GetComponent<MoveTopToBottom>().StartFall();
            //TEMPORARIO

            CooldownScript.ResetCooldown();
        }
    }
}
