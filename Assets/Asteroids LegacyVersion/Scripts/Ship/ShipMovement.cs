using UnityEngine;


public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _stopDuration;

    private float _angleRotation;
    private float _currentSpeed;
    private float _interpolationValue = 0;
    private bool _isStopped;
    private float _elapsedTime;

    public float CurrentSpeed => _currentSpeed;
    public bool IsStopped => _isStopped;
    public float SpeedRotation => _speedRotation;

    public void Rotate(float step)
    {
        _angleRotation += step * Time.deltaTime;

        if (Mathf.Abs(_angleRotation) >= 360)
            _angleRotation = 0;


        transform.rotation = Quaternion.Euler(0, 0, _angleRotation);
    }


    public void Move()
    {
        _currentSpeed = Mathf.Lerp(0, _speed, _interpolationValue);
        transform.position += new Vector3(PositionOffsetCalculation(Mathf.Cos(Mathf.Deg2Rad * _angleRotation)), PositionOffsetCalculation(Mathf.Sin(Mathf.Deg2Rad * _angleRotation)));
    }


    private float PositionOffsetCalculation(float radian)
    {
        return _currentSpeed * Time.deltaTime * radian;
    }

    public void Timer()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _stopDuration)
        {
            PlayMotion();
            _elapsedTime = 0;
        }
    }

    public void StopMotion()
    {
        _isStopped = true;
        _interpolationValue = 0;
    }

    private void PlayMotion()
    {
        _isStopped = false;
    }

    private float CalculateInterpolationValue(float value)
    {
        return value * Time.deltaTime;
    }

    public void IncreaseValue()
    {
        _interpolationValue += CalculateInterpolationValue(1.0f);

        if(_interpolationValue >= 1)
        {
            _interpolationValue = 1;
        }
    }

    public void DecreaseValue()
    {
        _interpolationValue -= CalculateInterpolationValue(0.4f);

        if(_interpolationValue <= 0)
        {
            _interpolationValue = 0;
        }
    }
}
