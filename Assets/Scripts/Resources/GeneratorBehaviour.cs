using UnityEngine;

public class GeneratorBehaviour : MonoBehaviour
{
    private Transform GUIDynamic = null;

    private Cooldown CooldownScript;
    private SpawnObject SpawnObjectScript;
    private RandomElectricitySpawn RandomElectricityScript;

    [SerializeField] private bool IsRobot = false;
    private Vector2 SpawnPosition = new Vector2(0,0);

    private void Awake(){
        GUIDynamic = GameObject.Find("_GUIDynamic").transform;

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

            GameObject obj = SpawnObjectScript.Spawn(SpawnPosition, Quaternion.identity, transform);
            
            //TEMPORARIO, NÃO SEI COMO FAZER MELHOR
            obj.transform.localPosition = SpawnPosition;
            obj.transform.SetParent(GUIDynamic, false);
            obj.GetComponent<MoveTopToBottom>().StartFall();
            //TEMPORARIO

            CooldownScript.ResetCooldown();
        }
    }
}
