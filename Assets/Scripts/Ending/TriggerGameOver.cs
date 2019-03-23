﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{
    private GameObject GameOverText;
    [SerializeField] private GameObject GameOverWindow;
    [SerializeField] private GameObject MenuButton;

    public void GameOver()
    {
        GameOverWindow.SetActive(true);
        MenuButton.SetActive(true);
    }
}
