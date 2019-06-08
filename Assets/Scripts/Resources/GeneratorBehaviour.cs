using UnityEngine;

public class GeneratorBehaviour : MonoBehaviour
{
    private Transform GUIDynamic = null;

    private Cooldown CooldownScript;
    private Cooldown AnimationCooldown;
    private Animation AnimationScript;
    private SpawnObject SpawnObjectScript;
    private RandomElectricitySpawn RandomElectricityScript;

    [SerializeField] private bool IsRobot = false;
    [SerializeField] private float secondCooldown = 0f;
    private Vector2 SpawnOffset = new Vector2(0,0);

    private void Awake(){
        GUIDynamic = GameObject.Find("_GUIDynamic").transform;

        AnimationScript = GetComponent<Animation>();
        CooldownScript = GetComponent<Cooldown>();
        SpawnObjectScript = GetComponent<SpawnObject>();
        RandomElectricityScript = GetComponent<RandomElectricitySpawn>();

        if (AnimationScript != null) InvokeRepeating("PlayAnimation", CooldownScript.CooldownTime - AnimationScript.animationTime, CooldownScript.CooldownTime);

        CooldownScript.OnCooldownEnded += CooldownEnded;
    }

    public void CooldownEnded()
    {
        SpawnOffset = RandomElectricityScript.RandomSpawnPosition(IsRobot);

        GameObject obj = SpawnObjectScript.Spawn(transform.position+(Vector3)SpawnOffset, Quaternion.identity, GUIDynamic);
        obj.GetComponent<MoveTopToBottom>().StartFall();
        SFXController.PlayClip("Electricity");
        if (IsRobot)
        {
            CooldownScript.CooldownTime = secondCooldown;
            if (AnimationScript != null)
            {
                CancelInvoke("PlayAnimation");
                InvokeRepeating("PlayAnimation", CooldownScript.CooldownTime - AnimationScript.animationTime, CooldownScript.CooldownTime);
            }
        }
        CooldownScript.ResetCooldown();
    }

    public void PlayAnimation()
    {
        AnimationScript.PlayTriggerAnimation("Generate");
    }
}
