using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int electricity = 0;

    void Start(){

    }

    void Awake(){
    
    }

    public void AddElectricity(int electricity){
        this.electricity += electricity;
        Debug.Log("electricity = " + this.electricity.ToString());
    }

    public void SubtractElectricity(int electricity){
        this.electricity -= electricity;
        Debug.Log("electricity = " + this.electricity.ToString());
    }
}
