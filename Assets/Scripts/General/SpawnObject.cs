using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject[] ObjectsToSpawn;

    public GameObject Spawn(int objectIndex, Vector3 position, Quaternion rotation, Transform parent)
    {
        return Instantiate(ObjectsToSpawn[objectIndex], position, rotation, parent);
    }
}
