using UnityEngine;
using TMPro;

public class JumpScore : MonoBehaviour
{
    [SerializeField] private float _nightHeight;
    [SerializeField] private Color _dayColor;
    [SerializeField] private Color _nightColor;
    [Header("Reference")]
    [SerializeField] private Camera _camera;
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _score;

    private float _smooth = 0.1f;
    private float _velocity;
    private float _targetPosition;
    private float _startPosition;

    public int CurreHeight { get; private set; }

    public void Reset()
    {
        CurreHeight = 0;
        _targetPosition = 0f;
        _score.text = CurreHeight.ToString();
        _startPosition = _player.transform.position.y;
    }

    private void Update()
    {
        var curretHeight = _player.transform.position.y - _startPosition;
        if (curretHeight > _targetPosition)
            _targetPosition = curretHeight;
        CurreHeight = (int)Mathf.SmoothDamp(CurreHeight, _targetPosition, ref _velocity, _smooth);
        _score.text = CurreHeight.ToString();
    }
}
