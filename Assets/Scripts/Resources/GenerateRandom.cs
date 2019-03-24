using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandom : MonoBehaviour
{
    [SerializeField]private float xStart;
    [SerializeField]private float xEnd;

    [SerializeField]private float yStart;
    [SerializeField]private float yEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GenerateRandomX(){
        return Random.Range(xStart, xEnd);
    }

    public float GenerateRandomY(){
        return Random.Range(yStart, yEnd);
    }
}
