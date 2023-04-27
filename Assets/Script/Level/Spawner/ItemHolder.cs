using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] private SpawnSet[] _sets;

    public Pool GetPool(int height)
    {
        var list = new List<Pool>();
        foreach (var set in _sets)
        {
            if (height >= set.SpawnHeight && set.CompliteSpawn >= height)
            {
                list.Add(set.Pool);
            }
        }
        return list.Count > 0 ? list[Random.Range(0, list.Count)] : 
            _sets[_sets.Length - 1].Pool;
    }
}
