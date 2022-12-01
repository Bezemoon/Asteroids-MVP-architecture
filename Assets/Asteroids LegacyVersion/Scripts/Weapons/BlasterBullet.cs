using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterBullet : Bullet
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private float _elapsedTime;

    protected override void Move()
    {
        transform.Translate(PositionOffsetCalculation(Mathf.Cos(transform.rotation.z * Mathf.Deg2Rad)), PositionOffsetCalculation(Mathf.Sin(transform.rotation.z * Mathf.Deg2Rad)), 0);
    }

    private float PositionOffsetCalculation(float radian)
    {
        return _speed * Time.deltaTime * radian;
    }

    private void Update()
    {
        Move();

        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _lifeTime)
        {
            Destroy(gameObject);
            _elapsedTime = 0;
        }
    }
}
