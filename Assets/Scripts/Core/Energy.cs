using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private int energy = 0;

    public void Start()
    {
        energy = 0;
    }

    /*Adds quantity to total of energy*/
    public void Add(int quantity)
    {
        SetEnergy(GetEnergy() + quantity);
    }

    //Energy getter
    public int GetEnergy()
    {
        return energy;
    }
    //Energy setter
    public void SetEnergy(int quantity)
    {
        energy = quantity;
    }

}
