using UnityEngine;

public class Collision : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "")
        {
            Debug.Log(collision.gameObject.name);
        }
        if(collision.gameObject.tag == "")
        {
            Debug.Log(collision.gameObject.tag);
        }
    }



}
