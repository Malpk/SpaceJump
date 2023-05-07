using UnityEngine;

public class BordResult : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private IntText _money;
    [SerializeField] private IntText _record;

    public void SetMoney(int money)
    {
        _record.SetText(money);
    }

    public void SetRecord(int record)
    {
        _money.SetText(record);
    }
}
