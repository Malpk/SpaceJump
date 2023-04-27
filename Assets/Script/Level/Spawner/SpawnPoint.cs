using UnityEngine;

[System.Serializable]
public class SpawnPoint
{
    [SerializeField] private Vector2[] _rangsPosition;

    public Vector2[] RangsPosition => _rangsPosition;
}
