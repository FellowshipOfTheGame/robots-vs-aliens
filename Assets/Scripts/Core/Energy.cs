using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private int energy = 0;

    public void Start()
    {
        energy = 0;
    }

    /*Adds quantity to total of energy*/
    public void add(int quantity)
    {
        setEnergy(getEnergy() + quantity);
    }

    //Energy getter
    public int getEnergy()
    {
        return energy;
    }
    //Energy setter
    public void setEnergy(int quantity)
    {
        energy = quantity;
    }

}
