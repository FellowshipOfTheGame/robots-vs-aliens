using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameOver : MonoBehaviour
{
    public KeyCode TestKey;
    TriggerGameOver Script;

    private void Awake()
    {
        Script = GetComponent<TriggerGameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(TestKey))
        {
            Script.GameOver();
        }
    }
}
