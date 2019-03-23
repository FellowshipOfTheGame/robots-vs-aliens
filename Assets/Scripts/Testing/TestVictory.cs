using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVictory : MonoBehaviour
{
    public KeyCode TestKey;
    TriggerVictory Script;

    private void Awake()
    {
        Script = GetComponent<TriggerVictory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(TestKey))
        {
            Script.Victory();
        }
    }
}
