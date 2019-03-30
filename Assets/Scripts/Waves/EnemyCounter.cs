using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public delegate void EnemyCounterDelegate();
    public EnemyCounterDelegate OnWaveEnd;

    private List<GameObject> EnemyList;

    public void AddEnemy(GameObject enemy)
    {
        enemy.GetComponent<DestroyObject>().OnObjectDestroy += RemoveEnemy;
        EnemyList.Add(enemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        EnemyList.Remove(enemy);
        if(EnemyList.Count == 0)
        {
            OnWaveEnd?.Invoke();
        }
    }
}
