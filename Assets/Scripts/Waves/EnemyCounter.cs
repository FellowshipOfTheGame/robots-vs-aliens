using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private static TriggerVictory VictoryScript = null;
    private WaveProgressBar waveProgressBar;
    private static FixedWaveBehaviour fixedWaveBehaviour;
    public HugeWaveIcon hugeWaveIcon;

    private static int EnemyCountTotal = 0;
    private static int EnemiesKilled = 0;
    private static int enemiesSpawned = 0;
    
    private static float progress = 0.0f;

    public delegate void DelegateEnemyCounter();
    public static DelegateEnemyCounter OnEnemiesKilled;

    public int EnemiesSpawned
    {
        get { return enemiesSpawned; }
    }

    private void Start()
    {
        hugeWaveIcon = GameObject.Find("HugeWaveIcon").GetComponent<HugeWaveIcon>();
    }

    void Awake()
    {
        hugeWaveIcon = GameObject.Find("HugeWaveIcon").GetComponent<HugeWaveIcon>();
        waveProgressBar = GameObject.Find("WaveProgressBar").GetComponent<WaveProgressBar>();
        fixedWaveBehaviour = GameObject.Find("WaveGenerator").GetComponent<FixedWaveBehaviour>();
        
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
        int hugeIndex = -1;
        foreach(FixedWaveData w in level.Waves)
        {
            if (w.IsHuge)
                hugeIndex = EnemyCountTotal;
            EnemyCountTotal += w.EnemiesIndexes.Length;
        }
        //Sprint(hugeWaveIcon.name);
        hugeWaveIcon.SetIconPosition(hugeIndex, EnemyCountTotal);
    }

    public static void AddEnemyKilled()
    {
        EnemiesKilled++;
        if(EnemiesKilled >= EnemyCountTotal)
        {
            VictoryScript.Victory();
        }
        else if((EnemiesKilled == enemiesSpawned) && fixedWaveBehaviour.OnHold)
        {
            //OnEnemiesKilled?.Invoke();
            fixedWaveBehaviour.StartWave();
            Debug.Log("A huge wave is coming!");
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
