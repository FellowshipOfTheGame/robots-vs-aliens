using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityCounter : MonoBehaviour
{
    private int electricity = 1000;

    public delegate void ElectricityCounterDelegate(string text);
    public ElectricityCounterDelegate OnElectricityChanged;

    public int Electricity
    {
        get { return electricity; }
        set { electricity = value; }
    }

    void Start(){

    }

    void Awake(){
    
    }

    public void AddElectricity(int value){
        this.electricity += value;
        OnElectricityChanged?.Invoke(this.electricity.ToString());
        //Debug.Log("electricity = " + this.electricity.ToString());
    }

    public void SubtractElectricity(int value){
        this.electricity -= value;
        OnElectricityChanged?.Invoke(this.electricity.ToString());
        //Debug.Log("electricity = " + this.electricity.ToString());
    }
}
