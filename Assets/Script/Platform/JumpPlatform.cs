using UnityEngine;

[RequireComponent(typeof(PoolItem))]
public class JumpPlatform : MonoBehaviour, IMapItem
{
    [SerializeField] private Transform _platform;

    private PoolItem _item;
    private PoolItem _containItem;

    private void Awake()
    {
        _item = GetComponent<PoolItem>();
    }

    public void SetItem(Transform item)
    {
        if (item.TryGetComponent(out Enemy enemy))
        {
            enemy.transform.position = transform.position;
        }
        else
        {
            item.parent = _platform;
            item.transform.localPosition = Vector3.zero;
        }
        _containItem = item.GetComponent<PoolItem>();
    }

    public void Delete()
    {
        if(_containItem)
            _containItem.Delete();
        _item.Delete();
    }
}
