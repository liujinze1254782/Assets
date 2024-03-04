using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//挂载在玩家身上，通过读取gunController来获取子弹信息以播出正确音效
public class AudioController : MonoBehaviour
{
    public AudioClip[] audioClips;
    private GunController gun;
    private void Awake()
    {
        gun = GetComponentInChildren<GunController>();
        SoundEffectPlayer.audioSource.clip = audioClips[(int)Sound.MOVE];
        SoundEffectPlayer.audioSource.Play();
    }

    //enum以增强代码可读性
    public enum Sound
    {
        MOVE = 0, MACHINE_GUN,BIG_GUN,BOMB
    };

    public void stopSound()
    {
        //关闭move音效
        SoundEffectPlayer.audioSource.clip = audioClips[4];//播放静音音效，不影响其他效果
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
