using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    [SerializeField] private Transform _platform;

    public void SetItem(Transform item)
    {
        if (item.TryGetComponent(out EnemyMovement enemy))
        {
            enemy.transform.position = transform.position;
        }
        else
        {
            item.parent = _platform;
            item.transform.localPosition = Vector3.zero;
        }
    }
}
