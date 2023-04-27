using UnityEngine;
using TMPro;

public class JumpScore : MonoBehaviour
{
    [SerializeField] private float _nightHeight;
    [SerializeField] private Color _dayColor;
    [SerializeField] private Color _nightColor;
    [Header("Reference")]
    [SerializeField] private Camera _camera;
    [SerializeField] private TextMeshProUGUI _score;

    private float _smooth = 0.1f;
    private float _velocity;
    private float _targetPosition;
    private float _startPosition;


    public int CurreHeight { get; private set; }

    public void SetStartPosition(float start)
    {
        _startPosition = start;
    }

    public void Reset()
    {
        CurreHeight = 0;
        _targetPosition = 0f;
        _score.text = CurreHeight.ToString();
    }

    private void Update()
    {
        CurreHeight = (int)Mathf.SmoothDamp(CurreHeight, _targetPosition, ref _velocity, _smooth);
        _score.text = CurreHeight.ToString();
    }

    public void UpdateScore(float jumpPositin)
    {
        var nextDistance = (int)Mathf.Abs(_startPosition - jumpPositin);
        if (nextDistance > CurreHeight)
            _targetPosition = nextDistance;
        _camera.backgroundColor = Vector4.Lerp(_dayColor, _nightColor,
            CurreHeight / _nightHeight);
    }
}
