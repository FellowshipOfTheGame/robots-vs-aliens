using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private static TriggerVictory VictoryScript = null;
    private Life LifeScript = null;

    private static int EnemyCount = 0;
    private static int EnemiesKilled = 0;

    private void Awake()
    {
        VictoryScript = GetComponent<TriggerVictory>();        
    }

    public void SetupWaveInfo(LevelWavesData level)
    {
        EnemyCount = 0;
        EnemiesKilled = 0;
        foreach(FixedWaveData w in level.Waves)
        {
            EnemyCount += w.EnemiesIndexes.Length;
        }
    }

    public static void AddEnemyKilled()
    {
        EnemiesKilled++;
        if(EnemiesKilled >= EnemyCount)
        {
            VictoryScript.Victory();
        }
    }
}
