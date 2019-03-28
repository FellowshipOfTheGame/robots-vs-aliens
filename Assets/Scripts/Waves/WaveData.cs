using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveData", menuName = "Wave Data", order = 51)]
public class WaveData : ScriptableObject
{
    [SerializeField] private float offsetTimeBegin;
    [SerializeField] private float offsetTimeFinish;

    [SerializeField] private int numberOfObjects;

    [SerializeField] private GameObject[] objects;

    public float OffsetTimeBegin{
        get{return offsetTimeBegin;}
    }

    public float OffsetTimeFinish{
        get{return offsetTimeFinish;}
    }

    public int NumberOfObjects{
        get{return numberOfObjects;}
    }

    public GameObject[] Objects{
        get{return objects;}
    }
}
