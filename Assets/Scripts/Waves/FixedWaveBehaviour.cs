using System.Collections.Generic;
using UnityEngine;

public class FixedWaveBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyCounter CounterScript = null;

    private Transform GUIDynamic = null;

    [SerializeField] private LevelWavesData[] AllLevels;
    private LevelWavesData CurrentLevel = null;
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

        CurrentLevel = AllLevels[CheckCurrentLevel()];

        SpawnObjectScript.objectsToSpawn = CurrentLevel.Waves[0].Objects;

        CounterScript.SetupWaveInfo(CurrentLevel);

        CooldownScript.CooldownTime = CurrentLevel.Waves[currentWave].Intervals[currentEnemy];
        //CooldownScript.CooldownTime = Random.Range(CurrentLevel.Waves[currentWave].OffsetTimeBegin,
          //          CurrentLevel.Waves[currentWave].OffsetTimeFinish);
        CooldownScript.ResetCooldown();

        CooldownScript.OnCooldownEnded += CooldownEnded;
    }

    public void CooldownEnded()
    {
        // Get the respective cell to instantiate
        int idCell = CurrentLevel.Waves[currentWave].CellsIndexes[currentEnemy];
        Vector3 positionToSpawn = cells[idCell].transform.position;

        // Set enemy type and Instantiate
        int objId = CurrentLevel.Waves[currentWave].EnemiesIndexes[currentEnemy];
        //int objId = Random.Range(0, CurrentLevel.Waves[currentWave].Objects.Length);

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
        if (currentEnemy >= CurrentLevel.Waves[currentWave].EnemiesIndexes.Length)
        {
            currentWave++;
            currentEnemy = 0;

            // If all waves are done
            if (currentWave >= CurrentLevel.Waves.Count)
            {
                //isWaveGenerationDone = true;
                CooldownScript.OnCooldownEnded -= CooldownEnded;
            }
            else
            {       // Reset values
                CooldownScript.CooldownTime = CurrentLevel.Waves[currentWave].Intervals[currentEnemy];
                SpawnObjectScript.objectsToSpawn = CurrentLevel.Waves[currentWave].Objects;
                CooldownScript.ResetCooldown();
            }
        }
        else
        {   // Reset enemy spawn time counter
            CooldownScript.CooldownTime = CurrentLevel.Waves[currentWave].Intervals[currentEnemy];
            CooldownScript.ResetCooldown();
        }
    }

    private int CheckCurrentLevel()
    {
        Debug.Log("Progress" + SaveData._data.Progress);
        return SaveData._data.Progress;
    }
}
