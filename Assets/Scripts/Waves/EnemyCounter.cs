using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private static TriggerVictory VictoryScript = null;
    public WaveProgressBar waveProgressBar;

    private static int EnemyCountTotal = 0;
    private static int EnemiesKilled = 0;
    private static int enemiesSpawned = 0;

    private static float progress = 0.0f;

    public int EnemiesSpawned
    {
        get { return enemiesSpawned; }
    }

    private void Awake()
    {
        waveProgressBar = GameObject.Find("WaveProgressBar").GetComponent<WaveProgressBar>();
        VictoryScript = GetComponent<TriggerVictory>();        
    }

    private void ResetCounters()
    {
        EnemyCountTotal = 0;
        EnemiesKilled = 0;
        enemiesSpawned = 0;
    }

    public void SetupWaveInfo(LevelWavesData level)
    {
        ResetCounters();
        foreach(FixedWaveData w in level.Waves)
        {
            EnemyCountTotal += w.EnemiesIndexes.Length;
        }
    }

    public static void AddEnemyKilled()
    {
        EnemiesKilled++;
        if(EnemiesKilled >= EnemyCountTotal)
        {
            VictoryScript.Victory();
        }
    }

    public void AddSpawnedEnemy()
    {
        Debug.Log("Added");
        enemiesSpawned++;
        progress = ((float)enemiesSpawned / (float)EnemyCountTotal);
        waveProgressBar.UpdateProgressBar(progress);
    }
}
