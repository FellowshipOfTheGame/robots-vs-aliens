using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourcesText : MonoBehaviour
{
    private Text txtResources;
    [SerializeField] private ElectricityCounter ElectricityCounterScript = null;

    private void Awake()
    {
        txtResources = GetComponent<Text>();
        ElectricityCounterScript.OnElectricityChanged += UpdateTextValue;
    }

    public void UpdateTextValue(string value)
    {
        txtResources.text = value.ToString();
    }
}
