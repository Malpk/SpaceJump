using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _grabMoney;
    [Header("Refrence")]
    [SerializeField] private AudioSource _source;

    public void Jump()
    {
        _source.PlayOneShot(_jump);
    }

    public void TakeMoney()
    {
        _source.PlayOneShot(_grabMoney);
    }
}
