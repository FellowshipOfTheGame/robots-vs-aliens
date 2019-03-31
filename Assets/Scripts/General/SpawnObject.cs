using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject[] ObjectsToSpawn;

    public GameObject[] objectsToSpawn{
        get{return ObjectsToSpawn;}
        set{ObjectsToSpawn = value;}
    }

    public GameObject Spawn(int objectIndex, Vector3 position, Quaternion rotation, Transform parent)
    {
        return Instantiate(ObjectsToSpawn[objectIndex], position, rotation, parent);
    }

    public GameObject Spawn(Vector3 position, Quaternion rotation, Transform parent)
    {
        return Instantiate(ObjectsToSpawn[0], position, rotation, parent);
    }
}
