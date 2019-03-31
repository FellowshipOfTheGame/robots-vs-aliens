using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourcesText : MonoBehaviour
{
    [SerializeField] private Text txtResources;
    [SerializeField] private ElectricityCounter ElectricityCounterScript;

    private void Awake()
    {
        ElectricityCounterScript.OnElectricityChanged += UpdateTextValue;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTextValue(string value)
    {
        txtResources.text = value.ToString();
    }
}
