using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] private AudioClip[] _playlist;
    private AudioSource _soundtrack;
    private int _currentTrack;

    void Awake() {
        _soundtrack = GetComponent<AudioSource>();
        _currentTrack = Random.Range(0, _playlist.Length);
    }

    void Start() {
        StartCoroutine(nameof(Playlist));
    }

    private IEnumerator Playlist() {
        while (true) {
            yield return new WaitForSeconds(1.0f);

            if (!_soundtrack.isPlaying) {
                _currentTrack = _currentTrack != (_playlist.Length - 1) ? _currentTrack + 1 : 0;

                _soundtrack.clip = _playlist[_currentTrack];
                _soundtrack.Play();
            }
        }
    }
}
