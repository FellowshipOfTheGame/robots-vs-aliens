using UnityEngine;

public class LoadProgressOnStart : MonoBehaviour
{
    void Start()
    {
        SaveData.Load();
    }
}
