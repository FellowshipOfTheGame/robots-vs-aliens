using UnityEngine;

public class ElectricityBehaviour : MonoBehaviour
{
    [SerializeField]private int score = 0;

    private ElectricityCounter CounterScript;

    void Start(){
        CounterScript = FindObjectOfType<ElectricityCounter>();
    }

    public void InteractWithElectricity(){
        SFXController.PlayClip("PickEnergy");
        CounterScript.AddElectricity(score);
        Destroy(gameObject);
    }
}
