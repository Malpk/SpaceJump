using UnityEngine;

public class GravitySet : MonoBehaviour
{
    [Header("Cheak Setting")]
    [SerializeField] private int _countCheak = 1;
    [SerializeField] private float _cheakSizeZone;
    [SerializeField] private float _cheakDistance;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private AnimationCurve _gravityCurve;
    [Header("Gravity Setting")]
    [SerializeField] private float _gravityScale;
    [SerializeField] private float _gravityDuration;

    private float _steapCheak;
    private float _progress = 0f;

    public bool IsGround { get; private set; }
    public float GravityScale { get; private set; }
    public RaycastHit2D Contact { get; private set; }

    private void Awake()
    {
        _steapCheak = _countCheak > 1 ? _cheakSizeZone / (_countCheak - 1) : 0;
    }

    private void OnValidate()
    {
        _countCheak = _countCheak > 1 ? _countCheak : 1;
        _steapCheak = _countCheak > 1 ? _cheakSizeZone / (_countCheak - 1) : 0;
        _cheakSizeZone = _cheakSizeZone > 1 ? _cheakSizeZone : 1;
    }

    public void Reset()
    {
        _progress = 0f;
        GravityScale = 0f;
    }


    public void UpdateGravity()
    {
        _progress = !IsGround ? _progress +
             Time.fixedDeltaTime / _gravityDuration : Time.fixedDeltaTime;
        Mathf.Clamp01(_progress);
        GravityScale = _gravityScale * _gravityCurve.Evaluate(_progress);
        IsGround = CheakGround(GravityScale * Time.fixedDeltaTime);
    }

    private bool CheakGround(float gravityScale)
    {
        var start = transform.position - Vector3.right * _cheakSizeZone / 2;
        for (int i = 0; i < _countCheak; i++)
        {
            var position = start + Vector3.right * _steapCheak * i;
            Contact = Physics2D.Raycast(position, Vector2.down, gravityScale, _groundLayer);
            Debug.DrawLine(position, (Vector2)position +
                Vector2.down * gravityScale, Contact ? Color.green : Color.red);
            if (Contact)
                return Contact;
        }
        return false;
    }

}
