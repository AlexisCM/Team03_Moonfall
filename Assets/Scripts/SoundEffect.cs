using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SoundEffect {
    [SerializeField] private AudioClip _clip;
    [SerializeField] private string _name;
    [SerializeField] [Range(0, 1)] private float _volume;
    [SerializeField] private bool _loop;

    [HideInInspector]
    public AudioSource source;

    public AudioClip Clip { 
        get { return _clip; }
    }

    public string Name {
        get { return _name; }
    }

    public float Volume {
        get { return _volume; }
    }

    public bool Loop {
        get { return _loop; }
    }
}
