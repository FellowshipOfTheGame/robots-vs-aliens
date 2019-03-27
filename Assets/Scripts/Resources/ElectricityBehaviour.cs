using UnityEngine;

public class ElectricityBehaviour : MonoBehaviour
{
    [SerializeField]private int score;

    private ElectricityCounter CounterScript;
    void Start(){
        CounterScript = FindObjectOfType<ElectricityCounter>();
    }

    public void InteractWithElectricity(){
        CounterScript.AddElectricity(score);
        Destroy(gameObject);
    }
}
