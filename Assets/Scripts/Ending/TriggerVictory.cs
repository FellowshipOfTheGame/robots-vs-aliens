using UnityEngine;

public class TriggerVictory : MonoBehaviour
{
    [SerializeField] private GameObject BlackScreen = null;
    [SerializeField] private GameObject VictoryText = null;
    [SerializeField] private GameObject MenuButton = null;

    public void Victory()
    {
        BlackScreen.SetActive(true);
        VictoryText.SetActive(true);
        MenuButton.SetActive(true);
    }
}
