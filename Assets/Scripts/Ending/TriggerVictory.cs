using UnityEngine;

public class TriggerVictory : MonoBehaviour
{
    [SerializeField] private GameObject BlackScreen = null;
    [SerializeField] private GameObject VictoryText = null;
    [SerializeField] private GameObject MenuButton = null;
    [SerializeField] private Pause PauseManager = null;

    public void Victory()
    {
        SaveData.AddProgressData(SaveData._data.Progress + 1);
        //SaveData.Save(SaveData._data);

        BlackScreen.SetActive(true);
        VictoryText.SetActive(true);
        MenuButton.SetActive(true);
        //PauseManager.PauseGame();
        Time.timeScale = 0;
    }
}
