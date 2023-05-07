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
    [SerializeField] private TextMeshProUGUI _recordText;

    private int _record;
    private int _curretScore;
    private float _smooth = 0.5f;
    private float _velocity;
    private float _targetPosition;
    private float _startPosition;

    public int CurreHeight { get; private set; } = 0;


    public void Reset()
    {
        SetRecord((int)_targetPosition);
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
        if (record > _record)
        {
            _record = record;
            _recordText.text = record.ToString();
        }
    }

    public int GetRecord()
    {
        return _record > _targetPosition ? _record : (int)_targetPosition;
    }
}
