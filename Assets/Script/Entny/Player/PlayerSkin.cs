using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _body;

    public void SetSkin(Sprite skin)
    {
        _body.sprite = skin;
    }
}
