using UnityEngine;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private string _saveKey = "key";
    [Header("Reference")]
    [SerializeField] private JumpScore _jumpScore;
    [SerializeField] private MusicSetting _setting;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private PlayerContent _playerContent;

    private string _data;

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
        PlayerPrefs.SetString(_saveKey, _data);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(_saveKey))
        {
            var data = JsonUtility.FromJson
                <PlayerData>(PlayerPrefs.GetString(_saveKey));
            SetData(data);
        }
    }

    private string GetData()
    {
        var data = new PlayerData();
        data.Money = _wallet.Money;
        data.Record = _jumpScore.Record;
        data.MusicSetting = _setting.Save();
        data.BuyContent = _playerContent.Save();
        return JsonUtility.ToJson(data);
    }

    private void SetData(PlayerData data)
    {
        _wallet.SetMoney(data.Money);
        _setting.Load(data.MusicSetting);
        _jumpScore.SetRecord(data.Record);
        _playerContent.Load(data.BuyContent);
    }
}
