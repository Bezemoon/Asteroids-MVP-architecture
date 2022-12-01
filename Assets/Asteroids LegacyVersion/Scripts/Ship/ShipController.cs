using Asteroids_1._0.Scripts.Ship;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private ShipMovement _movement;

    private void Update()
    {
        if (!_movement.IsStopped)
        {
            if (!_ship.IsReloading)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (_ship.CurrentWeapon.TryGetComponent(out Laser laser))
                    {
                        _movement.StopMotion();
                    }

                    if (_ship.CurrentWeapon.CurrentCapacity > 0)
                    {

                        _ship.CurrentWeapon.Shoot(_ship.ShootPoint);

                    }
                    else
                    {
                        _ship.ChangeReloadingState();
                    }
                }
            }
            else
            {
                _ship.ReloadTimer();

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _ship.SwitchWeapon();
            }

            if (Input.GetKey(KeyCode.A))
                _movement.Rotate(_movement.SpeedRotation);

            if (Input.GetKey(KeyCode.D))
                _movement.Rotate(-_movement.SpeedRotation);

            if (Input.GetKey(KeyCode.W))
                _movement.IncreaseValue();
            else
                _movement.DecreaseValue();

            _movement.Move();
        } 
        else
        {
            _movement.Timer();
        }
    }
}
