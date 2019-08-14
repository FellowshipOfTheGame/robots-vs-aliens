using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    private CurrentScene CurrentSceneScript;

    //temporary
    public MusicController musicController;
    public AudioClip gameMusic;
    public float gameMusicLoopTime;

    public AudioClip menuMusic;
    public float menuMusicLoopTime;

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
        SaveData.Save(SaveData._data);

        if (sceneName == "Prototype")
        {
            musicController.ChangeTrackInstantly(gameMusic, gameMusicLoopTime);
        }
        else if(sceneName == "Menu")
        {
            musicController.ChangeTrackInstantly(menuMusic, menuMusicLoopTime);
        }

        SceneManager.LoadScene(sceneName);
    }

    public void RestartCurrentScene(){

        string sceneName = CurrentSceneScript.GetCurrentSceneName();

        LoadScene(sceneName);
    }
}
