using UnityEngine;

public class LevelBorder : MonoBehaviour
{
    [SerializeField] private float _distanceBorder = 20f;
    [SerializeField] private TransportSet _player;

    private void Update()
    {
        Move(_player.CurretParent);
    }

    private void Move(Transform holder)
    {
        if (_distanceBorder < Mathf.Abs(holder.position.x))
        {
            var direction = -holder.position.x / Mathf.Abs(holder.position.x);
            holder.position = new Vector2(direction * (_distanceBorder - 1), holder.position.y);
        }
    }

}
