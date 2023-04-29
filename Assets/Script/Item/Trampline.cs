using UnityEngine;

public class Trampline : MonoBehaviour
{
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpDuration;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.Jump(_jumpHeight, _jumpDuration);
        }
    }

}
