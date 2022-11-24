using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class AudioManager : ScriptableObject
{
    private List<AudioSource>                                _audioSourceLists = new List<AudioSource>();
    private Dictionary<CommonParam.AudioClipType, AudioClip> _audioClips       = new Dictionary<CommonParam.AudioClipType, AudioClip>();
    public void PlayOneShot(CommonParam.AudioClipType audioClipType)
    {
        var audioSource = GetAudioSource();
        if (null != audioSource)
        {
            audioSource.PlayOneShot(_audioClips[audioClipType]);
        }
    }

    public void SetAudioSource(AudioSource audioSource)
    {
        _audioSourceLists.Add(audioSource);
    }

    public void SetAudioSources(List<AudioSource> audioSources)
    {
        _audioSourceLists = audioSources;
    }

    public void SetAudioClips(Dictionary<CommonParam.AudioClipType, AudioClip> audioClips)
    {
        _audioClips = audioClips;
    }

    private AudioSource GetAudioSource()
    {
        foreach (var audioSource in _audioSourceLists)
        {
            if (!audioSource.isPlaying)
                return audioSource;
        }

        return null;
    }
}
