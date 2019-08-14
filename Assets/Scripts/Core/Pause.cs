using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private static bool isPaused = false;
    [SerializeField] private GameObject pauseWindow = null;
    [SerializeField] private Animator pauseAnimator = null;

    private void Awake()
    {
        if(isPaused) UnpauseGame();   
        pauseAnimator.ResetTrigger("CloseWindow");
    }

    public void PauseGame()
    {
        SFXController.PlayClip("SelectButton");
        isPaused = true;
        pauseAnimator?.SetTrigger("OpenWindow");
        Time.timeScale = 0;
    }
    
    public void UnpauseGame()
    {
        SFXController.PlayClip("BackButton");
        isPaused = false;
        pauseAnimator?.SetTrigger("CloseWindow");
        Time.timeScale = 1;
    }

    public void TogglePause()
    {
        if (isPaused) UnpauseGame();
        else PauseGame();
    }


}
