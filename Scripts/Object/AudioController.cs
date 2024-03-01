using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] audioClips;
    private GunController gun;
    private void Awake()
    {
        gun = GetComponentInChildren<GunController>();
    }
    public enum Sound
    {
        MOVE = 0, MACHINE_GUN,BIG_GUN,BOMB
    };

    public void stopSound()
    {
        //πÿ±’move“Ù–ß
        SoundEffectPlayer.audioSource.clip = audioClips[4];
        SoundEffectPlayer.audioSource.Play();
    }
    #region soundPlayer
    public void playMove()
    {
        SoundEffectPlayer.audioSource.volume = 0.4f;
        SoundEffectPlayer.audioSource.clip = audioClips[(int)Sound.MOVE];
        SoundEffectPlayer.audioSource.Play();
    }
    public void playGun()
    {
        SoundEffectPlayer.audioSource.mute = false;
        if (gun.currentAmmo == 0)
            SoundEffectPlayer.audioSource.PlayOneShot(audioClips[(int)Sound.MACHINE_GUN]);
        else
            SoundEffectPlayer.audioSource.PlayOneShot(audioClips[(int)Sound.BIG_GUN]);
    }

    public void playBomb()
    {
        SoundEffectPlayer.audioSource.mute = false;
        SoundEffectPlayer.audioSource.PlayOneShot(audioClips[(int)Sound.BOMB]);
    }
    #endregion
}
