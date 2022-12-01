using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected int Capacity;

    public int CurrentCapacity { get; protected set; }

    public abstract void Shoot(Transform shootPoint);

    public virtual void Reload(float value) 
    {
        CurrentCapacity = (int)Mathf.Lerp(0, Capacity, value);
    }

    public virtual void LoadBullets()
    {
        CurrentCapacity = Capacity;
    }

}
