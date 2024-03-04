using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//������������ϣ�ͨ����ȡgunController����ȡ�ӵ���Ϣ�Բ�����ȷ��Ч
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

    //enum����ǿ����ɶ���
    public enum Sound
    {
        MOVE = 0, MACHINE_GUN,BIG_GUN,BOMB
    };

    public void stopSound()
    {
        //�ر�move��Ч
        SoundEffectPlayer.audioSource.clip = audioClips[4];//���ž�����Ч����Ӱ������Ч��
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
