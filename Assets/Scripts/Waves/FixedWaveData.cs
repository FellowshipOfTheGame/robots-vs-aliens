using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FixedWaveData", menuName = "Fixed Wave Data", order = 53)]
public class FixedWaveData : ScriptableObject
{
    [SerializeField] private float[] intervals;
    [SerializeField] private int[] enemiesIndexes;
    [SerializeField] private int[] cellsIndexes;
    [SerializeField] private bool isHuge = false;

    //[SerializeField] private int numberOfObjects = enemiesIndexes.Length;

    [SerializeField] private GameObject[] objects;

    public float [] Intervals
    {
        get { return intervals; }
    }

    public int [] EnemiesIndexes
    {
        get { return enemiesIndexes; }
    }

    public int [] CellsIndexes
    {
        get { return cellsIndexes; }
    }

    /*
    public int NumberOfObjects
    {
        get { return numberOfObjects; }
    }
    */
    public GameObject[] Objects
    {
        get { return objects; }
    }

    public bool IsHuge
    {
        get { return isHuge; }
    }
}
