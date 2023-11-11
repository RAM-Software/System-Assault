using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioMixer _mixer;
    public AudioSource _levelMusic, _levelSFX;

    [NonSerialized]
    public float _masterVol, _musicVol, _SFXVol;

    [System.Serializable]
    public struct Clip
    {

        public string clipName;
        public AudioClip audio;
        public bool isLoop;
    }

    public Clip[] SFXClip, musicClip;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _masterVol = PlayerPrefs.GetFloat("MasterVol");
        _musicVol = PlayerPrefs.GetFloat("MusicVol");
        _SFXVol = PlayerPrefs.GetFloat("SFXVol");
        _mixer.SetFloat("MasterVol", _masterVol);
        _mixer.SetFloat("MusicVol", _musicVol);
        _mixer.SetFloat("SFXVol", _SFXVol);

        //PlayMusic("BGM"); // Uncomment if music needs to play immediately
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayMusic(string name)
    {
        Clip sound = Array.Find(musicClip, x => x.clipName == name);

        if (sound.clipName == null)
        {
            Debug.Log("Audio source not found");
            return;
        }
        else
        {
            _levelMusic.clip = sound.audio;
            _levelMusic.Play();
            if (sound.isLoop)
            {
                _levelMusic.loop = true;
            }
            else
            {
                _levelMusic.loop = false;
            }
        }

    }
    public void PlaySFX(string name)
    {
        Clip sound = Array.Find(SFXClip, x => x.clipName == name);

        if (sound.clipName == null)
        {
            Debug.Log("Audio source not found");
            return;
        }
        else
        {
            _levelSFX.clip = sound.audio;
            _levelSFX.PlayOneShot(_levelSFX.clip);
            if (sound.isLoop)
            {
                _levelSFX.loop = true;
            }
            else
            {
                _levelSFX.loop = false;
            }
        }
    }
    
    public void SetMaster(float slider)
    {
        _masterVol = slider;
        _mixer.SetFloat("MasterVol", Mathf.Log10(_masterVol) * 20);
        PlayerPrefs.SetFloat("MasterVol", Mathf.Log10(_masterVol) * 20);
    }
    public void SetMusic(float slider)
    {
        _musicVol = slider;
        _mixer.SetFloat("MusicVol", Mathf.Log10(_musicVol) * 20);
        PlayerPrefs.SetFloat("MusicVol", Mathf.Log10(_musicVol) * 20);
    }
    public void SetSFX(float slider)
    {
        _SFXVol = slider;
        _mixer.SetFloat("SFXVol", Mathf.Log10(_SFXVol) * 20);
        PlayerPrefs.SetFloat("SFXVol", Mathf.Log10(_SFXVol) * 20);
    }
}
