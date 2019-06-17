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
    [SerializeField]
    private AudioClip SelectButtonClip = null;
    [SerializeField]
    private AudioClip BackButtonClip = null;
    [SerializeField]
    private AudioClip SlidersAndCheckboxInteractionClip = null;
    [SerializeField]
    private AudioClip PlaceRobotClip = null;
    [SerializeField]
    private AudioClip RobotShotClip = null;
    [SerializeField]
    private AudioClip BombClip = null;
    [SerializeField]
    private AudioClip PickEnergyClip = null;
    [SerializeField]
    private AudioClip ElectricityClip = null;

    private Toggle SFXMuteToggle = null;
    private Slider SFXVolumeSlider = null;

    // PRIVATE ATTRIBUTES
    private static Dictionary<string, AudioClip> Clips = null;

    private static string PrefsVolumeString = "SFXVolume";
    private static string PrefsMuteString = "SFXMute";

    void Awake()
    {
        Clips = new Dictionary<string, AudioClip>();
        FillClips();
        SceneManager.sceneLoaded += AddListenerToMuteButton;
        SceneManager.sceneLoaded += AddListenerToVolumeSlider;
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
        //if(scene.name == "Prototype")
        //{
            SFXMuteToggle = Resources.FindObjectsOfTypeAll<Toggle>()[1];
            SFXMuteToggle.onValueChanged.AddListener((bool mute) => ToggleMuteSFX(mute));
        //}
    }

    private void AddListenerToVolumeSlider(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Prototype")
        {
            SFXVolumeSlider = Resources.FindObjectsOfTypeAll<Slider>()[2];
            print(SFXVolumeSlider.name);

            SFXVolumeSlider.onValueChanged.AddListener((float volume) => ChangeSFXVolume(volume));
        }
        else if (scene.name == "Menu")
        {
            SFXVolumeSlider = Resources.FindObjectsOfTypeAll<Slider>()[0];
            print(SFXVolumeSlider.name);

            SFXVolumeSlider.onValueChanged.AddListener((float volume) => ChangeSFXVolume(volume));
        }
    }

    void FillClips()
    {
        Clips.Add("SelectButton", SelectButtonClip);
        Clips.Add("BackButton", BackButtonClip);
        Clips.Add("SlidersAndCheckboxInteraction", SlidersAndCheckboxInteractionClip);
        Clips.Add("PlaceRobot", PlaceRobotClip);
        Clips.Add("RobotShot", RobotShotClip);
        Clips.Add("Bomb", BombClip);
        Clips.Add("PickEnergy", PickEnergyClip);
        Clips.Add("Electricity", ElectricityClip);
    }

    public static void PlayClip(string key)
    {
        //print(key);
        AudioClip clip;
        if(Clips.TryGetValue(key, out clip))
        {
            //print("Play");
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
        if (mute)
        {
            //print("BackButton");
            PlayClip("BackButton");
        }
        else
            PlayClip("SelectButton");
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
