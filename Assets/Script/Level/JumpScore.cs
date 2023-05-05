using UnityEngine;
using TMPro;

public class JumpScore : MonoBehaviour
{
    [SerializeField] private int _scoreUnit;
    [SerializeField] private float _spaceHeight;
    [SerializeField] private Color _dayColor;
    [SerializeField] private Color _nightColor;
    [Header("Reference")]
    [SerializeField] private Camera _camera;
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _record;

    private int _curretScore;
    private float _smooth = 0.5f;
    private float _velocity;
    private float _targetPosition;
    private float _startPosition;


    public int Record { get; private set; }
    public int CurreHeight { get; private set; } = 0;


    public void Reset()
    {
        SetRecord(CurreHeight);
        CurreHeight = 0;
        _targetPosition = 0f;
        _score.text = CurreHeight.ToString();
        _startPosition = _player.transform.position.y;
    }

    private void Update()
    {
        var height = (int)(_player.transform.position.y - _startPosition);
        if(height > CurreHeight)
            CurreHeight = height;
        UpdateScore();
        _camera.backgroundColor = Color.Lerp(_dayColor, _nightColor,
            CurreHeight / _spaceHeight);
    }

    private void UpdateScore()
    {
        var target = CurreHeight * _scoreUnit;
        if (target > _targetPosition)
            _targetPosition = target;
        _curretScore = (int)Mathf.SmoothDamp(_curretScore, _targetPosition, ref _velocity, _smooth);
        _score.text = (_curretScore).ToString();
    }

    public void SetRecord(int record)
    {
        if (record > Record)
        {
            Record = record;
            _record.text = record.ToString();
        }
    }
}
