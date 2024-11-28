using UnityEngine;

public class PlayerClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    public void Init()
    {
        _audioSource.clip = _audioClip;
    }

    public void Play()
    {
        _audioSource.Play();
    }
}