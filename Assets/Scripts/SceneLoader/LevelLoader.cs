﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    private CurrentScene CurrentSceneScript;

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

    public void RestartCurrentScene(){
        SceneManager.LoadScene(CurrentSceneScript.GetCurrentSceneIndex());
    }
}
