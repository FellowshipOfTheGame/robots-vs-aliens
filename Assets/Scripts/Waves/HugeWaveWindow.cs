using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeWaveWindow : MonoBehaviour
{
    private Cooldown cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        cooldown = gameObject.AddComponent<Cooldown>();
        cooldown.OnCooldownEnded += DeactivateWindow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateWindow()
    {
        gameObject.SetActive(true);
        cooldown.ResetCooldown();
    }

    public void DeactivateWindow()
    {
        gameObject.SetActive(false);
    }
}
