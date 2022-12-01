using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Asteroid))]
public class AsteroidColissionHandler : MonoBehaviour
{
    private Asteroid _asteroid;

    private void Awake()
    {
        _asteroid = GetComponent<Asteroid>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BlasterBullet blaster))
        {
            _asteroid.Explode();
            Destroy(blaster.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out LaserBullet laser))
        {
            _asteroid.IsShare = false;
            _asteroid.Explode();
        }
    }
}
