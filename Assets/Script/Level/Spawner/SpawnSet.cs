using UnityEngine;

public class SpawnSet : MonoBehaviour
{
    [SerializeField] private int _spwanHeight;
    [SerializeField] private int _compliteSpawn;
    [SerializeField] private Pool _prefab;

    public int SpawnHeight => _spwanHeight;
    public int CompliteSpawn => _compliteSpawn;
    public Pool Pool => _prefab;
}
