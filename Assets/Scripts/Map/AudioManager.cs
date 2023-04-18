using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// …˘“Ùπ‹¿Ì∆˜
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    private AudioClip coin1Audio, coinStarAudio, dieAudio, pickMagnetAudio, jetackAudio;

    public AudioSource audioSource;
    public AudioSource jetpackAudioSource;
    private void Start()
    {
        instance = this;
    }

    public void Coin1Audio()
    {
        audioSource.clip = coin1Audio;
        audioSource.Play();
    }

    public void CoinStarAudio()
    {
        audioSource.clip = coinStarAudio;
        audioSource.Play();
    }
    public void DieAudio()
    {
        audioSource.clip = dieAudio;
        audioSource.Play();
    }
    public void JetpackAudio()
    {
        jetpackAudioSource.clip = jetackAudio;
        jetpackAudioSource.Play();
    }
    public void MagnetAudio()
    {
        audioSource.clip = pickMagnetAudio;
        audioSource.Play();
    }

}