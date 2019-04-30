using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveData", menuName = "Wave Data", order = 51)]
public class WaveData : ScriptableObject
{
    [SerializeField] private float offsetTimeBegin = 0;
    [SerializeField] private float offsetTimeFinish = 0;

    [SerializeField] private int numberOfObjects = 0;

    [SerializeField] private GameObject[] objects = null;

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
