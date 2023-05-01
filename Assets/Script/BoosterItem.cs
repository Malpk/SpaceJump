using UnityEngine;

public class BoosterItem : MonoBehaviour
{
    [SerializeField] private AirBall _booster;
    [SerializeField] private PoolItem _poolItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TransportSet set))
        {
            if (set.IsReady)
            {
                _booster.gameObject.SetActive(true);
                _booster.transform.parent = null;
                _booster.OnComplite += Complite;
                gameObject.SetActive(false);
                set.Enter(_booster);
            }
        }
    }

    private void Complite()
    {
        _booster.gameObject.SetActive(false);
        transform.position = _booster.transform.position;
        _booster.transform.parent = transform;
        _poolItem.Delete();
    }
}
