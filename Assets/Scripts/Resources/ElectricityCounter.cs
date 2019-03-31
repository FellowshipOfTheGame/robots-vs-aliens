using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityCounter : MonoBehaviour
{
    private int electricity = 0;

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

    public void AddElectricity(int electricity){
        this.electricity += electricity;
        OnElectricityChanged.Invoke(electricity.ToString());
        //Debug.Log("electricity = " + this.electricity.ToString());
    }

    public void SubtractElectricity(int electricity){
        this.electricity -= electricity;
        OnElectricityChanged.Invoke(electricity.ToString());
        //Debug.Log("electricity = " + this.electricity.ToString());
    }
}
