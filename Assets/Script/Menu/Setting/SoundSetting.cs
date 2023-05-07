using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private AnimationCurve _settingCurve;
    [Header("Reference")]
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _generalSetting;
    [SerializeField] private AudioMixer _mixer;

    private const float MINVOLUME = -80;

    private void Start()
    {
        UpdateVolume();
    }

    public void UpdateVolume()
    {
        _mixer.SetFloat("volume", MINVOLUME * 
            _settingCurve.Evaluate(_slider.value *_generalSetting.value));
    }

    public float Save()
    {
        return _slider.value;
    }

    public void Load(float value)
    {
        _slider.value = value;
    }
}
