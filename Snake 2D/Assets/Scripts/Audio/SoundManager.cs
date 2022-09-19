using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
   private static SoundManager _instance;
   public static SoundManager instance { get { return _instance; } }

   [SerializeField] AudioSource musicAS;

    public SoundType[] audioClips;

    private void Awake()
    {
        if (_instance)
        {
            Destroy(this.gameObject);

        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

     private void Start()
    {
       
        PlayMusic(Sounds.BackGround);
    }

     public void PlayMusic(Sounds sound)
    {
        AudioClip soundClip = GetClip(sound);
        if (soundClip != null)
        {
            musicAS.clip = soundClip;
            musicAS.Play();
        }
    }

    public AudioClip GetClip(Sounds _clipType)
    {
        SoundType item = Array.Find(audioClips, i => i.clipType == _clipType);
        if (item != null) return item.clip;
        return null;
    }



}
[Serializable]
public class SoundType
{
    public Sounds clipType;
    public AudioClip clip;
}

public enum Sounds
{
    BackGround
}
