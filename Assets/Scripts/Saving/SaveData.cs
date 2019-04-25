using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static Data _data;

    public delegate void SerializeAction();
    public static event SerializeAction OnBeforeSave;
    public static event SerializeAction OnLoad;

    private static string Path = string.Empty;

    // MONOBEHAVIOUR METHODS

    private void Awake()
    {
        //Defines the default path of saving and loading for the game. Usable in any platform
        Path = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    // PUBLIC METHODS

    //Public method for saving all game data. Has a delegate call before saving
    public static void Save(Data data)
    {
        OnBeforeSave?.Invoke();

        SaveToJSON(data);
    }

    //Public method for resetting all saved data
    public static void ResetSave()
    {
        _data = new Data(0);

        //PlayerPrefs.SetInt("SFXMute", 0);
        //PlayerPrefs.SetInt("MusicMute", 0);

        Save(_data);
    }

    //Public method for loading game data. Calls necessary methods when loading. Has a delegate call after loading
    public static void Load()
    {
        _data = LoadFromJSON();

        //EXECUTE STUFF WHEN LOADED

        OnLoad?.Invoke();
    }

    //Public method for changing the progress value in the temporary game data
    public static void AddProgressData(int progress)
    {
        _data.Progress = progress;
    }

    // PRIVATE METHODS

    //Converts save data (of type Data) into a JSON string and saves to file at main path location
    private static void SaveToJSON(Data data)
    {
        string json = JsonUtility.ToJson(data);

        StreamWriter writer = File.CreateText(Path);
        writer.Close();

        File.WriteAllText(Path, json);
    }

    //Opens the file at the main path location and converts the info into a save data (of type Data). If there is no file open, creates an initial save data
    private static Data LoadFromJSON()
    {
        if (!File.Exists(Path))
        {
            Debug.Log("Save data does not exist");
            //initialize a new game data with initial values
            _data = new Data(0);

            SaveToJSON(_data);
            if (File.Exists(Path))
            {
                Debug.Log("Save data exists now");
            }
        }
        else Debug.Log("Save data exists");

        string json = File.ReadAllText(Path);

        return JsonUtility.FromJson<Data>(json);
    }
}
