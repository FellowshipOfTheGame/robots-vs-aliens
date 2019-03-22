using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGenerator : MonoBehaviour
{

    [SerializeField] private Energy _energy;

    /*Generates set quantity of energy and spawns energy object in scene*/
    public void GenerateEnergy(int quantity, Energy energy)
    {
        energy.setEnergy(energy.getEnergy() + quantity);
        gameObject.GetComponent<Instantiator>().InstantiateObj();
    }

    /*Generates set quantity of energy and spawns energy object in scene*/
    public void GenerateEnergy(int quantity)
    {
        _energy.setEnergy(_energy.getEnergy() + quantity);
        gameObject.GetComponent<Instantiator>().InstantiateObj();
    }

}
