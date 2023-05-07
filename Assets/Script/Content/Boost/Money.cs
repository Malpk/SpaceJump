using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _moneyCount;
    [SerializeField] private PoolItem _poolItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeMoney(_moneyCount);
            _poolItem.Delete();
        }
    }
}
