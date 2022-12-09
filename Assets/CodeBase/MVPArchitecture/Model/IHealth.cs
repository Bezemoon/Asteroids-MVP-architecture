using System;

namespace CodeBase.MVPArchitecture.Model
{
    public interface IHealth
    {
        int Health { get;}
        
        event Action HealthChanged;
        
        void TakeDamage();
    }
}