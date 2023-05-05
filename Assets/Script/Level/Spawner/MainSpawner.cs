using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnAdditionProbility;
    [Header("Reference")]
    [SerializeField] private MapBulder _mapBuilder;
    [SerializeField] private SpawnAddition[] _spawners;
}
