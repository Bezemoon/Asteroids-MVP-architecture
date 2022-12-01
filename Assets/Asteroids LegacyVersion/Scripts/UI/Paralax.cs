using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ShipMovement))]
public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform _ship;
    [SerializeField] private RawImage _background;
    [SerializeField] private float _speed;

    private ShipMovement _shipMovement;
    private float _imageXposition;
    private float _imageYposition;


    private void Start()
    {
        _shipMovement = GetComponent<ShipMovement>();
    }

    private void Update()
    {
        if(_shipMovement.CurrentSpeed > 0)
        {
            Vector3 normal = _ship.position.normalized;

            _imageXposition += PositionOffsetCalculation(normal.x);
            _imageYposition += PositionOffsetCalculation(normal.y);

            _background.uvRect = new Rect(_imageXposition, _imageYposition, _background.uvRect.width, _background.uvRect.height);
        }
    }

    private float PositionOffsetCalculation(float value)
    {
        return value * Time.deltaTime * _speed;
    }
}
