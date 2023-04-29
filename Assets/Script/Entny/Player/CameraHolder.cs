using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private bool _freeFly;
    [Range(0,1f)]
    [SerializeField] private float _smoothTime;
    [Header("Reference")]
    [SerializeField] private Player _player;

    private float _velocity;
    private float _maxHeight = 0f;

    public void SetHeight(float height)
    {
        _maxHeight = height;
        transform.position = new Vector2(transform.position.x, height);
    }

    private void LateUpdate()
    {
        UpdateHeight();
        var target = Mathf.SmoothDamp(transform.position.y,
          _maxHeight, ref _velocity, _smoothTime);
        transform.position = new Vector2(transform.position.x, target);
    }

    private void UpdateHeight()
    {
        var height = _player.transform.position.y;
        _maxHeight = height > _maxHeight ? height : _maxHeight;
    }
}
