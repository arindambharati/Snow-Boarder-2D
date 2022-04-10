using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    public SoundType[] Audio;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Play(Sounds.BackgroundMusic);
        PlaySFX(Sounds.AmbientWindSound);
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null){
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else{
            Debug.LogError("Clip not found for soundtype: " + sound);
        }
    }

    public void PlaySFX(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundEffect.clip = clip;
            soundEffect.Play();
        }
        else
        {
            Debug.LogError("Clip not found for soundtype: " + sound);
        }
    }

    public void Stop(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundEffect.clip = clip;
            soundEffect.Stop();
        }
        else
        {
            Debug.LogError("Clip not found for soundtype: " + sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType audioType= Array.Find(Audio, item => item.soundType == sound);
        if (audioType != null) return audioType.soundClip;
        return null;
    }

    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip soundClip;
    }

    public enum Sounds
    {
        BackgroundMusic,
        AmbientWindSound,
        PlayerMove,
        PlayerDeath
    }
}
