using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser : Weapon
{
    private bool _isShoot;

    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint);
        CurrentCapacity--;
    }
}
