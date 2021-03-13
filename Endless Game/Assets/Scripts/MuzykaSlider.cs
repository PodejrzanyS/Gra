using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuzykaSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject ObjectMusic;

    private float MusicVolume = 0f;
    private AudioSource AudioSource;

    // Start is called before the first frame update
    private void Start()
    {
        ObjectMusic = GameObject.FindWithTag("Muzyka");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        MusicVolume = PlayerPrefs.GetFloat("Volume");
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;
    }

    // Update is called once per frame
    private void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("Volume", MusicVolume);
    }

    public void VolumeUpdater(float Volume)
    {
        MusicVolume = Volume;
    }

    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("Volume");
        AudioSource.volume = 1;
        volumeSlider.value = 1;
    }
}
