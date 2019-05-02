using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SFXController : MonoBehaviour
{
    private static AudioSource Source = null;

    // PUBLIC REFERENCES

    // PRIVATE REFERENCES
    [Header("References")]
    [SerializeField] private GameObject SFXSourcePrefab = null;

    [Header("Clips")]
    /*[SerializeField] private AudioClip ClickClip = null;
    [SerializeField] private AudioClip SwipeClip = null;
    //[SerializeField] private AudioClip WooshClip = null;
    [SerializeField] private AudioClip RightClip = null;
    [SerializeField] private AudioClip WrongClip = null;
    [SerializeField] private AudioClip PageClip = null;*/

    private Toggle SFXMuteToggle = null;

    // PRIVATE ATTRIBUTES
    private static Dictionary<string, AudioClip> Clips = null;

    private static string PrefsVolumeString = "SFXVolume";
    private static string PrefsMuteString = "SFXMute";

    void Awake()
    {
        Clips = new Dictionary<string, AudioClip>();
        FillClips();
        SceneManager.sceneLoaded += AddListenerToMuteButton;
    }

    private void Start()
    {
        if (Source == null)
        {
            GameObject obj = Instantiate(SFXSourcePrefab, new Vector3(0,0,-10), Quaternion.identity);
            Source = obj.GetComponent<AudioSource>();

            DontDestroyOnLoad(obj);
        }

        if (PlayerPrefs.GetInt(PrefsMuteString, 0) == 1)
        {
            Source.mute = true;
        }
        ChangeSFXVolume(PlayerPrefs.GetFloat(PrefsVolumeString, 1));
    }

    void AddListenerToMuteButton(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MenuFinal")
        {
            SFXMuteToggle = Resources.FindObjectsOfTypeAll<Toggle>()[0];
            SFXMuteToggle.onValueChanged.AddListener((bool mute) => ToggleMuteSFX(mute));

        }
        else if (scene.name == "GameFinal")
        {
            SFXMuteToggle = Resources.FindObjectsOfTypeAll<Toggle>()[2];
            SFXMuteToggle.onValueChanged.AddListener((bool mute) => ToggleMuteSFX(mute));
        }
    }

    void FillClips()
    {
        /*Clips.Add("PressButton", ClickClip);
        Clips.Add("ToggleWindow", SwipeClip);
        //Clips.Add("LoadScene", WooshClip);
        Clips.Add("CorrectAnswer", RightClip);
        Clips.Add("WrongAnswer", WrongClip);
        Clips.Add("FlipPage", PageClip);*/
    }

    public static void PlayClip(string key)
    {
        AudioClip clip;
        if(Clips.TryGetValue(key, out clip))
        {
            Source.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("No clip found! Try another name");
        }
    }

    public static void ToggleMuteSFX(bool mute)
    {
        Source.mute = mute;
        //PlayerPrefs.SetInt(PrefsString, mute ? 1 : 0);
    }

    public static void ChangeSFXVolume(float volume)
    {
        Source.volume = volume;
    }

    public static void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt(PrefsMuteString, Source.mute ? 1 : 0);
        PlayerPrefs.SetFloat(PrefsVolumeString, Source.volume);
    }

    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(PrefsVolumeString, 1);
    }

    public static bool GetMute()
    {
        if (PlayerPrefs.GetInt(PrefsMuteString, 0) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
