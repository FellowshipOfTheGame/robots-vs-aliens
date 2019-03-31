using UnityEngine;

public class GeneratorBehaviour : MonoBehaviour
{
    private Transform GUIDynamic = null;

    private Cooldown CooldownScript;
    private SpawnObject SpawnObjectScript;
    private RandomElectricitySpawn RandomElectricityScript;

    [SerializeField] private bool IsRobot = false;
    private Vector2 SpawnOffset = new Vector2(0,0);

    private void Awake(){
        GUIDynamic = GameObject.Find("_GUIDynamic").transform;

        CooldownScript = GetComponent<Cooldown>();
        SpawnObjectScript = GetComponent<SpawnObject>();
        RandomElectricityScript = GetComponent<RandomElectricitySpawn>();

        CooldownScript.OnCooldownEnded += CooldownEnded;
    }

    public void CooldownEnded()
    {
        SpawnOffset = RandomElectricityScript.RandomSpawnPosition(IsRobot);

        GameObject obj = SpawnObjectScript.Spawn(transform.position+(Vector3)SpawnOffset, Quaternion.identity, GUIDynamic);
        obj.GetComponent<MoveTopToBottom>().StartFall();

        CooldownScript.ResetCooldown();
    }
}
