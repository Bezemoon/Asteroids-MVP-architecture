using UnityEngine;

namespace Asteroids_LegacyVersion.Scripts.Asteroids
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private bool _isShare;
        [SerializeField] private Asteroid _fragmentPrefab;

        private readonly int _numberOfFragments = 2;
        private Vector3 _direction;

        public bool IsShare
        {
            get { return _isShare; }
            set { _isShare = value; }
        }

        private void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        public void Explode()
        {
            _speed = 0;

            if (_isShare)
            {
                BreakDown();
            }

            Destruction();
        }

        private void BreakDown()
        {
            for(int i = 0; i < _numberOfFragments; i++)
            {
                var asteroid = Instantiate(_fragmentPrefab, transform.position, Quaternion.identity);

                asteroid.SetDirection(transform.rotation.z + (Mathf.Pow(-1, i) * 15 * -1));
            }
        }

        public void SetDirection(float angle)
        {
            float x = transform.position.magnitude * Mathf.Cos(Mathf.Deg2Rad * angle);
            float y = transform.position.magnitude * Mathf.Sin(Mathf.Deg2Rad * angle);
            _direction = new Vector3(x, y).normalized;
        }

        private void Destruction()
        {
            Destroy(gameObject);
        }
    }
}
