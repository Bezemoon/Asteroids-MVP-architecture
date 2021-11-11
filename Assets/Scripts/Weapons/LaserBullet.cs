using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ќе забудь ограничить количество снар€дов за раз
/// </summary>

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class LaserBullet : Bullet
{
    [SerializeField] private float _duration;

    private Animator _animator;
    private float _elapsedTime;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.Play("Appearance");
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _duration)
        {
            _animator.Play("Diffusion");
            Invoke("Destruction", .5f);
        }
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }

}
