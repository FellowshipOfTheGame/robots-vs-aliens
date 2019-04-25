using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelWavesData", menuName = "Level Waves Data", order = 52)]
public class LevelWavesData : ScriptableObject
{
    [SerializeField] private int level;

    [SerializeField] private List <FixedWaveData> waves = new List<FixedWaveData>();

    public List<FixedWaveData> Waves{
        get{return waves;}
    }
}
