using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    [SerializeField]
    public AudioSource source;
    [SerializeField]
    public AudioSource[] sfxSources;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        if (instance ==  null )
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
            Destroy(gameObject);
    }
    


    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    public void SetMusicVolume(float volume)
    {
        if (source != null)
        {
            source.volume = volume;
        }
    }

    
}
