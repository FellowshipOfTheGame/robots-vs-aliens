using UnityEngine;

public class EnergyGenerator : MonoBehaviour
{

    [SerializeField] private Energy _energy;

    /*Generates set quantity of energy and spawns energy object in scene*/
    public void GenerateEnergy(int quantity, Energy energy)
    {
        energy.SetEnergy(energy.GetEnergy() + quantity);
        gameObject.GetComponent<Instantiator>().InstantiateObj();
    }

    /*Generates set quantity of energy and spawns energy object in scene*/
    public void GenerateEnergy(int quantity)
    {
        _energy.SetEnergy(_energy.GetEnergy() + quantity);
        gameObject.GetComponent<Instantiator>().InstantiateObj();
    }

}
