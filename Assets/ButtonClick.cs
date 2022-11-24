using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField]
    private CommonParam.AudioClipType _audioClipType = CommonParam.AudioClipType.cancelSE;
    private AudioManager _audioManager = null;
    private Button       _button       = null;
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = Resources.Load<AudioManager>("AudioManager");
        _button       = GetComponent<Button>();
        _button.onClick.AddListener(() => _audioManager.PlayOneShot(_audioClipType));
    }
}
