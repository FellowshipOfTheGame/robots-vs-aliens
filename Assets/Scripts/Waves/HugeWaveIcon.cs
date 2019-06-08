using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HugeWaveIcon : MonoBehaviour
{
    public GameObject slider;
    
    private Vector2 destiny;
    private Movement movement;
    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (movement._move)
        {
            if (gameObject.transform.GetComponent<RectTransform>().anchoredPosition.y <= destiny.y)
                movement._move = false;
        } 
    }

    public void SetIconPosition(int hugeIndex, int enemyCount)
    {
        hugeIndex = 2;
        enemyCount = 4;
        //float width = GetComponent<RectTransform>().offsetMin.x - transform.GetComponent<RectTransform>().offsetMax.x;
        /*
        //print("width = " + width);
        //gameObject.transform.position = new Vector3(fillArea.transform.position.x - width, fillArea.transform.position.y, 
        //fillArea.transform.position.z);
        float left = width - 20;
        GetComponent<RectTransform>().offsetMin = new Vector2(width, gameObject.transform.GetComponent<RectTransform>().offsetMin.y);
        GetComponent<RectTransform>().offsetMax = new Vector2(- (width - left), gameObject.transform.GetComponent<RectTransform>().offsetMin.y);
        //float width = gameObject.transform.parent.GetComponent<RectTransform>().sizeDelta.x;*/
        if(hugeIndex != -1)
        {
            print("Active");
            gameObject.SetActive(true);
            float width = slider.GetComponent<RectTransform>().offsetMin.x - slider.transform.GetComponent<RectTransform>().offsetMax.x;

            float position = hugeIndex * (width / enemyCount);
            print(position);
            gameObject.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(position,
            gameObject.transform.GetComponent<RectTransform>().anchoredPosition.y);
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }

    public void OnHugeWave()
    {
        destiny = new Vector2(gameObject.transform.GetComponent<RectTransform>().anchoredPosition.x,
            gameObject.transform.GetComponent<RectTransform>().anchoredPosition.y - 10f);
         
    }
}
