using UnityEngine;

public class ItemClener : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.Dead();
        if (collision.TryGetComponent(out IMapItem item))
        {
            item.Delete();
        }
    }
}
