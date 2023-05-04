using UnityEngine;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{
    [SerializeField] private Slider _generalSlider;
    [SerializeField] private SoundSetting _musicSlider;
    [SerializeField] private SoundSetting _volumeSlider;

    private SettingData _setting;

    public void UpdateSetting()
    {
        _generalSlider.value = _setting.General;
        _volumeSlider.Load(_setting.Volume);
        _musicSlider.Load(_setting.Music);
    }

    public void SaveSetting()
    {
        _setting = new SettingData();
        _setting.General = _generalSlider.value;
        _setting.Volume = _volumeSlider.Save();
        _setting.Music = _musicSlider.Save();
    }

    public string Save()
    {
        SaveSetting();
        return JsonUtility.ToJson(_setting);
    }

    public void Load(string save)
    {
        _setting = JsonUtility.FromJson<SettingData>(save);
        UpdateSetting();
    }
}
