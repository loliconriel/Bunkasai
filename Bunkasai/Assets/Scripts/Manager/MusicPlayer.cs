using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    AudioClip[] PauseEffectSource;
    [SerializeField]
    AudioClip[] audioClips;
    int Now_Play = 0;
    static public MusicPlayer instance;

    private void Awake()
    {
        //???š~??Q?R
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(instance.audioClips.Length!=0)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                instance.Now_Play++;
                if (instance.Now_Play >= instance.audioClips.Length)
                {
                    instance.Now_Play = 0;
                }
                GetComponent<AudioSource>().clip = instance.audioClips[Now_Play];//?????q??
                GetComponent<AudioSource>().Play();//????
            }
        }
        
    }
    public static void Pause()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach(AudioSource source in audioSources)
        {
            
            if(source.isActiveAndEnabled == true)
            {
                if (source.clip != null)
                {
                    foreach(AudioClip clip in instance.PauseEffectSource)
                    {
                        if (clip.name == source.clip.name)
                        {
                            if (source.isPlaying) source.Pause();
                            else source.UnPause();
                        }
                    }
                }
                
            }
        }
    } 
    public static void DestoryEffect()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {

            if (source.isActiveAndEnabled == true)
            {
                if (source.clip != null)
                {
                    Debug.Log(source.clip.name);
                    foreach (AudioClip clip in instance.PauseEffectSource)
                    {
                        if (clip.name == source.clip.name)
                        {
                            Destroy(source.gameObject);
                        }
                    }
                }

            }
        }
    }
}
