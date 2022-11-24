using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SampleSceneManager : MonoBehaviour
{
    private AudioManager                                     _audioManager = null;
    private List<AudioSource>                                _audioSources = new List<AudioSource>();
    private Dictionary<CommonParam.AudioClipType, AudioClip> _audioClips   = new Dictionary<CommonParam.AudioClipType, AudioClip>();

    private void Awake()
    {
        _audioManager = Resources.Load<AudioManager>("AudioManager");
        foreach (var value in Enum.GetValues(typeof(CommonParam.AudioClipType)))
        {
            var audioClip = Resources.Load<AudioClip>("AudioClips/" + value.ToString());
            _audioClips.Add((CommonParam.AudioClipType)value, audioClip);
        }
        _audioManager.SetAudioClips(_audioClips);
        foreach (int i in Enumerable.Range(0, 5))
        {
            _audioSources.Add(gameObject.AddComponent<AudioSource>());
        }
        _audioManager.SetAudioSources(_audioSources);
    }
}
