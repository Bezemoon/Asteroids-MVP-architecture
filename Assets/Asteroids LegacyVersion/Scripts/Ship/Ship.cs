using System.Collections.Generic;
using UnityEngine;

namespace Asteroids_LegacyVersion.Scripts.Ship
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private ShipMovement _movement;
        [SerializeField] private int _health;
        [SerializeField] private float _cooldown;
    
        private Weapon _currentWeapon;
        private int _currentWeaponIndex;
        private int _score;
        private int _currentHealth;
        private float _elapsedTime;
    
        public Weapon CurrentWeapon => _currentWeapon;
        public Transform ShootPoint => _shootPoint;
    
        public bool IsReloading
        {
            get;
            private set;
        }
    
        private void Start()
        {
            ResetPlayer(); 
        }
    
        public void ResetPlayer()
        {
            transform.position = Vector3.zero;
            _currentHealth = _health;
            SetWeapon();
        }
    
        private void SetWeapon()
        {
            _currentWeapon = _weapons[_currentWeaponIndex];
            _currentWeapon.LoadBullets();
        }
    
        public void ReloadTimer()
        {
            _elapsedTime += Time.deltaTime;
            _currentWeapon.Reload(_elapsedTime / _cooldown);
    
            if (_elapsedTime >= _cooldown)
            {
                _elapsedTime = 0;
                ChangeReloadingState();
            }
        }
    
        public void ChangeReloadingState()
        {
            IsReloading = !IsReloading;
        }
    
        public void SwitchWeapon()
        {
            _currentWeaponIndex++;
    
            if(_currentWeaponIndex >= _weapons.Count)
            {
                _currentWeaponIndex = 0;
            }
    
            SetWeapon();
        }
    
        
    
    
    }    
}
