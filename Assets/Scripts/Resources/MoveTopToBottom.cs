using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTopToBottom : MonoBehaviour
{
    [SerializeField]private float speed;

    void Update(){
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
