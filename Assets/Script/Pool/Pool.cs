using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private PoolItem _prefab;

    private List<PoolItem> _pool = new List<PoolItem>();

    private void OnValidate()
    {
        name = _prefab?  $"Pool[{ _prefab.name}]" : "Pool";
    }

    public PoolItem Create(Transform parent = null)
    {
        var item = GetPrefab(parent ? parent : transform);
        item.OnDelete += AddPool;
        return item;
    }

    private PoolItem GetPrefab(Transform parent)
    {
        if (_pool.Count > 0)
        {
            var item = _pool[0];
            _pool.Remove(item);
            item.gameObject.SetActive(true);
            item.transform.parent = parent;
            return item;
        }
        return Instantiate(_prefab.gameObject, parent).GetComponent<PoolItem>();
    }

    private void AddPool(PoolItem item)
    {
        item.OnDelete -= AddPool;
        item.transform.parent = transform;
        item.gameObject.SetActive(false);
        item.transform.localPosition = Vector3.zero;
    }
}
