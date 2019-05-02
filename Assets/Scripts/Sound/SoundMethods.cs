using UnityEngine;
using UnityEngine.UI;

public class SoundMethods : MonoBehaviour
{
    [SerializeField] private Slider MusicSlider = null;
    [SerializeField] private Toggle MusicToggle = null;
    [SerializeField] private Slider SFXSlider = null;
    [SerializeField] private Toggle SFXToggle = null;


    private void Start()
    {
        MusicSlider.value = MusicController.GetVolume();
        MusicToggle.isOn = MusicController.GetMute();
        SFXSlider.value = SFXController.GetVolume();
        SFXToggle.isOn = SFXController.GetMute();
    }

    public void ChangeMusicVolume(float volume)
    {
        MusicController.ChangeMusicVolume(volume);
    }

    public void ToggleMuteMusic(bool mute)
    {
        MusicController.ToggleMuteMusic(mute);
    }

    public void ChangeSFXVolume(float volume)
    {
        SFXController.ChangeSFXVolume(volume);
    }

    public void ToggleMuteSFX(bool mute)
    {
        SFXController.ToggleMuteSFX(mute);
    }

    public void SavePlayerPrefs()
    {
        MusicController.SavePlayerPrefs();
        SFXController.SavePlayerPrefs();
    }
}
