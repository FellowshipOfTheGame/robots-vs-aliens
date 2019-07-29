using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public Text levelText;

    private void Start(){
        UpdateText();
    }

    public void UpdateText(){
        levelText.text = (SaveData._data.Progress+1).ToString();
    }

    public void ResetProgress(){
        SaveData.ResetSave();
    }
}
