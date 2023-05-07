using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private GameObject _body;

    private float _scaleX;

    public bool FlipX => transform.localScale.x < 0;

    public void SetSkin(GameObject skin)
    {
        Destroy(_body);
        _body = Instantiate(skin,transform);
        _scaleX = _body.transform.localScale.x;
        _body.transform.localPosition = Vector3.zero;
    }
}
