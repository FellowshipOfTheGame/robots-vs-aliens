using UnityEngine;
using UnityEngine.UI;

public class SavingTest : MonoBehaviour
{
    int progress = 0;
    public Text progressText;

    // MONOBEHAVIOUR METHODS

    private void Start()
    {
        LoadProgress();
    }

    private void OnEnable()
    {
        SaveData.OnBeforeSave += ApplyData;
        SaveData.OnLoad += LoadData;
    }

    private void OnDisable()
    {
        SaveData.OnBeforeSave -= ApplyData;
        SaveData.OnLoad -= LoadData;
    }

    // DELEGATE METHODS

    public void ApplyData()
    {
        SaveData.AddProgressData(progress);
    }

    public void LoadData()
    {
        progress = SaveData._data.Progress;
        progressText.text = "Current progress: " + progress;
    }

    // BUTTON CALL METHODS

    public void AddProgress()
    {
        progress++;
        progressText.text = "Current progress: " + progress;
    }

    public void SaveProgress()
    {
        SaveData.Save(SaveData._data);
    }

    public void LoadProgress()
    {
        SaveData.Load();
    }

    public void ResetSave()
    {
        progress = 0;
        SaveData.ResetSave();
        LoadData();
    }
}
