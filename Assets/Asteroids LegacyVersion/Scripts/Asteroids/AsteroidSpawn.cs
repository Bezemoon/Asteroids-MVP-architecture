using System.Collections.Generic;
using UnityEngine;

namespace Asteroids_LegacyVersion.Scripts.Asteroids
{
    public class AsteroidSpawn : MonoBehaviour
    {
        [SerializeField] private List<Asteroid> _asteroidPrefabs;
        [SerializeField] private int _quantity;
        [SerializeField] private float _maxValueSpawnPoint;
        [SerializeField] private float _minValueSpawnPoint;

        private Camera _camera;
        private int _currentQuantity;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _currentQuantity = _quantity;
            Spawn();
        }

        private void Spawn()
        {
            for(int i = 0; i < _quantity; i++)
            {
                int asteroidXPosition = (int) Random.Range(_minValueSpawnPoint, _maxValueSpawnPoint);
                int asteroidYPosition = (int) Random.Range(_minValueSpawnPoint, _maxValueSpawnPoint);

                var asteroid = Instantiate(_asteroidPrefabs[Random.Range(0, _asteroidPrefabs.Count)], new Vector3(asteroidXPosition, asteroidYPosition, 0), Quaternion.identity);
                asteroid.SetDirection(Random.Range(0, 360));
            }
        }
    }
}
