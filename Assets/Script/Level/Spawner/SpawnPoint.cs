using UnityEngine;

[System.Serializable]
public class SpawnPoint
{
    [SerializeField] private int[] _directionsPatern;

    public int[] Paterns => _directionsPatern;
}
