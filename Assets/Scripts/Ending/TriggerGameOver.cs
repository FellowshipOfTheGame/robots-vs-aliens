using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{
    private GameObject GameOverText;
    [SerializeField] private GameObject GameOverWindow;
    [SerializeField] private GameObject MenuButton;

    private void Awake()
    {
        //FindObjectOfType<EnemyCounter>().OnWaveEnd += GameOver;    
    }

    public void GameOver()
    {
        GameOverWindow.SetActive(true);
        MenuButton.SetActive(true);
    }
}
