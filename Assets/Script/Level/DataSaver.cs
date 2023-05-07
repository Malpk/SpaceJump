using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class DataSaver : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    [SerializeField] private string _saveKey = "key";
    [Header("Reference")]
    [SerializeField] private JumpScore _jumpScore;
    [SerializeField] private MusicSetting _setting;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private PlayerContent _playerContent;

    private string _data;


    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    private void Awake()
    {
        Load();
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    public void Save()
    {
        _data = GetData();
#if UNITY_WEBGL && !UNITY_EDITOR
        SaveExtern(_data);
#else
        PlayerPrefs.SetString(_saveKey, _data);
#endif
    }

    private void Load()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        LoadExtern();
#else
        if (PlayerPrefs.HasKey(_saveKey))
        {
            SetData(PlayerPrefs.GetString(_saveKey));
        }
#endif
    }

    private string GetData()
    {
        var data = new PlayerData();
        data.Money = _wallet.Money;
        data.Record = _jumpScore.GetRecord();
        data.MusicSetting = _setting.Save();
        data.BuyContent = _playerContent.Save();
        return JsonUtility.ToJson(data);
    }

    public void SetData(string json)
    {
        var data = JsonUtility.FromJson<PlayerData>(json);
        _wallet.SetMoney(data.Money);
        _setting.Load(data.MusicSetting);
        _jumpScore.SetRecord(data.Record);
        _playerContent.Load(data.BuyContent);
    }
>>>>>>> Stashed changes
}
