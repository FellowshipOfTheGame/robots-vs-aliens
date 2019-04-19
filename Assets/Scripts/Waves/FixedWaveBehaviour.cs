using System.Collections.Generic;
using UnityEngine;

public class FixedWaveBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyCounter CounterScript = null;

    private Transform GUIDynamic = null;

    [SerializeField] private LevelWavesData levelWavesData;
    private Cooldown CooldownScript;
    private SpawnObject SpawnObjectScript;

    [SerializeField]
    private List<GameObject> cells = new List<GameObject>();

    private int currentWave = 0;
    private int currentEnemy = 0;

    private bool isWaveGenerationDone = false;

    void Awake()
    {
        GUIDynamic = GameObject.Find("_GUIDynamic").transform;
        CooldownScript = GetComponent<Cooldown>();

        SpawnObjectScript = GetComponent<SpawnObject>();
        SpawnObjectScript.objectsToSpawn = levelWavesData.Waves[0].Objects;

        CounterScript.SetupWaveInfo(levelWavesData);

        CooldownScript.CooldownTime = levelWavesData.Waves[currentWave].Intervals[currentEnemy];
        //CooldownScript.CooldownTime = Random.Range(levelWavesData.Waves[currentWave].OffsetTimeBegin,
          //          levelWavesData.Waves[currentWave].OffsetTimeFinish);
        CooldownScript.ResetCooldown();

        CooldownScript.OnCooldownEnded += CooldownEnded;
    }

    public void CooldownEnded()
    {
        // Get the respective cell to instantiate
        int idCell = levelWavesData.Waves[currentWave].CellsIndexes[currentEnemy];
        Vector3 positionToSpawn = cells[idCell].transform.position;

        // Set enemy type and Instantiate
        int objId = levelWavesData.Waves[currentWave].EnemiesIndexes[currentEnemy];
        //int objId = Random.Range(0, levelWavesData.Waves[currentWave].Objects.Length);

        GameObject obj = SpawnObjectScript.Spawn(objId, positionToSpawn, Quaternion.identity, GUIDynamic);
        CounterScript.AddSpawnedEnemy();
        // Temporary
        //obj.transform.localPosition = positionToSpawn;
        //obj.transform.SetParent(GUIDynamic, false);
        //

        CheckTurn();
    }

    private void CheckTurn()
    {
        currentEnemy++;
        //CooldownScript.ResetCooldown();

        // If the current wave is over
        if (currentEnemy >= levelWavesData.Waves[currentWave].EnemiesIndexes.Length)
        {
            currentWave++;
            currentEnemy = 0;

            // If all waves are done
            if (currentWave >= levelWavesData.Waves.Count)
            {
                //isWaveGenerationDone = true;
                CooldownScript.OnCooldownEnded -= CooldownEnded;
            }
            else
            {       // Reset values
                CooldownScript.CooldownTime = levelWavesData.Waves[currentWave].Intervals[currentEnemy];
                SpawnObjectScript.objectsToSpawn = levelWavesData.Waves[currentWave].Objects;
                CooldownScript.ResetCooldown();
            }
        }
        else
        {   // Reset enemy spawn time counter
            CooldownScript.CooldownTime = levelWavesData.Waves[currentWave].Intervals[currentEnemy];
            CooldownScript.ResetCooldown();
        }
    }
}
