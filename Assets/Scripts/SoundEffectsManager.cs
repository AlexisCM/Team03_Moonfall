using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEffectsManager : MonoBehaviour {
    [SerializeField] SoundEffect[] _soundEffectArray;

    public static SoundEffectsManager Instance { get; private set; }

    private void Awake() {
        if ( Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        foreach (SoundEffect sound in _soundEffectArray) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.Clip;
            sound.source.volume = sound.Volume;
            sound.source.loop = sound.Loop;
        }
    }

    public void Play(string name) {
        Find(name).source.Play();
    }

    public void Pause(string name) {
        Find(name).source.Pause();
    }

    public void Stop(string name) {
        Find(name).source.Stop();
    }

    public bool IsPlaying(string name) {
        return Find(name).source.isPlaying;
    }

    private SoundEffect Find(string name) {
        SoundEffect s = Array.Find(_soundEffectArray, sound => sound.Name == name);

        if (s == null) {
            throw new ArgumentException("Sound Effect '" + s.Name + "' could not be found.");
        }

        return s;
    }
}
