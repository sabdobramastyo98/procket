using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource bgmSource;
    public Text musicText;
    public Slider musicSlider;
    public AudioClip[] audioClips;

    void Start()
    {
        Instance=this;
        Initiate();
    }

    public void setMusic(int id)
    {
        bgmSource.clip = audioClips[id];
        bgmSource.Play();
    }

    public void toggleMusic()
    {
        if(bgmSource.isPlaying){
            bgmSource.Pause();
            musicText.text = "Music Off";
        }
        else
        {
            bgmSource.Play();
            musicText.text = "Music On";
        }
    }

    public void Initiate()
    {
        bgmSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }

    public void setVolume()
    {
        bgmSource.volume = musicSlider.value;
        PlayMusic();
        PlayerPrefs.SetFloat("MusicVolume",bgmSource.volume);
    }

    public void PlayMusic()
    {
        bgmSource.Play();
        musicText.text = "Music On";
    }

    public void StopMusic()
    {
        bgmSource.Pause();
        musicText.text = "Music Off";
    }

    void Update()
    {
        
    }
}

