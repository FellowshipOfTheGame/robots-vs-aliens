using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    //Reference to both audio sources that can play music tracks
    private static AudioSource Source1 = null;
    private static AudioSource Source2 = null;

    // PUBLIC REFERENCES
    [Header("References")]
    public AudioClip MusicTrack;
    public float LoopDuration;

    [Space(20)]
    // PRIVATE REFERENCES
    [SerializeField] private GameObject MusicSourcePrefab = null;
    private Toggle MusicMuteToggle = null;

    [Space(20)]
    // PRIVATE ATTRIBUTES
    [SerializeField] private float FadeDuration = 2;
    [SerializeField] private float BlendDuration = 2;

    private int CurrentSource = 1;
    private bool IsFading = false;
    private bool IsBlending = false;

    private static string PrefsMuteString = "MusicMute";
    private static string PrefsVolumeString = "MusicVolume";

    // --- MONOBEHAVIOUR METHODS ---

    private void Start()
    {
        if (Source1 == null && Source2 == null)
        {
            GameObject obj = Instantiate(MusicSourcePrefab, new Vector3(0, 0, -10), Quaternion.identity);
            Source1 = obj.transform.GetChild(0).GetComponent<AudioSource>();
            Source2 = obj.transform.GetChild(1).GetComponent<AudioSource>();

            DontDestroyOnLoad(obj);
        }

        Source1.clip = MusicTrack;
        if (!Source1.isPlaying)
        {
            Source1.Play();
            StartCoroutine(LoopTrackAtTime(MusicTrack, Source1, Source2, LoopDuration));
        }

        if (PlayerPrefs.GetInt(PrefsMuteString, 0) == 1)
        {
            Source1.mute = true;
            Source2.mute = true;
        }
        ChangeMusicVolume(PlayerPrefs.GetFloat(PrefsVolumeString, 1));
    }

    // --- PUBLIC METHODS --

    public void ChangeTrackInstantly(AudioClip newTrack, float loopTime)
    {
        if (CurrentSource == 1)
        {
            StopAllCoroutines();
            Source1.clip = newTrack;
            Source1.Play();
            StartCoroutine(LoopTrackAtTime(newTrack, Source2, Source1, loopTime));
        }
        else if (CurrentSource == 2)
        {
            StopAllCoroutines();
            Source2.clip = newTrack;
            Source2.Play();
            StartCoroutine(LoopTrackAtTime(newTrack, Source1, Source2, loopTime));
        }
    }

    public void ChangeTrackBlend(AudioClip newTrack, float loopTime, float BlendDuration)
    {
        if (!IsBlending)
        {
            if (CurrentSource == 1)
            {
                StopAllCoroutines();
                Source2.clip = newTrack;
                Source2.Play();
                StartCoroutine(BlendTracks(Source1, Source2));
                StartCoroutine(LoopTrackAtTime(newTrack, Source1, Source2, loopTime));
                CurrentSource = 2;
            }
            else if (CurrentSource == 2)
            {
                StopAllCoroutines();
                Source1.clip = newTrack;
                Source1.Play();
                StartCoroutine(BlendTracks(Source2, Source1));
                StartCoroutine(LoopTrackAtTime(newTrack, Source2, Source1, loopTime));
                CurrentSource = 1;
            }
        }
    }

    // --- MUSIC MANIPULATION METHODS ---

    public static void ChangeMusicVolume(float volume)
    {
        Source1.volume = volume;
        Source2.volume = volume;
        //PlayerPrefs.SetFloat(PrefsVolumeString, volume);
    }

    public static void ToggleMuteMusic(bool mute)
    {
        Source1.mute = mute;
        Source2.mute = mute;
        //PlayerPrefs.SetInt(PrefsMuteString, mute ? 1 : 0);
    }

    public static void SavePlayerPrefs()
    {
        PlayerPrefs.SetFloat(PrefsVolumeString, Source1.volume);
        PlayerPrefs.SetInt(PrefsMuteString, Source1.mute ? 1 : 0);
    }

    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(PrefsVolumeString, Source1.volume);
    }

    public static bool GetMute()
    {
        if(PlayerPrefs.GetInt(PrefsMuteString, 0) == 1){
            return true;
        }
        else
        {
            return false;
        }
    }
   
    IEnumerator FadeOutTrack(AudioSource Source)
    {
        IsFading = true;
        float time = 0;
        while (time <= FadeDuration)
        {
            Source.volume = 1 - (time / FadeDuration);
            time += Time.deltaTime;
            yield return null;
        }
        Source.Stop();
        IsFading = false;
    }

    IEnumerator FadeInTrack(AudioSource Source)
    {
        IsFading = true;
        Source.Play();
        float time = 0;
        while (time <= FadeDuration)
        {
            Source.volume = time / FadeDuration;
            time += Time.deltaTime;
            yield return null;
        }
        IsFading = false;
    }

    IEnumerator BlendTracks(AudioSource FadeOutSource, AudioSource FadeInSource)
    {
        IsBlending = true;
        float time = 0;
        while (time <= BlendDuration)
        {
            FadeOutSource.volume = 1 - (time / BlendDuration);
            FadeInSource.volume = time / BlendDuration;
            time += Time.deltaTime;
            yield return null;
        }
        FadeOutSource.Stop();
        IsBlending = false;
    }

    IEnumerator LoopTrackAtTime(AudioClip clip, AudioSource currentSource, AudioSource newSource, float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Looping");
        newSource.clip = clip;
        newSource.Play();
        StartCoroutine(LoopTrackAtTime(clip, newSource, currentSource, time));
    }
}
