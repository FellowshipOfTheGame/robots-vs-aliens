using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField] private static bool isPaused = false;

    private void Awake()
    {
        UnpauseGame();   
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
    }
    
    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    public void SwitchPause()
    {
        if (isPaused) UnpauseGame();
        else PauseGame();
    }


}
