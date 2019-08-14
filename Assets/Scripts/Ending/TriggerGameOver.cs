using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{
    private GameObject GameOverText;
    [SerializeField] private GameObject GameOverWindow = null;
    [SerializeField] private GameObject MenuButton = null;
    [SerializeField] private Pause PauseManager = null;

    private void Awake()
    {
        //FindObjectOfType<EnemyCounter>().OnWaveEnd += GameOver;    
    }

    public void GameOver()
    {
        GameOverWindow.SetActive(true);
        MenuButton.SetActive(true);
        //PauseManager.PauseGame();
        Time.timeScale = 0;
    }
}
