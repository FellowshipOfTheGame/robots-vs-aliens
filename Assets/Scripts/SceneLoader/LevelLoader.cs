﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    private CurrentScene CurrentSceneScript;

    [SerializeField] private int LevelsStartIndex = 0;

    private void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this){
            Destroy(gameObject);
        }

        CurrentSceneScript = GetComponent<CurrentScene>();
    }
    
    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene(LevelsStartIndex + levelNumber);
    }

    public void RestartCurrentScene(){
        SceneManager.LoadScene(CurrentSceneScript.GetCurrentSceneIndex());
    }
}
